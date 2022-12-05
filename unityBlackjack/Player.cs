using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player : Person
{
    //basic constructor
    public Player(int _money) : base() //player uses a base class constructor
    {
        //set the starting values
        Money = _money;
        Score = 0;
        Bet = 0;
    }
    //Default constructor
    public Player() : base() { Score = 0; Money = 10000; }

    //Amount of player money
    public double Money { get; set; }

    private int cards_number;
    public int CardsNumber//property for how many cards a player has in their hand, if they have 7, the round ends
    {
        get { return Hand.Count; }
    }

    //0 tied, 1 lost 1 win
    public int Score { get; set; }

    //The player's Bet
    public int Bet { get; set; }

    //property that retrieves the ID of the player's last card, due to easier addition of cards to the screen
    public string LastCard
    {
        get { return Hand[CardsNumber - 1].ID; }
    }

    //property that returns the value of the player's last card
    public int LastCardValue
    {
        get { return Hand[CardsNumber - 1].Card_Value; }
    }
}