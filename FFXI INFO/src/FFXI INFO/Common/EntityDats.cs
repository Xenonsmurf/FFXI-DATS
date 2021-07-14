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

namespace FFXI_INFO.Common
{
    public class EntityDats
    {
        private static getRomPath Rom = new getRomPath();

        [JsonProperty(Order = 1)]
        public int id { get; set; }
        [JsonProperty(Order = 2)]
        public string name { get; set; }
        [JsonProperty(Order = 3)]
        public List<_entity> entities = new();
        private int fileId { get; set; }
        public EntityDats(getRomPath rp)
        {
            Rom = rp;
        }
        public EntityDats()
        {
        }

        public void ParseDat(Span<byte> data, int zone, string zName)
        {
            entities.Clear();
            id = zone;
            name = zName;
            try
            {
                if (data.Length > 32)
                {
                    for (var I = 0; I < data.Length;)
                    {
                        var Name = Encoding.ASCII.GetString(data.Slice(I, 28)).TrimEnd('\0');
                        if (data.Length > 32)
                        {
                            var ServerID = MemoryMarshal.Read<uint>(data[(I + 28)..]);
                            var TargetIndex = (int)(ServerID & 0xFFF);
                            var zoneId = (int)((ServerID >> 12) & 0xFFF);
                            entities.Add(new _entity { name = Name, serverID = ServerID, targetIndex = TargetIndex, zoneID = zoneId });
                            I += 32;
                        }
                    }
                }
                if (data.Length <= 32)
                {
                    entities.Add(new _entity { name = "none", serverID = 0, targetIndex = 0, zoneID = zone });
                }
                data.Clear();
                DumpToJson(zone);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
            }
        }

        private void DumpToJson(int zone)
        {
            try
            {
                var path = ($@"{AppDomain.CurrentDomain.BaseDirectory}Entities");
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
    }

}