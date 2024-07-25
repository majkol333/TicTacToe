using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.FileIO;

namespace TicTacToe
{
    static class DataSystem
    {
        public static DirectoryInfo dir = new DirectoryInfo(Path.GetFullPath("data"));
        public static FileInfo[] dataSave = {new FileInfo(Path.GetFullPath("data/uwins.txt")), new FileInfo(Path.GetFullPath("data/cwins.txt")), new FileInfo(Path.GetFullPath("data/draws.txt"))};
        public static int[] data = {0, 0, 0};
        public static void SaveData()
        {
            for (int i = 0; i < 3; i++)
            {
                using (StreamWriter sw = dataSave[i].CreateText())
                    sw.WriteLine(data[i]);
            }
        }
        public static void CreateDir()
        {
            if (dir.Exists)
            {
                FileSystem.DeleteDirectory(dir.FullName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            }
            
            dir.Create();
            for (int i = 0; i < 3; i++)
                dataSave[i].Create();

            SaveData();
        }
        public static void LoadData()
        {
            if (dir.Exists)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (File.Exists(dataSave[i].FullName))
                    {
                        using (StreamReader sr = new(dataSave[i].FullName))
                        {
                            if (!int.TryParse(sr.ReadLine(), out data[i]))
                            {
                                data[i] = 0;
                            }
                        }
                    }
                    else
                        data[i] = 0;
                }
                SaveData();
            }
            else
            CreateDir();
        }

    }
}