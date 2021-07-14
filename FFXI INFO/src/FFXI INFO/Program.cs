using FFXI_INFO.Common;
using FFXI_INFO.Common.Types;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace FFXI_INFO
{
    class Program
    {
        public static UtilsConsole Utils = new UtilsConsole();
        public static getRomPath Rom = new getRomPath();
        public static knownFiles knownFiles = new knownFiles(Rom);
        public static ZoneListDat ZoneList = new ZoneListDat(Rom);
        public static DialogueDats DD = new DialogueDats();
        public static EntityDats Ent = new EntityDats();
        public static ZoneRelatedInfo ZoneInfo = new ZoneRelatedInfo(Rom, ZoneList);
        public static AnimationDats Animation = new AnimationDats(Rom);
        //  public static EventDats EV = new EventDats();
        static void Main(string[] args)
        {
            var zoneModelRelatedStuff = new (int ID, string TypeName)[]
{
                (1, "BUMP_MAP "),
                (2, "ZONEMODEL"),
                (3, "DIALOG   "),
                (4, "ENTITIES "),
                (5, "EVENTS   "),
                (6, "Shadows  ")
};
            try
            {
                if (!Utils.Confirm("Is your installation directory for FFXI: {C:\\Program Files (x86)\\PlayOnline\\SquareEnix\\FINAL FANTASY XI\\}."))
                {
                    Rom.installPath = Utils.GetAnswer("Please update your installation directory (Press enter when you are done).");
                }
                if (Utils.Confirm("Would you like to try and find all the Animation dats and create json files for each Race"))
                {

                    Console.WriteLine($@"This will take a while!");
                    Animation.ParseTheDats();
                }
                if (Utils.Confirm("Would you like to get the Rom paths for known files, e.g slipEnglish, abilEnglish,etc.."))
                {
                    knownFiles.getFilePathForKnownFiles();
                }
                if (Utils.Confirm("Would you like to parse the English zone list.dat, and save to json  << needed when parsing other dats."))
                {
                    ParseZoneList();
                }
                if (Utils.Confirm("Would you like to build a json file for each dialogue dat for zones?."))
                {
                    Console.Write("Dumping Dialogue dats." + Environment.NewLine);
                    for (int i = 0; i < 299; i++)
                    {
                        DialogueInfo(i, i);
                    }
                    for (int i = 1000; i < 1299; i++)
                    {
                        DialogueInfo(i, i);
                    }
                    Console.Write("Finished dumping dialogue dats" + Environment.NewLine);
                }
                if (Utils.Confirm("Would you like to build a json file for each Entity dat for zones?."))
                {
                    Console.Write("Dumping Entity dats." + Environment.NewLine);
                    for (int i = 0; i < 299; i++)
                    {
                        EntityInfo(i, i);
                    }
                    for (int i = 1000; i < 1299; i++)
                    {
                        EntityInfo(i, i);
                    }
                    Console.Write("Finished dumping Entity dats" + Environment.NewLine);
                }
                if (Utils.Confirm("Would you like to build a json file with all zone related info."))
                {
                    GetZoneRelatedInfo();
                }
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("enter zoneId to look up  zone related info.>> ");
                    int id;
                    try
                    {
                        id = int.Parse(Console.ReadLine() ?? string.Empty);
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Need to enter numbers!." + Environment.NewLine);
                        id = -1;
                    }
                    if (id == -1) continue;
                    {
                        foreach (var (value, _) in zoneModelRelatedStuff)
                        {
                            int fileId;
                            switch (value)
                            {
                                case 1:
                                    BumpMapInfo(id);
                                    break;

                                case 2:
                                    ZoneModelInfo(id);
                                    break;

                                case 3:
                                    DialogueInfo(id, id);
                                    break;

                                case 4:
                                    EntityInfo(id, id);
                                    break;

                                case 5:
                                    EventInfo(id);
                                    break;
                                case 6:
                                    ShadowInfo(id);
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        private static void GetZoneRelatedInfo()
        {
            ZoneInfo.start();
        }

        private static void EventInfo(int id)
        {
            if (id < 2000)
            {
                if (id < 1000)
                {
                   var fileId = id < 256 ? id + 5820 : id + 84735;
                    if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}"))
                    {
                        Print($@"{id} EVENTS ", Rom.GetRomPath(fileId, Rom.tableDirectory));
                   //     EV.ParseDat($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}", id, GetZoneName(id), Ent, DD);
                    }
                }
                else
                {
                  var  fileId = id + 56881;
                    if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}"))
                    {
                        Print($@"{id} EVENTS ", Rom.GetRomPath(fileId, Rom.tableDirectory));
                       // EV.ParseDat($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}", id, GetZoneName(id), Ent, DD);
                    }

                }
            }
            else
            {
              var  fileId = id + 65611;
                if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}"))
                {
                    Print($@"{id} EVENTS ", Rom.GetRomPath(fileId, Rom.tableDirectory));
                }
            }
        }
        //FFXI allows for a single zone to have multiple Entity dats & Dialogue dats  depending on the zones 'instance' being loaded/used. Internally,
        //the client has a shift for the id based on the zone id and a sub-zone id which is sent in the 0x00A zone enter packet.
        //Packet: Zone Enter (0x000A)
        //+0x30 = zone id
        //+0x9E = zone sub id
        //zones 1000 to 1026 return dats related to Dungeons
        //in this case we are just setting subid to id for testing.
        private static void EntityInfo(int id, int subid)
        {
            if (id < 1000 || id > 1299)
            {
               var fileId = id < 256 ? id + 6720 : id + 86235;

                if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}"))
                {
                    Print($@"{id} ENTITIES ", Rom.GetRomPath(fileId, Rom.tableDirectory));
                    var data = File.ReadAllBytes($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}").AsSpan();
                    Ent.ParseDat(data, id, GetZoneName(id));
                }
            }
            else
            {
             var   fileId = id + 66911;
                if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}"))
                {
                    Print($@"{id} ENTITIES ", Rom.GetRomPath(fileId, Rom.tableDirectory));
                    var data = File.ReadAllBytes($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}").AsSpan();
                    Ent.ParseDat(data, id, GetZoneName(id));
                }
            }
        }

        //FFXI allows for a single zone to have multiple Entity dats & Dialogue dats  depending on the zones 'instance' being loaded/used. Internally,
        //the client has a shift for the id based on the zone id and a sub-zone id which is sent in the 0x00A zone enter packet.
        //Packet: Zone Enter (0x000A)
        //+0x30 = zone id
        //+0x9E = zone sub id
        //zones 1000 to 1026 return dats related to Dungeons
        //in this case we are just setting subid to id for testing.
        private static void DialogueInfo(int id,int subid)
        {
            var fileId = 0;
            if (subid < 1000 || subid > 1299)
            {
                fileId = id < 256 ? id + KeyTables.GetDatFileIdOffset(105) : KeyTables.GetDatFileIdOffset(108) +id - 256;

                if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}"))
                {
                    Print($@"{id} DIALOGUE", Rom.GetRomPath(fileId, Rom.tableDirectory));
                    DD.ParseDialogueDat($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}", id, GetZoneName(id));
                }
            }
            else
            {
                fileId = KeyTables.GetDatFileIdOffset(107) + subid - 1000;

                if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}"))
                {
                    Print($@"{id} DIALOGUE", Rom.GetRomPath(fileId, Rom.tableDirectory));
                    DD.ParseDialogueDat($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}", id, GetZoneName(id));
                }
            }
        }
        private static void ShadowInfo(int id)
        {
            var fileId = 7052;
            if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}"))
            {
                Print($@"{id} SHADOW?", Rom.GetRomPath(fileId, Rom.tableDirectory));
            }
        }
        private static void BumpMapInfo(int id)
        {
           var fileId = id < 256 ? id + 39831 : id + 84435;
            if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}"))
            {
                Print($@"{id} BUMP MAP", Rom.GetRomPath(fileId, Rom.tableDirectory));
            }
        }
        private static void ZoneModelInfo(int id)
        {
            var fileId = id < 256 ? id + 100 : id + 83635;
            if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(fileId, Rom.tableDirectory)}"))
            {
                Print($@"{id} ZONE MODEL", Rom.GetRomPath(fileId, Rom.tableDirectory));
            }
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("zone name not found");
                Console.ForegroundColor = ConsoleColor.White;
                return $@"{id}";
            }
            return $@"{id}";
        }
        public static void ParseZoneList()
        {
            Console.Write($@"Parsing Zone_List.dat" + Environment.NewLine);
            var data = File.ReadAllBytes($@"{Rom.installPath}{Rom.GetRomPath(KeyTables.GetDatFileIdOffset(16), Rom.tableDirectory)}").AsSpan();
            ZoneList.ParseZoneList(data);
            if (ZoneList._zones.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($@"Unable to Parse zonelist.dat" + Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (ZoneList._zones.Count > 0)
            {
                foreach (var datFile in ZoneList._zones)
                {
                    Print($@"{datFile.id} {datFile.name}", datFile.path);

                }
            }
        }
        public static void Print(string a, string b)
        {
            char pad = ' ';
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(a.PadRight(40, pad));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(b.PadRight(24, pad));
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
