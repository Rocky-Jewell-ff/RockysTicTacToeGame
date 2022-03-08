using System.Collections.Generic;
using TicTacToeLibrary.Models;

namespace TicTacToeLibrary.DataAccess
{
    public interface IDataConnection
    {
        PlayerModel CreatePlayer(PlayerModel model);
        PlayerModel UpdatePlayer(PlayerModel model);
        List<PlayerModel> GetAllPlayers();

    }
}
