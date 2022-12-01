using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //property that specifies the map
    public string ID { get; set; }

    //property that tells us what the value of a card is
    public int Card_Value { get; set; }
    //property that tell us whether the card is a face card
    public bool IDNumber
    {
        get
        {
            if (ID == "J" || ID == "Q" || ID == "K" || ID == "A") return true;
            else return false;
        }
    }

    //constructor
    public Card()
    { ID = ""; Card_Value = 0; }
    public Card(string ID_karte)//recieves the string ID, labels the number cards as standard and "J", "Q", "K", "A" as their respective values
    {
        ID = ID_karte;
        //if it cant be converted into a number
        try
        {
            Card_Value = int.Parse(ID_karte);//cards 2,3,4,5,6,7,8,9,10
        }
        catch //if it can't be converted into a number
        {
            if (ID_karte == "J" || ID_karte == "Q" || ID_karte == "K")//if the card is J, Q, or K, the value is 10
            {
                Card_Value = 10;
            }
            else Card_Value = 11;//if the card is an A, the default value is 11, this may be changed later in the game
        }
    }
}