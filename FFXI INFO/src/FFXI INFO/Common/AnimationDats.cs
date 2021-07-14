using FFXI_INFO.Common.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FFXI_INFO.Common
{
    public class AnimationDats
    {
        #region Public Fields

        public List<_Animations> AnimationDat = new List<_Animations>();

        public List<string> AnimationTypes = new List<string>
        {
            "ElvaanFemale_Ability_Animations",
            "ElvaanFemale_Archery_Animations",
            "ElvaanFemale_Battle_Animations",
            "ElvaanFemale_General_Animations",
            "ElvaanFemale_Mannequin_Animations",
            "ElvaanFemale_Runfencer_wards_Animations",
            "ElvaanFemale_WS_Animations",

            "ElvaanMale_Ability_Animations",
            "ElvaanMale_Archery_Animations",
            "ElvaanMale_Battle_Animations",
            "ElvaanMale_General_Animations",
            "ElvaanMale_Mannequin_Animations",
            "ElvaanMale_Runfencer_wards_Animations",
            "ElvaanMale_WS_Animations",

            "HumeFemale_Ability_Animations",
            "HumeFemale_Archery_Animations",
            "HumeFemale_Battle_Animations",
            "HumeFemale_General_Animations",
            "HumeFemale_Mannequin_Animations",
            "HumeFemale_Runfencer_wards_Animations",
            "HumeFemale_WS_Animations",

            "HumeMale_Ability_Animations",
            "HumeMale_Archery_Animations",
            "HumeMale_Battle_Animations",
            "HumeMale_General_Animations",
            "HumeMale_Mannequin_Animations",
            "HumeMale_Runfencer_wards_Animations",
            "HumeMale_WS_Animations",

            "Galka_Ability_Animations",
            "Galka_Archery_Animations",
            "Galka_Battle_Animations",
            "Galka_General_Animations",
            "Galka_Mannequin_Animations",
            "Galka_Runfencer_wards_Animations",
            "Galka_WS_Animations",

            "Mithra_Ability_Animations",
            "Mithra_Archery_Animations",
            "Mithra_Battle_Animations",
            "Mithra_General_Animations",
            "Mithra_Mannequin_Animations",
            "Mithra_Runfencer_wards_Animations",
            "Mithra_WS_Animations",

            "Taru_Ability_Animations",
            "Taru_Archery_Animations",
            "Taru_Battle_Animations",
            "Taru_General_Animations",
            "Taru_Mannequin_Animations",
            "Taru_Runfencer_wards_Animations",
            "Taru_WS_Animations",
            "Dancer_Animations",
        };

        public List<string> Dancer_Animations = new List<string>();

        public List<string> ElvaanFemale_Ability_Animations = new List<string>();

        public List<string> ElvaanFemale_Archery_Animations = new List<string>();

        public List<string> ElvaanFemale_Battle_Animations = new List<string>();

        public List<string> ElvaanFemale_General_Animations = new List<string>();

        public List<string> ElvaanFemale_Mannequin_Animations = new List<string>();

        public List<string> ElvaanFemale_Runfencer_wards_Animations = new List<string>();

        public List<string> ElvaanFemale_WS_Animations = new List<string>();

        public List<string> ElvaanMale_Ability_Animations = new List<string>();

        public List<string> ElvaanMale_Archery_Animations = new List<string>();

        public List<string> ElvaanMale_Battle_Animations = new List<string>();

        public List<string> ElvaanMale_General_Animations = new List<string>();

        public List<string> ElvaanMale_Mannequin_Animations = new List<string>();

        public List<string> ElvaanMale_Runfencer_wards_Animations = new List<string>();

        public List<string> ElvaanMale_WS_Animations = new List<string>();

        public List<string> Galka_Ability_Animations = new List<string>();

        public List<string> Galka_Archery_Animations = new List<string>();

        public List<string> Galka_Battle_Animations = new List<string>();

        public List<string> Galka_General_Animations = new List<string>();

        public List<string> Galka_Mannequin_Animations = new List<string>();

        public List<string> Galka_Runfencer_wards_Animations = new List<string>();

        public List<string> Galka_WS_Animations = new List<string>();

        public List<string> HumeFemale_Ability_Animations = new List<string>();

        public List<string> HumeFemale_Archery_Animations = new List<string>();

        public List<string> HumeFemale_Battle_Animations = new List<string>();

        public List<string> HumeFemale_General_Animations = new List<string>();

        public List<string> HumeFemale_Mannequin_Animations = new List<string>();

        public List<string> HumeFemale_Runfencer_wards_Animations = new List<string>();

        public List<string> HumeFemale_WS_Animations = new List<string>();

        public List<string> HumeMale_Ability_Animations = new List<string>();

        public List<string> HumeMale_Archery_Animations = new List<string>();

        public List<string> HumeMale_Battle_Animations = new List<string>();

        public List<string> HumeMale_General_Animations = new List<string>();

        public List<string> HumeMale_Mannequin_Animations = new List<string>();

        public List<string> HumeMale_Runfencer_wards_Animations = new List<string>();

        public List<string> HumeMale_WS_Animations = new List<string>();

        public List<string> Mithra_Ability_Animations = new List<string>();

        public List<string> Mithra_Archery_Animations = new List<string>();

        public List<string> Mithra_Battle_Animations = new List<string>();

        public List<string> Mithra_General_Animations = new List<string>();

        public List<string> Mithra_Mannequin_Animations = new List<string>();

        public List<string> Mithra_Runfencer_wards_Animations = new List<string>();

        public List<string> Mithra_WS_Animations = new List<string>();

        public List<string> Taru_Ability_Animations = new List<string>();

        public List<string> Taru_Archery_Animations = new List<string>();

        public List<string> Taru_Battle_Animations = new List<string>();

        public List<string> Taru_General_Animations = new List<string>();

        public List<string> Taru_Mannequin_Animations = new List<string>();

        public List<string> Taru_Runfencer_wards_Animations = new List<string>();

        public List<string> Taru_WS_Animations = new List<string>();

        public List<string> Unknown_Animations = new List<string>();

        #endregion Public Fields

        #region Public Constructors

        public AnimationDats(getRomPath rp)
        {
            Rom = rp;
        }

        #endregion Public Constructors

        #region Public Properties

        public getRomPath Rom { get; set; }

        #endregion Public Properties

        #region Public Methods

        public static void Print(string a, string b)
        {
            char pad = ' ';
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(a.PadRight(40, pad));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(b.PadRight(24, pad));
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Dump()
        {
            try
            {
                foreach (var type in AnimationTypes)
                {
                    switch (type)
                    {
                        case "ElvaanFemale_Ability_Animations":
                            dumpToJson(type, ElvaanFemale_Ability_Animations);
                            break;

                        case "ElvaanFemale_Archery_Animations":
                            dumpToJson(type, ElvaanFemale_Archery_Animations);
                            break;

                        case "ElvaanFemale_Battle_Animations":
                            dumpToJson(type, ElvaanFemale_Battle_Animations);
                            break;

                        case "ElvaanFemale_General_Animations":
                            dumpToJson(type, ElvaanFemale_General_Animations);
                            break;

                        case "ElvaanFemale_Mannequin_Animations":
                            dumpToJson(type, ElvaanFemale_Mannequin_Animations);
                            break;

                        case "ElvaanFemale_Runfencer_wards_Animations":
                            dumpToJson(type, ElvaanFemale_Runfencer_wards_Animations);
                            break;

                        case "ElvaanFemale_WS_Animations":
                            dumpToJson(type, ElvaanFemale_WS_Animations);
                            break;

                        case "ElvaanMale_Ability_Animations":
                            dumpToJson(type, ElvaanMale_Ability_Animations);
                            break;

                        case "ElvaanMale_Archery_Animations":
                            dumpToJson(type, ElvaanMale_Archery_Animations);
                            break;

                        case "ElvaanMale_Battle_Animations":
                            dumpToJson(type, ElvaanMale_Battle_Animations);
                            break;

                        case "ElvaanMale_General_Animations":
                            dumpToJson(type, ElvaanMale_General_Animations);
                            break;

                        case "ElvaanMale_Mannequin_Animations":
                            dumpToJson(type, ElvaanMale_Mannequin_Animations);
                            break;

                        case "ElvaanMale_Runfencer_wards_Animations":
                            dumpToJson(type, ElvaanMale_Runfencer_wards_Animations);
                            break;

                        case "ElvaanMale_WS_Animations":
                            dumpToJson(type, ElvaanMale_WS_Animations);
                            break;

                        case "HumeFemale_Ability_Animations":
                            dumpToJson(type, HumeFemale_Ability_Animations);
                            break;

                        case "HumeFemale_Archery_Animations":
                            dumpToJson(type, HumeFemale_Archery_Animations);
                            break;

                        case "HumeFemale_Battle_Animations":
                            dumpToJson(type, HumeFemale_Battle_Animations);
                            break;

                        case "HumeFemale_General_Animations":
                            dumpToJson(type, HumeFemale_General_Animations);
                            break;

                        case "HumeFemale_Mannequin_Animations":
                            dumpToJson(type, HumeFemale_Mannequin_Animations);
                            break;

                        case "HumeFemale_Runfencer_wards_Animations":
                            dumpToJson(type, HumeFemale_Runfencer_wards_Animations);
                            break;

                        case "HumeFemale_WS_Animations":
                            dumpToJson(type, HumeFemale_WS_Animations);
                            break;

                        case "HumeMale_Ability_Animations":
                            dumpToJson(type, HumeMale_Ability_Animations);
                            break;

                        case "HumeMale_Archery_Animations":
                            dumpToJson(type, HumeMale_Archery_Animations);
                            break;

                        case "HumeMale_Battle_Animations":
                            dumpToJson(type, HumeMale_Battle_Animations);
                            break;

                        case "HumeMale_General_Animations":
                            dumpToJson(type, HumeMale_General_Animations);
                            break;

                        case "HumeMale_Mannequin_Animations":
                            dumpToJson(type, HumeMale_Mannequin_Animations);
                            break;

                        case "HumeMale_Runfencer_wards_Animations":
                            dumpToJson(type, HumeMale_Runfencer_wards_Animations);
                            break;

                        case "HumeMale_WS_Animations":
                            dumpToJson(type, HumeMale_WS_Animations);
                            break;

                        case "Galka_Ability_Animations":
                            dumpToJson(type, Galka_Ability_Animations);
                            break;

                        case "Galka_Archery_Animations":
                            dumpToJson(type, Galka_Archery_Animations);
                            break;

                        case "Galka_Battle_Animations":
                            dumpToJson(type, Galka_Battle_Animations);
                            break;

                        case "Galka_General_Animations":
                            dumpToJson(type, Galka_General_Animations);
                            break;

                        case "Galka_Mannequin_Animations":
                            dumpToJson(type, Galka_Mannequin_Animations);
                            break;

                        case "Galka_Runfencer_wards_Animations":
                            dumpToJson(type, Galka_Runfencer_wards_Animations);
                            break;

                        case "Galka_WS_Animations":
                            dumpToJson(type, Galka_WS_Animations);
                            break;

                        case "Taru_Ability_Animations":
                            dumpToJson(type, Taru_Ability_Animations);
                            break;

                        case "Taru_Archery_Animations":
                            dumpToJson(type, Taru_Archery_Animations);
                            break;

                        case "Taru_Battle_Animations":
                            dumpToJson(type, Taru_Battle_Animations);
                            break;

                        case "Taru_General_Animations":
                            dumpToJson(type, Taru_General_Animations);
                            break;

                        case "Taru_Mannequin_Animations":
                            dumpToJson(type, Taru_Mannequin_Animations);
                            break;

                        case "Taru_Runfencer_wards_Animations":
                            dumpToJson(type, Taru_Runfencer_wards_Animations);
                            break;

                        case "Taru_WS_Animations":
                            dumpToJson(type, Taru_WS_Animations);
                            break;
                        case "Mithra_Ability_Animations":
                            dumpToJson(type, Mithra_Ability_Animations);
                            break;

                        case "Mithra_Archery_Animations":
                            dumpToJson(type, Mithra_Archery_Animations);
                            break;

                        case "Mithra_Battle_Animations":
                            dumpToJson(type, Mithra_Battle_Animations);
                            break;

                        case "Mithra_General_Animations":
                            dumpToJson(type, Mithra_General_Animations);
                            break;

                        case "Mithra_Mannequin_Animations":
                            dumpToJson(type, Mithra_Mannequin_Animations);
                            break;

                        case "Mithra_Runfencer_wards_Animations":
                            dumpToJson(type, Mithra_Runfencer_wards_Animations);
                            break;

                        case "Mithra_WS_Animations":
                            dumpToJson(type, Mithra_WS_Animations);
                            break;

                        case "Dancer_Animations":
                            dumpToJson(type, Dancer_Animations);
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
                var path = ($@"{AppDomain.CurrentDomain.BaseDirectory}{str}");
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

        public void ParseTheDats()
        {
            DirectoryInfo directory = new DirectoryInfo(Rom.installPath);
            FileInfo[] files = directory.GetFiles("*.DAT", SearchOption.AllDirectories);
            var query = from file in files
                        where ((file.Length > 36) && (file.FullName.Contains("ROM")))
                        select file.FullName;
            Int64 i = 0;
            foreach (string filename in query)
            {
                var data = File.ReadAllBytes(filename).AsSpan();
                var type = Encoding.ASCII.GetString(data.Slice(0, 4));
                var subtype = Encoding.ASCII.GetString(data.Slice(32, 4));
                switch (type)
                {
                    #region WS

                    case "ef_0":
                    case "ef_1":
                        ElvaanFemale_WS_Animations.Add(filename);
                        break;

                    case "em_0":
                    case "em_1":
                        ElvaanMale_WS_Animations.Add(filename);
                        break;

                    case "hm_0":
                    case "hm_1":
                        HumeMale_WS_Animations.Add(filename);
                        break;

                    case "hf_0":
                    case "hf_1":
                        HumeFemale_WS_Animations.Add(filename);
                        break;

                    case "gl_0":
                    case "gl_1":
                        Galka_WS_Animations.Add(filename);
                        break;

                    case "mt_0":
                    case "mt_1":
                        Mithra_WS_Animations.Add(filename);
                        break;

                    case "tr_0":
                    case "tr_1":
                        Taru_WS_Animations.Add(filename);
                        break;

                    #endregion WS

                    #region Archery

                    case "ef_y":
                    case "ef_g":
                        ElvaanFemale_Archery_Animations.Add(filename);
                        break;

                    case "em_y":
                    case "em_g":
                        ElvaanMale_Archery_Animations.Add(filename);
                        break;

                    case "hm_y":
                    case "hm_g":
                        HumeMale_Archery_Animations.Add(filename);
                        break;

                    case "hf_y":
                    case "hf_g":
                        HumeFemale_Archery_Animations.Add(filename);
                        break;

                    case "gl_y":
                    case "gl_g":
                        Galka_Archery_Animations.Add(filename);
                        break;

                    case "mt_y":
                    case "mt_g":
                        Mithra_Archery_Animations.Add(filename);
                        break;

                    case "tr_y":
                    case "tr_g":
                        Taru_Archery_Animations.Add(filename);
                        break;

                    #endregion Archery

                    #region Battle

                    case "ef_b":
                        ElvaanFemale_Battle_Animations.Add(filename);
                        break;

                    case "em_b":
                        ElvaanMale_Battle_Animations.Add(filename);
                        break;

                    case "gl_b":
                        Galka_Battle_Animations.Add(filename);
                        break;

                    case "hm_b":
                        HumeMale_Battle_Animations.Add(filename);
                        break;

                    case "hf_b":
                        HumeFemale_Battle_Animations.Add(filename);
                        break;

                    case "mt_b":
                        Mithra_Battle_Animations.Add(filename);
                        break;

                    case "tr_b":
                        Taru_Battle_Animations.Add(filename);
                        break;

                    #endregion Battle

                    #region General

                    case "ef_e":
                    case "ef_c":
                    case "ef_f":
                    case "ef_k":
                        ElvaanFemale_General_Animations.Add(filename);
                        break;

                    case "em_e":
                    case "em_c":
                    case "em_f":
                    case "em_k":
                        ElvaanMale_General_Animations.Add(filename);
                        break;

                    case "hm_e":
                    case "hm_c":
                    case "hm_f":
                    case "hm_k":
                        HumeMale_General_Animations.Add(filename);
                        break;

                    case "hf_e":
                    case "hf_c":
                    case "hf_f":
                    case "hf_k":
                        HumeFemale_General_Animations.Add(filename);
                        break;

                    case "gl_e":
                    case "gl_c":
                    case "gl_f":
                    case "gl_k":
                        Galka_General_Animations.Add(filename);
                        break;

                    case "mt_e":
                    case "mt_c":
                    case "mt_f":
                    case "mt_k":
                        Mithra_General_Animations.Add(filename);
                        break;

                    case "tr_e":
                    case "tr_c":
                    case "tr_f":
                    case "tr_k":
                        Taru_General_Animations.Add(filename);
                        break;

                    #endregion General

                    #region Ability

                    case "ef_s":
                    case "ef_2":
                    case "ef_h":
                    case "ef_j":
                    case "ef_t":
                        ElvaanFemale_Ability_Animations.Add(filename);
                        break;

                    case "em_s":
                    case "em_2":
                    case "em_h":
                    case "em_j":
                    case "em_t":
                        ElvaanMale_Ability_Animations.Add(filename);
                        break;

                    case "hm_s":
                    case "hm_2":
                    case "hm_h":
                    case "hm_j":
                    case "hm_t":
                        HumeMale_Ability_Animations.Add(filename);
                        break;

                    case "hf_s":
                    case "hf_2":
                    case "hf_h":
                    case "hf_j":
                    case "hf_t":
                        HumeFemale_Ability_Animations.Add(filename);
                        break;

                    case "gl_s":
                    case "gl_2":
                    case "gl_h":
                    case "gl_j":
                    case "gl_t":
                        Galka_Ability_Animations.Add(filename);
                        break;

                    case "mt_s":
                    case "mt_2":
                    case "mt_h":
                    case "mt_j":
                    case "mt_t":
                        Mithra_Ability_Animations.Add(filename);
                        break;

                    case "tr_s":
                    case "tr_2":
                    case "tr_h":
                    case "tr_j":
                    case "tr_t":
                        Taru_Ability_Animations.Add(filename);
                        break;

                    #endregion Ability

                    #region Runfencer & wards

                    case "em_r":
                        ElvaanMale_Runfencer_wards_Animations.Add(filename);
                        break;

                    case "ef_r":
                        ElvaanFemale_Runfencer_wards_Animations.Add(filename);
                        break;

                    case "hm_r":
                        HumeMale_Runfencer_wards_Animations.Add(filename);
                        break;

                    case "hf_r":
                        HumeFemale_Runfencer_wards_Animations.Add(filename);
                        break;

                    case "gl_r":
                        Galka_Runfencer_wards_Animations.Add(filename);
                        break;

                    case "mt_r":
                        Mithra_Runfencer_wards_Animations.Add(filename);
                        break;

                    case "tr_r":
                        Taru_Runfencer_wards_Animations.Add(filename);
                        break;

                    #endregion Runfencer & wards

                    #region Mannequin

                    case "em_m":
                        ElvaanMale_Mannequin_Animations.Add(filename);
                        break;

                    case "ef_m":
                        ElvaanFemale_Mannequin_Animations.Add(filename);
                        break;

                    case "hf_m":
                        HumeFemale_Mannequin_Animations.Add(filename);
                        break;

                    case "hm_m":
                        HumeMale_Mannequin_Animations.Add(filename);
                        break;

                    case "gl_m":
                        Galka_Mannequin_Animations.Add(filename);
                        break;

                    case "mt_m":
                        Mithra_Mannequin_Animations.Add(filename);
                        break;

                    case "tr_m":
                        Taru_Mannequin_Animations.Add(filename);
                        break;

                        #endregion Mannequin
                }
                if (type.Contains("dnc"))
                {
                    if (!Dancer_Animations.Contains(filename))
                    {
                        Dancer_Animations.Add(filename);
                    }
                }
                if (type.Contains("dc0"))
                {
                    if (!Dancer_Animations.Contains(filename))
                    {
                        Dancer_Animations.Add(filename);
                    }
                }
                if (type.Contains("art"))
                {
                    if (!Dancer_Animations.Contains(filename))
                    {
                        Dancer_Animations.Add(filename);
                    }
                }
                if (subtype.Contains("show"))
                {
                    if (!Dancer_Animations.Contains(filename))
                    {
                        Dancer_Animations.Add(filename);
                    }
                }
                if (type.Contains("ef_") && subtype.Contains("rwb"))
                {
                    if (!ElvaanFemale_Archery_Animations.Contains(filename))
                    {
                        ElvaanFemale_Archery_Animations.Add(filename);
                    }
                }
                if (type.Contains("em_") && subtype.Contains("rwb"))
                {
                    if (!ElvaanMale_Archery_Animations.Contains(filename))
                    {
                        ElvaanMale_Archery_Animations.Add(filename);
                    }
                }
                if (type.Contains("hm_") && subtype.Contains("rwb"))
                {
                    if (!HumeMale_Archery_Animations.Contains(filename))
                    {
                        HumeMale_Archery_Animations.Add(filename);
                    }
                }
                if (type.Contains("hf_") && subtype.Contains("rwb"))
                {
                    if (!HumeFemale_Archery_Animations.Contains(filename))
                    {
                        HumeFemale_Archery_Animations.Add(filename);
                    }
                }
                if (type.Contains("gl_") && subtype.Contains("rwb"))
                {
                    if (!Galka_Archery_Animations.Contains(filename))
                    {
                        Galka_Archery_Animations.Add(filename);
                    }
                }
                if (type.Contains("mt_") && subtype.Contains("rwb"))

                {
                    if (!Mithra_Archery_Animations.Contains(filename))
                    {
                        Mithra_Archery_Animations.Add(filename);
                    }
                }
                if (type.Contains("tr_") && subtype.Contains("rwb"))
                {
                    if (!Taru_Archery_Animations.Contains(filename))
                    {
                        Taru_Archery_Animations.Add(filename);
                    }
                }
            }
            Dump();
        }

        #endregion Public Methods
    }
}