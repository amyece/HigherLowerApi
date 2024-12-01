using Microsoft.AspNetCore.Mvc;

namespace HigherLowerApi.Models
{
    public class Game : Controller
    {
        private Deck deck;
        private int score;
        private Card currentCard;

        public Game()
        {
            deck = new Deck();
            score = 0;
            currentCard = new Card(0, Suit.Hearts);
        }


        public void StartGame()
        {
            deck.Shuffle();
            score = 0;
            currentCard = deck.DealCard();
        }

        public string MakeGuess(string guess)
        {
            if (deck.IsEmpty())
            {
                deck = new Deck();
                deck.Shuffle();
                score = 0;
                currentCard = deck.DealCard();
            }

            var nextCard = deck.DealCard();
            string result = "";

            if ((guess.ToLower() == "higher" && nextCard.Rank > currentCard.Rank) || (guess.ToLower() == "lower" && nextCard.Rank < currentCard.Rank))
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
                deck = new Deck();
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
    }
}
