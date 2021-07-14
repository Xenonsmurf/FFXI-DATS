using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXI_INFO.Common
{
    public class knownFiles
    {
        public static getRomPath Rom { get; set; }
        public knownFiles(getRomPath rp)
        {
            Rom = rp;
        }
        public (int ID, string TypeName)[] files = new (int ID, string TypeName)[]
         {
                (81, "SpellAbilCommon"),
                (73, "generalEnglish"),
                (74, "usable English"),
                (75, "weaponEnglish"),
                (76, "armorEnglish"),
                (55668, "armor2English"),
                (77, "puppetEnglish"),
                (91, "currencyEnglish"),
                (55667, "slipEnglish"),
                (55701, "abilEnglish"),
                (55465, "areaEnglish"),
                (55702, "spellEnglish"),
                (55726, "statusEnglish"),
                (56235, "generalFrench"),
                (56211, "general2French"),
                (56236, "usableFrench"),
                (56237, "weaponFrench"),
                (56238, "armorFrench"),
                (56208, "armor2French"),
                (56239, "puppetFrench"),
                (56240, "currencyFrench"),
                (56207, "slipFrench"),
                (56241, "abilFrench"),
                (56195, "areaFrench"),
                (56242, "spellFrench"),
                (56272, "statusFrench"),
                (55815, "generalGerman"),
                (55791, "general2German"),
                (55816, "usableGerman"),
                (55817, "weaponGerman"),
                (55818, "armorGerman"),
                (55788, "armor2German"),
                (55819, "puppetGerman"),
                (55820, "currencyGerman"),
                (55787, "slipGerman"),
                (55821, "abilGerman"),
                (55775, "areaGerman"),
                (55822, "spellGerman"),
                (55852, "statusGerman"),
                (4, "generalJapanese"),
                (55551, "general2Japanese"),
                (5, "usableJapanese"),
                (6, "weaponJapanese"),
                (7, "armorJapanese"),
                (55548, "armor2Japanese"),
                (8, "puppetJapanese"),
                (9, "currencyJapanese"),
                (55547, "slipJapanese"),
                (55581, "abilJapanese"),
                (55535, "areaJapanese"),
                (55582, "spellJapanese"),
                (55605, "statusJapanese"),
                (11, "old-spells-1"),
                (73, "items-general"),
                (55671, "items-general2"),
                (74, "items-usable"),
                (75, "items-weapons"),
                (76, "items-armor"),
                (55668, "items-armor2"),
                (77, "items-puppet"),
                (82, "quests"),
                (85, "old-abilities"),
                (86, "old-spells-2"),
                (87, "old-statuses"),
                (91, "items-currency"),
                (55667, "items-voucher-slip"),
         };

        public void getFilePathForKnownFiles()
        {
            foreach (var datFile in files)
            {
                if (File.Exists($@"{Rom.installPath}{Rom.GetRomPath(datFile.ID, Rom.tableDirectory)}"))
                {
                    Print(datFile.TypeName, Rom.GetRomPath(datFile.ID, Rom.tableDirectory));
                }
            }
        }
        public  void Print(string a, string b)
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
