using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToeLibrary.Models;

namespace TicTacToeLibrary
{
    public class Calculations
    {

        public static List<PlayerModel> RandomizeWhoStarts(List<PlayerModel> players)
        {
            // Stackover Flow Randomize a List<T> -- cards.OrderBy(a => Guid.NewGuid()).ToList();
            return players.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}
