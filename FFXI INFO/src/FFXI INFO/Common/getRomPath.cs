using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXI_INFO.Common
{
    public class getRomPath
    {
        public getRomPath()
        {
            installPath = "C:\\Program Files (x86)\\PlayOnline\\SquareEnix\\FINAL FANTASY XI\\";
        }
        public string installPath { get; set; }

        public (int RomIndex, string Vtable, string Ftable)[] tableDirectory = new (int RomIndex, string Vtable, string Ftable)[]
        {
                (1, "C:\\Program Files (x86)\\PlayOnline\\SquareEnix\\FINAL FANTASY XI\\VTABLE.dat",
                    "C:\\Program Files (x86)\\PlayOnline\\SquareEnix\\FINAL FANTASY XI\\FTABLE.dat"),
                (2, "C:\\Program Files (x86)\\PlayOnline\\SquareEnix\\FINAL FANTASY XI\\ROM2\\VTABLE2.dat",
                    "C:\\Program Files (x86)\\PlayOnline\\SquareEnix\\FINAL FANTASY XI\\ROM2\\FTABLE2.dat"),
                (3, "C:\\Program Files (x86)\\PlayOnline\\SquareEnix\\FINAL FANTASY XI\\ROM3\\VTABLE3.dat",
                    "C:\\Program Files (x86)\\PlayOnline\\SquareEnix\\FINAL FANTASY XI\\ROM3\\FTABLE3.dat"),
                (4, "C:\\Program Files (x86)\\PlayOnline\\SquareEnix\\FINAL FANTASY XI\\ROM4\\VTABLE4.dat",
                    "C:\\Program Files (x86)\\PlayOnline\\SquareEnix\\FINAL FANTASY XI\\ROM4\\FTABLE4.dat"),
                (5, "C:\\Program Files (x86)\\PlayOnline\\SquareEnix\\FINAL FANTASY XI\\ROM5\\VTABLE5.dat",
                    "C:\\Program Files (x86)\\PlayOnline\\SquareEnix\\FINAL FANTASY XI\\ROM5\\FTABLE5.dat"),
                (6, "C:\\Program Files (x86)\\PlayOnline\\SquareEnix\\FINAL FANTASY XI\\ROM6\\VTABLE6.dat",
                    "C:\\Program Files (x86)\\PlayOnline\\SquareEnix\\FINAL FANTASY XI\\ROM6\\FTABLE6.dat"),
                (7, "C:\\Program Files (x86)\\PlayOnline\\SquareEnix\\FINAL FANTASY XI\\ROM7\\VTABLE7.dat",
                    "C:\\Program Files (x86)\\PlayOnline\\SquareEnix\\FINAL FANTASY XI\\ROM7\\FTABLE7.dat"),
                (8, "C:\\Program Files (x86)\\PlayOnline\\SquareEnix\\FINAL FANTASY XI\\ROM8\\VTABLE8.dat",
                    "C:\\Program Files (x86)\\PlayOnline\\SquareEnix\\FINAL FANTASY XI\\ROM8\\FTABLE8.dat"),
                (9, "C:\\Program Files (x86)\\PlayOnline\\SquareEnix\\FINAL FANTASY XI\\ROM9\\VTABLE9.dat",
                    "C:\\Program Files (x86)\\PlayOnline\\SquareEnix\\FINAL FANTASY XI\\ROM9\\FTABLE9.dat")
        };
        public string GetRomPath(int fId, IList<(int RomIndex, string Vtable, string Ftable)> tableDirectory)
        {
            for (var i = 0; i < tableDirectory.Count; i++)
            {
                using var vreader = new BinaryReader(File.OpenRead(tableDirectory[i].Vtable));

                if (fId > vreader.BaseStream.Length - 1) continue;
                var vTableOffset = fId;
                vreader.BaseStream.Seek(vTableOffset, SeekOrigin.Begin);
                var vTableValue = vreader.ReadByte();
                vreader.Close();
                using var freader = new BinaryReader(File.OpenRead(tableDirectory[i].Ftable));
                var fTableOffset = fId * 2;
                freader.BaseStream.Seek(fTableOffset, SeekOrigin.Begin);
                Console.ForegroundColor = ConsoleColor.Green;
                var fvalue = freader.ReadUInt16();
                freader.Close();
                switch (vTableValue)
                {
                    case 0:
                        continue;
                    case 1:
                        return $@"ROM\{fvalue >> 7}\{fvalue & 0x7F}.DAT";

                    default:
                        return $@"ROM{vTableValue}\{fvalue >> 7}\{fvalue & 0x7F}.DAT";
                }
            }
            return "";
        }
    }
}
