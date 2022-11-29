using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using UnityEngine;

public class Person : MonoBehaviour
{
    public Person()
    {
        LastCard_X = 0;
        LastCard_Y = 0;
        Active = false;
        SoftHand = false;
        r = new Random();
    }
    
    //List of cards a person has in their hand
    public List<Card> Hand { get; set; }

    private Random r; //random object

    //Sets the coordinates for the next card that will appear on the screen
    public void SetNewCard(int x, int y)
    {
        LastCard_X = x; LastCard_Y = y;
    }

    //Numerical value of the cards the person has in their hand
    public int HandValue
    {
        get
        {
            int aceCount = 0; //number of aces a person has in their hand
            int handValue = 0; //total value of the cards
            for (int i = 0; i < Hand.Count; i++)
            {
                if (Hand[i].ID == "A")
                {
                    aceCount += 1;
                }
                else //cards are aren't aces
                {
                    handValue += Hand[i].Card_Value;
                }
            }
            SoftHand = false; //soft hand is false by default

            //check if any aces have a value of 11
            if (aceCount > 0) //if you have multiple aces, only one can have a value of 11
            {
                if ((handValue + 11 + aceCount - 1) <= 21)
                {
                    handValue = handValue + 11 + aceCount - 1; //set one ace as value of 11, other aces with value of 1
                    SoftHand = true; //setting soft hand to true
                }
                else //if no ace can have a value of 11 (otherwise bust), all aces have value of 1
                {
                    handValue += aceCount;
                }
            }
            return handValue;
        }
    }

   //The property of cards that a player has, if an ace has a value of 11, then SoftHand is true, otherwise it is false
    public bool SoftHand { get; set; }

    //check the position of the last card of the player on the screen, if the position is (0,0), then there are no cards
    public int LastCard_X { get; set; }

    public int LastCard_Y { get; set; }

    //to know if the player is active, aka if they are currently playing
    public bool Active { get; set; }

    //Adding a new card for the player
    public void AddNewCard(Card newCard)
    {
        //string image path
        string putanja = "sprites\\cards2\\" + newCard.ID.ToString() + "\\" + r.Next(1, 5).ToString() + ".png";
        Hand.Add(newCard); //adding a new card to the list of cards a player has
        Sprite card = new Sprite(putanja, LastCard_X, LastCard_Y, BlackjackGame.Sirina, BlackjackGame.Visina, "card"); //making a new sprite
        Game.AddSprite(card); //Add a card to the game
        SetNewCard(LastCard_X + 15, LastCard_Y); //setting the position of the new card
    }
}