namespace TicTacToeLibrary.Models
{
    public class SkillsModel
    {
        public int Id { get; set; }
        public bool BackToBack { get; set; } = false;
        public bool OverRide { get; set; } = false;
        public bool ClearBoard { get; set; } = false;
        public bool MoveTheirPiece { get; set; } = false;
    }
}
