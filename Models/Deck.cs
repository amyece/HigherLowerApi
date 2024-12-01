using Microsoft.AspNetCore.Mvc;

namespace HigherLowerApi.Models
{
    public class Deck : Controller
    {
        private List<Card> cards;
        private Random random;

        public Deck()
        {
            random = new Random();
            cards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (int rank = 1; rank <= 13; rank++)
                {
                    cards.Add(new Card(rank, suit));
                }
            }
        }

        public void Shuffle()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                int j = random.Next(cards.Count);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public Card DealCard()
        {
            if (cards.Count > 0)
            {
                Card dealtCard = cards[0];
                cards.RemoveAt(0);
                return dealtCard;
            }
            return null;
        }

        public bool IsEmpty()
        {
            return cards.Count == 0;
        }
    }
}
