namespace TicTacToeLibrary.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Wins { get; set; }
        public int GamesPlayed { get; set; }

        public float WinLoseRatio { get; set; }
        public decimal AmountOfMoneyWon { get; set; }

        public string PlayerDisplayName
        {
            get
            {
                return $"{Name} Wins {Wins}, Bank Value ${AmountOfMoneyWon}";
            }
        }

        public string DisplayName
        {
            get
            {
                return $"{Id}:  {Name}";
            }
        }

    }


}
