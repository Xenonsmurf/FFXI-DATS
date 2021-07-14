using FFXI_INFO.Common.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FFXI_INFO.Common
{
    public class DialogueDats
    {
        public DialogueDats()
        {
        }
        [JsonProperty(Order = 1)] public int id { get; set; }
        [JsonProperty(Order = 2)] public string name { get; set; }
        [JsonProperty(Order = 3)] public List<_dialogue> dialogue = new List<_dialogue>();
        public void ParseDialogueDat(string datPath, int Id, string Name)
        {
            id = Id;
            name = Name;
            dialogue.Clear();
                try
                {
                    //changed back to the way polutilites does this, as i was having issues reading as span, will investigate and update.
                    using BinaryReader br = new(File.OpenRead(datPath));
                    {
                        var length = br.ReadUInt32();
                        var textposition = (br.ReadUInt32() ^ 0x80808080);
                        var count = textposition / 4;
                        var dialogEntries = new List<uint>((int)count + 1) { textposition };
                        for (var i = 1; i < count; ++i)
                        {
                            dialogEntries.Add(br.ReadUInt32() ^ 0x80808080);
                        }
                        dialogEntries.Add((uint)br.BaseStream.Length - 4);
                        dialogEntries.Sort();
                        for (var i = 0; i < (int)count; ++i)
                        {
                            if (dialogEntries[i] < 4 * (int)count || 4 + dialogEntries[i] >= br.BaseStream.Length)
                            {
                                break;
                            }
                            long textStart = dialogEntries[i];
                            long textEnd = dialogEntries[i + 1];
                            br.BaseStream.Seek(4 + textStart, SeekOrigin.Begin);
                            var textByteArray = br.ReadBytes((int)(textEnd - textStart));

                            for (var I = 0; I < textByteArray.Length; ++I)
                            {
                                textByteArray[I] ^= 0x80;
                            }
                            var Text = Encoding.UTF8.GetString(textByteArray).TrimEnd('\0');
                            dialogue.Add(new _dialogue { id = i, text = Text }); 
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.ToString());
                }
                DumpToJson();
        }

        private void DumpToJson()
        {
            try
            {
                var path = ($@"{AppDomain.CurrentDomain.BaseDirectory}Dialogue");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (!Directory.Exists(path)) return;
                var outFile = File.Create($@"{path}\\{name}.json");
                outFile.Close();
                string JSONresult = JsonConvert.SerializeObject(this);
                string jsonFormatted = JValue.Parse(JSONresult).ToString(Formatting.Indented);
                File.WriteAllText(outFile.Name, jsonFormatted);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
            }
        }
        public  bool Decrypted(Span<byte> data)
        {
            try
            {
                byte result;
                int i = 4;
                result = data[3];
                if (result > 0  && result == 16)
                {
                    while (i < data.Length)
                    {
                        data[i] ^= 0x80;
                        i++;
                    }
                    return true;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a Dialogue dat. or its a dat for a zone with no Dialogue.");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }
    }
}
