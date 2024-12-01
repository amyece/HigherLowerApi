using Microsoft.AspNetCore.Mvc;

namespace HigherLowerApi.Models
{
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }
    public class Card : Controller
    {
        public int Rank { get; set; }
        public Suit Suit { get; set; }

        public Card(int rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public override string ToString()
        {
            string rankName = Rank switch
            {
                1 => "Ace",
                11 => "Jack",
                12 => "Queen",
                13 => "King",
                _ => Rank.ToString()
            };

            return $"{rankName} of {Suit}";
        }
    }
}
