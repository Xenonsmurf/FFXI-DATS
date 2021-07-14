using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FFXI_INFO.Common
{
    public class EquipmentDats
    {
    
        public List<string> ElvaanFemale_Ammo_eq_DAT = new List<string>();
        public List<string> ElvaanFemale_Body_eq_DAT = new List<string>();
        public List<string> ElvaanFemale_Feet_eq_DAT = new List<string>();
        public List<string> ElvaanFemale_Hands_eq_DAT = new List<string>();
        public List<string> ElvaanFemale_Head_eq_DAT = new List<string>();
        public List<string> ElvaanFemale_Legs_eq_DAT = new List<string>();
        public List<string> ElvaanFemale_Main_eq_DAT = new List<string>();
        public List<string> ElvaanFemale_Range_eq_DAT = new List<string>();
        public List<string> ElvaanFemale_Sub_eq_DAT = new List<string>();
        public List<string> ElvaanMale_Ammo_eq_DAT = new List<string>();
        public List<string> ElvaanMale_Body_eq_DAT = new List<string>();
        public List<string> ElvaanMale_Feet_eq_DAT = new List<string>();
        public List<string> ElvaanMale_Hands_eq_DAT = new List<string>();
        public List<string> ElvaanMale_Head_eq_DAT = new List<string>();
        public List<string> ElvaanMale_Legs_eq_DAT = new List<string>();
        public List<string> ElvaanMale_Main_eq_DAT = new List<string>();
        public List<string> ElvaanMale_Range_eq_DAT = new List<string>();
        public List<string> ElvaanMale_Sub_eq_DAT = new List<string>();
        public List<string> Galka_Ammo_eq_DAT = new List<string>();
        public List<string> Galka_Body_eq_DAT = new List<string>();
        public List<string> Galka_Feet_eq_DAT = new List<string>();
        public List<string> Galka_Hands_eq_DAT = new List<string>();
        public List<string> Galka_Head_eq_DAT = new List<string>();
        public List<string> Galka_Legs_eq_DAT = new List<string>();
        public List<string> Galka_Main_eq_DAT = new List<string>();
        public List<string> Galka_Range_eq_DAT = new List<string>();
        public List<string> Galka_Sub_eq_DAT = new List<string>();
        public List<string> HumeFemale_Ammo_eq_DAT = new List<string>();
        public List<string> HumeFemale_Body_eq_DAT = new List<string>();
        public List<string> HumeFemale_Feet_eq_DAT = new List<string>();
        public List<string> HumeFemale_Hands_eq_DAT = new List<string>();
        public List<string> HumeFemale_Head_eq_DAT = new List<string>();
        public List<string> HumeFemale_Legs_eq_DAT = new List<string>();
        public List<string> HumeFemale_Main_eq_DAT = new List<string>();
        public List<string> HumeFemale_Range_eq_DAT = new List<string>();
        public List<string> HumeFemale_Sub_eq_DAT = new List<string>();
        public List<string> HumeMale_Ammo_eq_DAT = new List<string>();
        public List<string> HumeMale_Body_eq_DAT = new List<string>();
        public List<string> HumeMale_Feet_eq_DAT = new List<string>();
        public List<string> HumeMale_Hands_eq_DAT = new List<string>();
        public List<string> HumeMale_Head_eq_DAT = new List<string>();
        public List<string> HumeMale_Legs_eq_DAT = new List<string>();
        public List<string> HumeMale_Main_eq_DAT = new List<string>();
        public List<string> HumeMale_Range_eq_DAT = new List<string>();
        public List<string> HumeMale_Sub_eq_DAT = new List<string>();
        public List<string> Mithra_Ammo_eq_DAT = new List<string>();
        public List<string> Mithra_Body_eq_DAT = new List<string>();
        public List<string> Mithra_Feet_eq_DAT = new List<string>();
        public List<string> Mithra_Hands_eq_DAT = new List<string>();
        public List<string> Mithra_Head_eq_DAT = new List<string>();
        public List<string> Mithra_Legs_eq_DAT = new List<string>();
        public List<string> Mithra_Main_eq_DAT = new List<string>();
        public List<string> Mithra_Range_eq_DAT = new List<string>();
        public List<string> Mithra_Sub_eq_DAT = new List<string>();
        public List<string> Taru_Ammo_eq_DAT = new List<string>();
        public List<string> Taru_Body_eq_DAT = new List<string>();
        public List<string> Taru_Feet_eq_DAT = new List<string>();
        public List<string> Taru_Hands_eq_DAT = new List<string>();
        public List<string> Taru_Head_eq_DAT = new List<string>();
        public List<string> Taru_Legs_eq_DAT = new List<string>();
        public List<string> Taru_Main_eq_DAT = new List<string>();
        public List<string> Taru_Range_eq_DAT = new List<string>();
        public List<string> Taru_Sub_eq_DAT = new List<string>();



        public EquipmentDats(getRomPath rp)
        {
            Rom = rp;
        }


        public getRomPath Rom { get; set; }

        public static void Print(string a, string b)
        {
            char pad = ' ';
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(a.PadRight(40, pad));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(b.PadRight(24, pad));
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ParseTheDats()
        {
            DirectoryInfo directory = new DirectoryInfo(Rom.installPath);
            FileInfo[] files = directory.GetFiles("*.DAT", SearchOption.AllDirectories);
            var query = from file in files
                        where ((file.Length > 4) && (file.FullName.Contains("ROM")))
                        select file.FullName;

            foreach (string filename in query)
            {
                var data = File.ReadAllBytes(filename).AsSpan();
                var eqType = Encoding.ASCII.GetString(data.Slice(0, 4));
                var wpType = Encoding.ASCII.GetString(data.Slice(1, 3));

                switch (eqType)
                {
                    case "1ef_":
                        ElvaanFemale_Head_eq_DAT.Add(filename);
                        break;

                    case "1em_":
                        ElvaanMale_Head_eq_DAT.Add(filename);
                        break;

                    case "1gl_":
                        Galka_Head_eq_DAT.Add(filename);
                        break;

                    case "1hm_":
                        HumeMale_Head_eq_DAT.Add(filename);
                        break;

                    case "1hf_":
                        HumeFemale_Head_eq_DAT.Add(filename);
                        break;

                    case "1mt_":
                        Mithra_Head_eq_DAT.Add(filename);
                        break;

                    case "1tr_":
                        Taru_Head_eq_DAT.Add(filename);
                        break;

                    case "0ef_":
                        ElvaanFemale_Body_eq_DAT.Add(filename);
                        break;

                    case "0em_":
                        ElvaanMale_Body_eq_DAT.Add(filename);
                        break;

                    case "0gl_":
                        Galka_Body_eq_DAT.Add(filename);
                        break;

                    case "0hm_":
                        HumeMale_Body_eq_DAT.Add(filename);
                        break;

                    case "0hf_":
                        HumeFemale_Body_eq_DAT.Add(filename);
                        break;

                    case "0mt_":
                        Mithra_Body_eq_DAT.Add(filename);
                        break;

                    case "0tr_":
                        Taru_Body_eq_DAT.Add(filename);
                        break;

                    case "2ef_":
                        ElvaanFemale_Hands_eq_DAT.Add(filename);
                        break;

                    case "2em_":
                        ElvaanMale_Hands_eq_DAT.Add(filename);
                        break;

                    case "2gl_":
                        Galka_Hands_eq_DAT.Add(filename);
                        break;

                    case "2hm_":
                        HumeMale_Hands_eq_DAT.Add(filename);
                        break;

                    case "2hf_":
                        HumeFemale_Hands_eq_DAT.Add(filename);
                        break;

                    case "2mt_":
                        Mithra_Hands_eq_DAT.Add(filename);
                        break;

                    case "2tr_":
                        Taru_Hands_eq_DAT.Add(filename);
                        break;

                    case "3ef_":
                        ElvaanFemale_Legs_eq_DAT.Add(filename);
                        break;

                    case "3em_":
                        ElvaanMale_Legs_eq_DAT.Add(filename);
                        break;

                    case "3gl_":
                        Galka_Legs_eq_DAT.Add(filename);
                        break;

                    case "3hm_":
                        HumeMale_Legs_eq_DAT.Add(filename);
                        break;

                    case "3hf_":
                        HumeFemale_Legs_eq_DAT.Add(filename);
                        break;

                    case "3mt_":
                        Mithra_Legs_eq_DAT.Add(filename);
                        break;

                    case "3tr_":
                        Taru_Legs_eq_DAT.Add(filename);
                        break;

                    case "4ef_":
                        ElvaanFemale_Feet_eq_DAT.Add(filename);
                        break;

                    case "4em_":
                        ElvaanMale_Feet_eq_DAT.Add(filename);
                        break;

                    case "4gl_":
                        Galka_Feet_eq_DAT.Add(filename);
                        break;

                    case "4hm_":
                        HumeMale_Feet_eq_DAT.Add(filename);
                        break;

                    case "4hf_":
                        HumeFemale_Feet_eq_DAT.Add(filename);
                        break;

                    case "4mt_":
                        Mithra_Feet_eq_DAT.Add(filename);
                        break;

                    case "4tr_":
                        Taru_Feet_eq_DAT.Add(filename);
                        break;

                }

                switch (wpType)
                {
                    //main
                    case "0ef":
                        ElvaanFemale_Main_eq_DAT.Add(filename);
                        break;

                    case "0em":
                        ElvaanMale_Main_eq_DAT.Add(filename);
                        break;

                    case "0gl":
                        Galka_Main_eq_DAT.Add(filename);
                        break;

                    case "0hm":
                        HumeMale_Main_eq_DAT.Add(filename);
                        break;

                    case "0hf":
                        HumeFemale_Main_eq_DAT.Add(filename);
                        break;

                    case "0mt":
                        Mithra_Main_eq_DAT.Add(filename);
                        break;

                    case "0tr":
                        Taru_Main_eq_DAT.Add(filename);
                        break;

                    //sub
                    case "1ef":
                        ElvaanFemale_Sub_eq_DAT.Add(filename);
                        break;

                    case "1em":
                        ElvaanMale_Sub_eq_DAT.Add(filename);
                        break;

                    case "1gl":
                        Galka_Sub_eq_DAT.Add(filename);
                        break;

                    case "1hm":
                        HumeMale_Sub_eq_DAT.Add(filename);
                        break;

                    case "1hf":
                        HumeFemale_Sub_eq_DAT.Add(filename);
                        break;

                    case "1mt":
                        Mithra_Sub_eq_DAT.Add(filename);
                        break;

                    case "1tr":
                        Taru_Sub_eq_DAT.Add(filename);
                        break;

                    //ranged
                    case "2ef":
                        ElvaanFemale_Range_eq_DAT.Add(filename);
                        break;

                    case "2em":
                        ElvaanMale_Range_eq_DAT.Add(filename);
                        break;

                    case "2gl":
                        Galka_Range_eq_DAT.Add(filename);
                        break;

                    case "2hm":
                        HumeMale_Range_eq_DAT.Add(filename);
                        break;

                    case "2hf":
                        HumeFemale_Range_eq_DAT.Add(filename);
                        break;

                    case "2mt":
                        Mithra_Range_eq_DAT.Add(filename);
                        break;

                    case "2tr":
                        Taru_Range_eq_DAT.Add(filename);
                        break;

                 
                }

            }
            Dump();
        }
        public List<string> eqTypes = new List<string>
        {
          "ElvaanFemale_Ammo_eq_DAT",
          "ElvaanFemale_Body_eq_DAT",
          "ElvaanFemale_Feet_eq_DAT",
          "ElvaanFemale_Hands_eq_DAT",
          "ElvaanFemale_Head_eq_DAT",
          "ElvaanFemale_Legs_eq_DAT",
          "ElvaanFemale_Main_eq_DAT",
          "ElvaanFemale_Range_eq_DAT",
          "ElvaanFemale_Sub_eq_DAT",
          "ElvaanMale_Ammo_eq_DAT",
          "ElvaanMale_Body_eq_DAT",
          "ElvaanMale_Feet_eq_DAT",
          "ElvaanMale_Hands_eq_DAT",
          "ElvaanMale_Head_eq_DAT",
          "ElvaanMale_Legs_eq_DAT",
          "ElvaanMale_Main_eq_DAT",
          "ElvaanMale_Range_eq_DAT",
          "ElvaanMale_Sub_eq_DAT",
          "Galka_Ammo_eq_DAT",
          "Galka_Body_eq_DAT",
          "Galka_Feet_eq_DAT",
          "Galka_Hands_eq_DAT",
          "Galka_Head_eq_DAT",
          "Galka_Legs_eq_DAT",
          "Galka_Main_eq_DAT",
          "Galka_Range_eq_DAT",
          "Galka_Sub_eq_DAT",
          "HumeFemale_Ammo_eq_DAT",
          "HumeFemale_Body_eq_DAT",
          "HumeFemale_Feet_eq_DAT",
          "HumeFemale_Hands_eq_DAT",
          "HumeFemale_Head_eq_DAT",
          "HumeFemale_Legs_eq_DAT",
          "HumeFemale_Main_eq_DAT",
          "HumeFemale_Range_eq_DAT",
          "HumeFemale_Sub_eq_DAT",
          "HumeMale_Ammo_eq_DAT",
          "HumeMale_Body_eq_DAT",
          "HumeMale_Feet_eq_DAT",
          "HumeMale_Hands_eq_DAT",
          "HumeMale_Head_eq_DAT",
          "HumeMale_Legs_eq_DAT",
          "HumeMale_Main_eq_DAT",
          "HumeMale_Range_eq_DAT",
          "HumeMale_Sub_eq_DAT",
          "Mithra_Ammo_eq_DAT",
          "Mithra_Body_eq_DAT",
          "Mithra_Feet_eq_DAT",
          "Mithra_Hands_eq_DAT",
          "Mithra_Head_eq_DAT",
          "Mithra_Legs_eq_DAT",
          "Mithra_Main_eq_DAT",
          "Mithra_Range_eq_DAT",
          "Mithra_Sub_eq_DAT",
          "Taru_Ammo_eq_DAT",
          "Taru_Body_eq_DAT",
          "Taru_Feet_eq_DAT",
          "Taru_Hands_eq_DAT",
          "Taru_Head_eq_DAT",
          "Taru_Legs_eq_DAT",
          "Taru_Main_eq_DAT",
          "Taru_Range_eq_DAT",
          "Taru_Sub_eq_DAT",
        };
        public void Dump()
        {
            try
            {
                foreach (var type in eqTypes)
                {
                    switch (type)
                    {
                        case"ElvaanFemale_Ammo_eq_DAT":
                            dumpToJson(type, ElvaanFemale_Ammo_eq_DAT);
                            break;
                        case"ElvaanFemale_Body_eq_DAT":
                            dumpToJson(type, ElvaanFemale_Body_eq_DAT);
                            break;
                        case "ElvaanFemale_Feet_eq_DAT":
                            dumpToJson(type, ElvaanFemale_Feet_eq_DAT);
                            break;
                        case "ElvaanFemale_Hands_eq_DAT":
                            dumpToJson(type, ElvaanFemale_Hands_eq_DAT);
                            break;
                        case "ElvaanFemale_Head_eq_DAT":
                            dumpToJson(type, ElvaanFemale_Head_eq_DAT);
                            break;
                        case "ElvaanFemale_Legs_eq_DAT":
                            dumpToJson(type, ElvaanFemale_Legs_eq_DAT);
                            break;
                        case "ElvaanFemale_Main_eq_DAT":
                            dumpToJson(type, ElvaanFemale_Main_eq_DAT);
                            break;
                        case "ElvaanFemale_Range_eq_DAT":
                            dumpToJson(type, ElvaanFemale_Range_eq_DAT);
                            break;
                        case "ElvaanFemale_Sub_eq_DAT":
                            dumpToJson(type, ElvaanFemale_Sub_eq_DAT);
                            break;

                        case "ElvaanMale_Ammo_eq_DAT":
                            dumpToJson(type, ElvaanMale_Ammo_eq_DAT);
                            break;
                        case "ElvaanMale_Body_eq_DAT":
                            dumpToJson(type, ElvaanMale_Body_eq_DAT);
                            break;
                        case "ElvaanMale_Feet_eq_DAT":
                            dumpToJson(type, ElvaanMale_Feet_eq_DAT);
                            break;
                        case "ElvaanMale_Hands_eq_DAT":
                            dumpToJson(type, ElvaanMale_Hands_eq_DAT);
                            break;
                        case "ElvaanMale_Head_eq_DAT":
                            dumpToJson(type, ElvaanMale_Head_eq_DAT);
                            break;
                        case "ElvaanMale_Legs_eq_DAT":
                            dumpToJson(type, ElvaanMale_Legs_eq_DAT);
                            break;
                        case "ElvaanMale_Main_eq_DAT":
                            dumpToJson(type, ElvaanMale_Main_eq_DAT);
                            break;
                        case "ElvaanMale_Range_eq_DAT":
                            dumpToJson(type, ElvaanMale_Range_eq_DAT);
                            break;
                        case "ElvaanMale_Sub_eq_DAT":
                            dumpToJson(type, ElvaanMale_Sub_eq_DAT);
                            break;
                        case "HumeFemale_Ammo_eq_DAT":
                            dumpToJson(type, HumeFemale_Ammo_eq_DAT);
                            break;
                        case "HumeFemale_Body_eq_DAT":
                            dumpToJson(type, HumeFemale_Body_eq_DAT);
                            break;
                        case "HumeFemale_Feet_eq_DAT":
                            dumpToJson(type, HumeFemale_Feet_eq_DAT);
                            break;
                        case "HumeFemale_Hands_eq_DAT":
                            dumpToJson(type, HumeFemale_Hands_eq_DAT);
                            break;
                        case "HumeFemale_Head_eq_DAT":
                            dumpToJson(type, HumeFemale_Head_eq_DAT);
                            break;
                        case "HumeFemale_Legs_eq_DAT":
                            dumpToJson(type, HumeFemale_Legs_eq_DAT);
                            break;
                        case "HumeFemale_Main_eq_DAT":
                            dumpToJson(type, HumeFemale_Main_eq_DAT);
                            break;
                        case "HumeFemale_Range_eq_DAT":
                            dumpToJson(type, HumeFemale_Range_eq_DAT);
                            break;
                        case "HumeFemale_Sub_eq_DAT":
                            dumpToJson(type, HumeFemale_Sub_eq_DAT);
                            break;
                        case "HumeMale_Ammo_eq_DAT":
                            dumpToJson(type, HumeMale_Ammo_eq_DAT);
                            break;
                        case "HumeMale_Body_eq_DAT":
                            dumpToJson(type, HumeMale_Body_eq_DAT);
                            break;
                        case "HumeMale_Feet_eq_DAT":
                            dumpToJson(type, HumeMale_Feet_eq_DAT);
                            break;
                        case "HumeMale_Hands_eq_DAT":
                            dumpToJson(type, HumeMale_Hands_eq_DAT);
                            break;
                        case "HumeMale_Head_eq_DAT":
                            dumpToJson(type, HumeMale_Head_eq_DAT);
                            break;
                        case "HumeMale_Legs_eq_DAT":
                            dumpToJson(type, HumeMale_Legs_eq_DAT);
                            break;
                        case "HumeMale_Main_eq_DAT":
                            dumpToJson(type, HumeMale_Main_eq_DAT);
                            break;
                        case "HumeMale_Range_eq_DAT":
                            dumpToJson(type, HumeMale_Range_eq_DAT);
                            break;
                        case "HumeMale_Sub_eq_DAT":
                            dumpToJson(type, HumeMale_Sub_eq_DAT);
                            break;
                        case "Galka_Ammo_eq_DAT":
                            dumpToJson(type, Galka_Ammo_eq_DAT);
                            break;
                        case "Galka_Body_eq_DAT":
                            dumpToJson(type, Galka_Body_eq_DAT);
                            break;
                        case "Galka_Feet_eq_DAT":
                            dumpToJson(type, Galka_Feet_eq_DAT);
                            break;
                        case "Galka_Hands_eq_DAT":
                            dumpToJson(type, Galka_Hands_eq_DAT);
                            break;
                        case "Galka_Head_eq_DAT":
                            dumpToJson(type, Galka_Head_eq_DAT);
                            break;
                        case "Galka_Legs_eq_DAT":
                            dumpToJson(type, Galka_Legs_eq_DAT);
                            break;
                        case "Galka_Main_eq_DAT":
                            dumpToJson(type, Galka_Main_eq_DAT);
                            break;
                        case "Galka_Range_eq_DAT":
                            dumpToJson(type, Galka_Range_eq_DAT);
                            break;
                        case "Galka_Sub_eq_DAT":
                            dumpToJson(type, Galka_Sub_eq_DAT);
                            break;
                        case "Mithra_Ammo_eq_DAT":
                            dumpToJson(type, Mithra_Ammo_eq_DAT);
                            break;
                        case "Mithra_Body_eq_DAT":
                            dumpToJson(type, Mithra_Body_eq_DAT);
                            break;
                        case "Mithra_Feet_eq_DAT":
                            dumpToJson(type, Mithra_Feet_eq_DAT);
                            break;
                        case "Mithra_Hands_eq_DAT":
                            dumpToJson(type, Mithra_Hands_eq_DAT);
                            break;
                        case "Mithra_Head_eq_DAT":
                            dumpToJson(type, Mithra_Head_eq_DAT);
                            break;
                        case "Mithra_Legs_eq_DAT":
                            dumpToJson(type, Mithra_Legs_eq_DAT);
                            break;
                        case "Mithra_Main_eq_DAT":
                            dumpToJson(type, Mithra_Main_eq_DAT);
                            break;
                        case "Mithra_Range_eq_DAT":
                            dumpToJson(type, Mithra_Range_eq_DAT);
                            break;
                        case "Mithra_Sub_eq_DAT":
                            dumpToJson(type, Mithra_Sub_eq_DAT);
                            break;

                        case "Taru_Ammo_eq_DAT":
                            dumpToJson(type, Taru_Ammo_eq_DAT);
                            break;
                        case "Taru_Body_eq_DAT":
                            dumpToJson(type, Taru_Body_eq_DAT);
                            break;
                        case "Taru_Feet_eq_DAT":
                            dumpToJson(type, Taru_Feet_eq_DAT);
                            break;
                        case "Taru_Hands_eq_DAT":
                            dumpToJson(type, Taru_Hands_eq_DAT);
                            break;
                        case "Taru_Head_eq_DAT":
                            dumpToJson(type, Taru_Head_eq_DAT);
                            break;
                        case "Taru_Legs_eq_DAT":
                            dumpToJson(type, Taru_Legs_eq_DAT);
                            break;
                        case "Taru_Main_eq_DAT":
                            dumpToJson(type, Taru_Main_eq_DAT);
                            break;
                        case "Taru_Range_eq_DAT":
                            dumpToJson(type, Taru_Range_eq_DAT);
                            break;
                        case "Taru_Sub_eq_DAT":
                            dumpToJson(type, Taru_Sub_eq_DAT);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
            }
        }
        public void dumpToJson(string str, List<string> type)
        {
            try
            {
                //un comment this if you need file ids
                //AnimationDat.Clear();

                //foreach (var item in type)
                //{
                //    for (int i = 0; i < int.MaxValue; i++)
                //    {
                //        if (AnimationDat.Count() >= type.Count())
                //        {
                //            break;
                //        }
                //        string datPath = $@"{Rom.installPath}{Rom.GetRomPath(i, Rom.tableDirectory)}";
                //         if (datPath == item)
                //        {
                //            AnimationDat.Add(new _Animations { FileID = i, Path = datPath });
                //            break;
                //        }
                //    }

                //}
                var path = ($@"{AppDomain.CurrentDomain.BaseDirectory}Equipment");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (!Directory.Exists(path)) return;
                var outFile = File.Create($@"{path}\\{str}.json");
                outFile.Close();
                //string JSONresult = JsonConvert.SerializeObject(AnimationDat);
                string JSONresult = JsonConvert.SerializeObject(type);
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