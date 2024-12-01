using Microsoft.AspNetCore.Mvc;

namespace HigherLowerApi.Models
{
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades,
        Joker
    }

    public class Card : Controller
    {
        public int Rank { get; set; }
        public Suit Suit { get; set; }
        public bool IsJoker { get; set; }

        public Card(int rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
            IsJoker = suit == Suit.Joker;  // Set IsJoker to true if the suit is Joker
        }

        public override string ToString()
        {
            if (Suit == Suit.Joker)
            {
                return "Joker";  // For Joker, return "Joker" as the string representation
            }

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
