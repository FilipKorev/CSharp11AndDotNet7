using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System;

SectionTitle("* Handling cross-platform enviroments and filesystems");
Console.WriteLine("{0,-33} {1}", arg0: "Path.Separator", arg1: PathSeparator);
Console.WriteLine("{0,-33} {1}", arg0: "Path.DirectorySeparatorChar", arg1: DirectorySeparatorChar);
Console.WriteLine("{0,-33} {1}", arg0: "Directory.GetCurrentDirectory()", arg1: GetCurrentDirectory());
Console.WriteLine("{0,-33} {1}", arg0: "Enviroment.CurrentDirectory", arg1: CurrentDirectory);
Console.WriteLine("{0,-33} {1}", arg0: "Enviroment.SystemDirectory", arg1: SystemDirectory);
Console.WriteLine("{0,-33} {1}", arg0: "Path.GetTempPath()", arg1: GetTempPath());
Console.WriteLine("GetFolderPath(SpecialFolder)");
Console.WriteLine("{0,-33} {1}", arg0: " .System", arg1: GetFolderPath(SpecialFolder.System));
Console.WriteLine("{0,-33} {1}", arg0: " .ApplicationData", arg1: GetFolderPath(SpecialFolder.ApplicationData));
Console.WriteLine("{0,-33} {1}", arg0: " .MyDocuments", arg1: GetFolderPath(SpecialFolder.MyDocuments));
Console.WriteLine("{0,-33} {1}", arg0: " .Personal", arg1: GetFolderPath(SpecialFolder.Personal));