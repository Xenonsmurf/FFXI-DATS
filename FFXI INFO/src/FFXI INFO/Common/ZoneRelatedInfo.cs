using FFXI_INFO.Common.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXI_INFO.Common
{
  public  class ZoneRelatedInfo
    {
        private static getRomPath Rom { get; set; }
        private static ZoneListDat ZoneList { get; set; }
        [JsonProperty(Order = 1)]
        public List<_zoneRelatedInfo> zoneInfo = new List<_zoneRelatedInfo>();
        

        public ZoneRelatedInfo(getRomPath rp, ZoneListDat zl)
        {
            Rom = rp;
            ZoneList = zl;
        }
        public ZoneRelatedInfo()
        {
        }
        public static string GetZoneName(int id)
        {
            if (ZoneList._zones.Count() > 0)
            {
                foreach (var zone in ZoneList._zones)
                {
                    if (zone.id == id)
                    {
                        return zone.name;
                    }
                }
            }
            if (ZoneList._zones.Count() <= 0)
            {
                return $@"{id}";
            }
            return $@"{id}";
        }
        public void start()
        {
            zoneInfo.Clear();
            for (int i = 0; i < 299; i++)
            {
                GetInfo(i, GetZoneName(i));
            }
            for (int i = 1000; i < 1299; i++)
            {
                GetInfo(i, GetZoneName(i));
            }
            DumpToJson();

        }
        public void GetInfo(int id, string Name)
        {
            var info = new _zoneRelatedInfo();
            info.id = id;
            info.name = Name;
            var fileId = 0;

            fileId = id < 256 ? id + 39831 : id + 84435;
            if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}"))
            {
                info.BumpMap_Dat_Path = Rom.GetRomPath(fileId, Rom.tableDirectory);
            }
            fileId = id < 256 ? id + 100 : id + 83635;
            if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}"))
            {
                info.Main_Model_Dat_Path = Rom.GetRomPath(fileId, Rom.tableDirectory);
            }
            fileId = 7052;
            if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}"))
            {
                info.Shodow_Dat_Path = Rom.GetRomPath(fileId, Rom.tableDirectory);
            }


            if (id < 2000)
            {
                if (id < 1000)
                {
                    fileId = id < 256 ? id + 5820 : id + 84735;
                    if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}"))
                    {
                        info.Event_Dat_Path = Rom.GetRomPath(fileId, Rom.tableDirectory);
                    }
                }
                else
                {
                    fileId = id + 56881;
                    if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}"))
                    {
                        info.Event_Dat_Path = Rom.GetRomPath(fileId, Rom.tableDirectory);
                    }

                }
            }
            else
            {
                fileId = id + 65611;
                if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}"))
                {
                    info.Event_Dat_Path = Rom.GetRomPath(fileId, Rom.tableDirectory);
                }
            }



            if (id < 1000 || id > 1299)
            {
                fileId = id < 256 ? id + 6720 : id + 86235;

                if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}"))
                {
                    info.Entity_Dat_Path = Rom.GetRomPath(fileId, Rom.tableDirectory);
                }
            }
            else
            {
                fileId = id + 66911;
                if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}"))
                {
                    info.Entity_Dat_Path = Rom.GetRomPath(fileId, Rom.tableDirectory);
                }
            }

            if (id < 1000 || id > 1299)
            {
                fileId = id < 256 ? id + KeyTables.GetDatFileIdOffset(105) : KeyTables.GetDatFileIdOffset(108) + id - 256;

                if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}"))
                {

                    info.Dialogue_Dat_Path = Rom.GetRomPath(fileId, Rom.tableDirectory);
                }
            }
            else
            {
                fileId = KeyTables.GetDatFileIdOffset(107) + id - 1000;

                if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}"))
                {
                    info.Dialogue_Dat_Path = Rom.GetRomPath(fileId, Rom.tableDirectory);
                }
            }

            zoneInfo.Add(info);
        }
        private void DumpToJson()
        {
            try
            {
                var path = ($@"{AppDomain.CurrentDomain.BaseDirectory}");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (!Directory.Exists(path)) return;
                var outFile = File.Create($@"{path}\\ZoneINFO.json");
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
