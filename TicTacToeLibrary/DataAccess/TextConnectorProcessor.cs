using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using TicTacToeLibrary.Models;

namespace TicTacToeLibrary.DataAccess
{
    public static class TextConnectorProcessor
    {
        #region * Load the text file 
        public static string FullFilePath(this string fileName)
        {

            return $"{ConfigurationManager.AppSettings["filePath"]}\\{ fileName }";
        }
        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }
        #endregion

        #region * Converts the List<PlayerModel> to text and saves it to List<string>
        public static List<PlayerModel> ConvertToPlayerModels(this List<string> lines)
        {
            List<PlayerModel> output = new List<PlayerModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                // Note if the Order is wrong you'll get an error! 
                PlayerModel p = new PlayerModel();
                p.Id = int.Parse(cols[0]);
                p.Name = cols[1];
                p.Wins = int.Parse(cols[2]);
                p.GamesPlayed = int.Parse(cols[3]);
                p.WinLoseRatio = float.Parse(cols[4]);
                p.AmountOfMoneyWon = decimal.Parse(cols[5]);
                output.Add(p);
            }
            return output;
        }
        #endregion

        #region * Saves the List<PlayerModel> to PlayerFile
        public static void SaveToPlayerFile(this List<PlayerModel> models, string fileName)
        {
            List<string> lines = new List<string>();
            foreach (PlayerModel p in models)
            {
                lines.Add($"{p.Id},{p.Name},{p.Wins},{p.GamesPlayed},{p.WinLoseRatio},{p.AmountOfMoneyWon}");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
            
        }
        #endregion

        #region Deletes the File
        public static void DeletePlayerFile(string fileName)
        {
            File.Delete(fileName.FullFilePath());
        }
        #endregion
    }
}
