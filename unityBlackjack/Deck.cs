using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.UnityEngine;

public class Deck : MonoBehavior
{
    private Random r;

    //A collection of cards in one object
    public List<Card> Cards { get; set; }

    public int CardsNumber //Number of cards using in the game
    {
        get { return Cards.Count; }
    }

    //Method that shuffles the playing cards
    public void Shuffle()
    {
        Random r = new Random(); //creates a random object with which we mix the cards
        for (int i = 1; i <= 100; i++)//shuffling the cards 100 times 
        {
            for (int index = 0; index < CardsNumber; index++) //go from the first card to the last card in the deck
            {
                int k = r.Next(0, CardsNumber - 1); //random card index in the deck
                Card temp = Cards[index];
                Cards[index] = Cards[k];
                Cards[k] = temp;
            }
        }
    }

    //Method that adds the card to the game and removes it from the deck
    public Card ReturnCard()
    {
        int index = r.Next(0, CardsNumber - 1);
        Card card = new Card(Cards[index].ID); //The card that is returned
        Cards.RemoveAt(index);
        return card;
    }

    public Deck() //First constructor
    {
        Cards = new List<Card>(); r = new Random();
    }
    public Deck(int n)//Second constructor, specifies how many decks to use
    {
        r = new Random();
        Cards = new List<Card>();
        for (int i = 1; i <= n; i++)//n times we add 1 deck(52 cards) to the total deck
        {
            AddDeck(); //add one deck
        }
    }

    //Method used in the constructor, n times to add 1 deck to the total deck
    private void AddDeck()
    {
        for (int i = 1; i <= 4; i++) //for each colour
        {
            for (int l = 2; l <= 10; l++) //number cards
            {
                Card karta = new Card(l.ToString());
                Cards.Add(karta);
            }
            //face cards
            Card a = new Card("A"); Card k = new Card("K"); Card q = new Card("Q"); Card j = new Card("J");
            Cards.Add(a); Cards.Add(k); Cards.Add(q); Cards.Add(j);
        }
    }
}