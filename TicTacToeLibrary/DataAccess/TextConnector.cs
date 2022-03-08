using System.Collections.Generic;
using System.Linq;
using TicTacToeLibrary.Models;

namespace TicTacToeLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string PlayerFile = "PlayerModels.csv";
        public PlayerModel CreatePlayer(PlayerModel model)
        {
            List<PlayerModel> players = PlayerFile.FullFilePath().LoadFile().ConvertToPlayerModels();

            // We need to find the Max id
            int currentId = 1;

            if (players.Count > 0)
            {
                currentId = players.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;

            players.Add(model);

            players.SaveToPlayerFile(PlayerFile);

            return model;
        }

        public List<PlayerModel> GetAllPlayers()
        {
            return PlayerFile.FullFilePath().LoadFile().ConvertToPlayerModels();
        }

        /// <summary>
        /// Updates the PlayerFile by removing the old entery and replaces it with a new one
        /// </summary>
        /// <param name="model">This is the PlayerModel you would like to update</param>
        /// <returns></returns>
        public PlayerModel UpdatePlayer(PlayerModel model)
        {
            List<PlayerModel> players = PlayerFile.FullFilePath().LoadFile().ConvertToPlayerModels();
            
            foreach (PlayerModel pm in players)
            {
                if (model.Id == pm.Id)
                {  
                    players.Remove(pm);
                    players.Add(model);
                    players.SaveToPlayerFile(PlayerFile);
                    return model;
                }
            }
            
            return model;
        }
    }
}
