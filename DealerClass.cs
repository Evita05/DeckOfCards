using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDeck
{
    /// <summary>
    /// Card class contains a card of suite (For eg :  clubs, diamond etc ) and cardtype (For eg : A, 2,3 etc)
    /// </summary>
    public class Card
    {
        public string suit { get; set; }
        public string cardType { get; set; }
    }
    public class DealerClass
    {
        PlayingDeck py = new PlayingDeck();
        DealtDeck dlt = new DealtDeck();
        public List<Card> dealerCards { get; set; }
        public void InitializeDeck()
        {
            InitializeDealerCards();
            InitializePlayingDeck(dealerCards);
            InitializeDealtDeck();
        }
        /// <summary>
        ///  Setting the 52 cards to the dealerCards object
        /// </summary>
        public void InitializeDealerCards()
        {
            this.dealerCards = new List<Card>();
            String[] suit = new string[] { "Clubs" };
            List<string> suits = new List<string>();
            suits.AddRange(suit);
            String[] cardTypes = new string[] { "A", "2" };
            List<string> cardType = new List<string>();
            cardType.AddRange(cardTypes);

            foreach(var a in suits)
            {
                foreach(var b in cardType)
                {
                    Card _c = new Card
                    {
                        suit = a,
                        cardType = b
                    };
                    this.dealerCards.Add(_c);
                }
                
            }
         
        }
        /// <summary>
        /// Initialize the playing deck
        /// </summary>
        /// <param name="dealerCards"></param>
        public void InitializePlayingDeck(List<Card> dealerCards)
        {
            py.cardList = dealerCards;
        }
        /// <summary>
        ///  This is the object where the cards that have been picked are saved
        /// </summary>
        public void InitializeDealtDeck()
        {
            dlt.cardList = new List<Card>();
        }
      
        /// <summary>
        /// Resetting the decks, playingdeck to 52 cards and dealtdeck is empty
        /// </summary>
        public void resetGame()
        {
            InitializeDeck();
             
        }
        /// <summary>
        /// Pick the card from the playing deck , insert it into the dealt deck and remove it from the playing deck
        /// </summary>
        public void pickCard()
        {        
            try
            {
                Card cardObj=this.py.returnPickedCard();
                this.dlt.cardList.Add(cardObj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());

            }

            

        }
        /// <summary>
        /// Shuffling the playing deck randomly
        /// </summary>
        public void shuffleDeck()
        {
            Random rnd = new Random();
            if (py.cardList.Count > 0)
            {
                for (int i = 0; i < py.cardList.Count; i++)
                {
                    var card = py.cardList[i];
                    int randomNum = rnd.Next(0, py.cardList.Count);
                    py.cardList[i] = py.cardList[randomNum];
                    py.cardList[randomNum] = card;
                }
                Console.WriteLine("The deck is shuffled");
            }
            else
            {
                Console.WriteLine("The deck is empty");
            }

            
        }
        /// <summary>
        /// Printing the decks : Dealt deck and playing deck
        /// </summary>

        public void printDecks()
        {
            Console.WriteLine("-----Dealt Deck --------");
            for (int i = 0; i < dlt.cardList.Count; i++)
            {
                if (dlt.cardList[i] != null)
                    Console.WriteLine("Position " + i + " holds " + dlt.cardList[i].suit + " "+dlt.cardList[i].cardType);
            }
            Console.WriteLine("-----PlayingDeck --------");
            for (int i = 0; i < py.cardList.Count; i++)
            {
                if (py.cardList[i] != null)
                    Console.WriteLine("Position " + i + " holds " + py.cardList[i].suit + " " + py.cardList[i].cardType);
            }
        }
    }

    public class Decks
    {
        public List<Card> cardList { get; set; }
    }

    public class PlayingDeck : Decks
    {
        
        public PlayingDeck()
        {
            this.cardList = new List<Card>();
           
        }

        public Card returnPickedCard()
        {
            var cardobj = this.cardList.FirstOrDefault();
            Console.WriteLine("You picked :: " + cardobj.suit + "  " + cardobj.cardType);
            this.cardList.Remove(cardobj);
            return cardobj;
        }
    }

    public class DealtDeck : Decks
    {
        
        public DealtDeck()
        {

        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            DealerClass cardsDeck = new DealerClass();
            cardsDeck.resetGame();
            Console.WriteLine("Please select from the below options:");
            Console.WriteLine("Press 1 to reset the game");
            Console.WriteLine("Press 2 to pick a card");
            Console.WriteLine("Press 3 to shuffle the deck");
            Console.WriteLine("Press 4 to print the decks");
            Console.WriteLine("Press X to exit.");
            string userInput = Console.ReadLine();
            userInput = Calculate(userInput, cardsDeck);

        }

        private static string Calculate(string userInput, DealerClass cardsDeck)
        {
            switch (userInput)
            {
                case "1":
                    cardsDeck.resetGame();
                    Console.WriteLine("The deck is reset");
                    break;
                case "2":
                    cardsDeck.pickCard();
                    break;
                case "3":
                    cardsDeck.shuffleDeck();
                    
                    break;
                case "4":  //write code to print all user cards. New feature
                    cardsDeck.printDecks();

                    break;
                case "X":
                    return "";
                case "x":
                    return "";
                default:
                    Console.WriteLine("Invalid Input.");

                    break;

            }
            Console.WriteLine("Press any of the options to continue : ");
            userInput = Console.ReadLine();
            userInput = Calculate(userInput, cardsDeck);
            return userInput;
        }
    }
}
