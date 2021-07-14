using FFXI_INFO.Common.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXI_INFO.Common
{
    public class ZoneListDat
    {
        private readonly List<int> _ignore = new()
        {
            133,
            278,
            286,
            189,
            199,
            210,
            214,
            219,
            229,
        };

        public ZoneListDat(getRomPath rp)
        {
            Rom = rp;
            _zones = new ObservableCollection<_zones>();
        }

        public ObservableCollection<_zones> _zones { get; set; }
        private int position { get; set; } = 0;
        private getRomPath Rom { get; set; }

        public bool Decrypted(Span<byte> data)
        {
            try
            {
                while (position < data.Length)
                {
                    data[position] ^= 0xff;
                    position++;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }
        public void ParseZoneList(Span<byte> data)
        {
            try
            {
                ResetList();
                if (!Decrypted(data)) return;
                var pos = 0x9C0;
                var i = 0;
                while (pos < data.Length)
                {
                    var offset = 1;
                    var text = Encoding.ASCII.GetString(data.Slice(pos, offset));
                    while (!text.Contains("\0"))
                    {
                        text = Encoding.ASCII.GetString(data.Slice(pos, offset));
                        offset++;
                    }
                    var name = text.TrimEnd('\0');
                    if (name != "" && name != "\u0001" && name != "\f")
                    {
                        var zone = new _zones();
                        if (_ignore.Contains(i))
                        {
                            i++;
                        }
                        var fileId = i < 256 ? i + 100 : i + 83635;
                        zone.id = i;
                        zone.name = name;
                        zone.path = Rom.GetRomPath(fileId, Rom.tableDirectory);

                        _zones.Add(zone);
                        i++;
                    }
                    pos += text.Length;
                    if (pos > data.Length)
                    {
                        break;
                    }
                }
                var sortedList = new ObservableCollection<_zones>(_zones.OrderBy(x => x.id).ToList());
                _zones = sortedList;
                DumpToJson();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        private void DumpToJson()
        {
            try
            {
                var path = ($@"{AppDomain.CurrentDomain.BaseDirectory}");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (!Directory.Exists(path)) return;
                var outFile = File.Create($@"{path}\\ZoneList.json");
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
        private void ResetList()
        {
            _zones.Clear();
            _zones.Add(new _zones { id = 133, name = "Lobby", path = "ROM/1/5.DAT" });
            _zones.Add(new _zones { id = 278, name = "None1", path = Rom.GetRomPath(83913, Rom.tableDirectory) });
            _zones.Add(new _zones { id = 286, name = "None2", path = Rom.GetRomPath(83921, Rom.tableDirectory) });
            _zones.Add(new _zones { id = 189, name = "Residential_Area1", path = Rom.GetRomPath(289, Rom.tableDirectory) });
            _zones.Add(new _zones { id = 199, name = "Residential_Area2", path = Rom.GetRomPath(299, Rom.tableDirectory) });
            _zones.Add(new _zones { id = 210, name = "GM_Home", path = Rom.GetRomPath(310, Rom.tableDirectory) });
            _zones.Add(new _zones { id = 214, name = "Residential_Area3", path = Rom.GetRomPath(314, Rom.tableDirectory) });
            _zones.Add(new _zones { id = 219, name = "Residential_Area4", path = Rom.GetRomPath(319, Rom.tableDirectory) });
            _zones.Add(new _zones { id = 229, name = "None", path = Rom.GetRomPath(329, Rom.tableDirectory) });
        }
    }
}