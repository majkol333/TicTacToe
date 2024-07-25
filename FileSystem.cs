/*using System.IO;
using System.Runtime.CompilerServices;

namespace TicTacToe
{
    static class FileSystem
    {
        public static int userWins = 0;
        public static int computerWins = 0;
        public static int draws = 0;
        public static DirectoryInfo dir = new DirectoryInfo(Path.GetFullPath("data"));
        public static FileInfo userWinsData = new FileInfo(Path.GetFullPath("data/uwins.txt"));
        public static FileInfo computerWinsData = new FileInfo(Path.GetFullPath("data/cwins.txt"));
        public static FileInfo drawsData = new FileInfo(Path.GetFullPath("data/draws.txt"));

        public static void SaveData()
        {
            using (StreamWriter sw = userWinsData.CreateText())
                sw.WriteLine(userWins);
            using (StreamWriter sw = computerWinsData.CreateText())
                sw.WriteLine(computerWins);
            using (StreamWriter sw = drawsData.CreateText())
                sw.WriteLine(draws);
        }
        public static void CreateDir()
        {
            dir.Create();
            userWinsData.Create();
            computerWinsData.Create();
            drawsData.Create();

            SaveData();
        }
        public static void LoadData()
        {
            if (dir.Exists)
            {
                if (File.Exists(userWinsData.FullName))
                {
                    using (StreamReader sr = new(userWinsData.FullName))
                    {

                    }
                }
            }
            else
            CreateDir();
        }

    }
}*/