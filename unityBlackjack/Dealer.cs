using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.UnityEngine;

public class Dealer : Person
{
    //constructor
    public Dealer() : base() //the dealer uses a base class constructor
    {
        _bust = false;
    }

    private bool _bust;

    //To know if the dealer has exceeded the sum of 21, then it's true, otherwise it's false
    public bool Bust
    {
        get
        {
            if (HandValue <= 21) return true; //If the dealer is 21 or less, it's not Bust, otherwise it's not
            else return false;
        }
        set
        { _bust = value; }
    }
}