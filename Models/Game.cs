using Microsoft.AspNetCore.Mvc;

namespace HigherLowerApi.Models
{
    public class Game : Controller
    {
        private Deck deck;
        private int score;
        private Card currentCard;
        private bool includeJokers;

        public Game()
        {
            includeJokers = false;
            deck = new Deck(includeJokers);
            score = 0;
            currentCard = new Card(0, Suit.Hearts);
        }


        public void StartGame(bool includeJokers)
        {
            deck = new Deck(includeJokers);
            deck.Shuffle();
            score = 0;
            currentCard = deck.DealCard();


        }

        public string MakeGuess(string guess)
        {
            if (deck.IsEmpty())
            {
                deck = new Deck(includeJokers);
                deck.Shuffle();
                score = 0;
                currentCard = deck.DealCard();
            }

            var nextCard = deck.DealCard();
            string result = "";

            if (currentCard.Suit == Suit.Joker || nextCard.Suit == Suit.Joker ||
        (guess.ToLower() == "higher" && nextCard.Rank > currentCard.Rank) ||
        (guess.ToLower() == "lower" && nextCard.Rank < currentCard.Rank))
            {
                score++;
                result = "Correct!";
            }
            else
            {
                score = 0;
                result = "Incorrect!";
            }
            currentCard = nextCard;

            if (deck.IsEmpty())
            {
                deck = new Deck(includeJokers);
                deck.Shuffle();
            }

            return result;
        }

        public object GetGameState()
        {
            return new
            {
                currentCard = new
                {
                    rank = currentCard.Rank.ToString(),
                    suit = currentCard.Suit.ToString()
                },

                Score = score
            };
        }

        // Method to toggle Jokers on or off
        public void ToggleJokers()
        {
            includeJokers = !includeJokers;  // Toggle the includeJokers flag
            deck = new Deck(includeJokers);  // Recreate the deck based on the new setting
            deck.Shuffle();
            score = 0;
            currentCard = deck.DealCard();
            StartGame(includeJokers);
        }
    }
}
