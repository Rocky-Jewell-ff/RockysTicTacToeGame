using System.Collections.Generic;

namespace TicTacToeLibrary.Models
{
    public class GameModel
    {
        public int Id { get; set; }
        public List<PlayerModel> Vs { get; set; } = new List<PlayerModel>();
        public decimal Bet { get; set; }
        public bool Winner { get; set; }
        public int Round { get; set; }
    }
}
