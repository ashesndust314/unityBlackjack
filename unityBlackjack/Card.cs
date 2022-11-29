using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    /// <summary>
    /// Svojstvo koje odredjuje kartu
    /// </summary>
    public string ID { get; set; }

    /// <summary>
    /// Svojstvo koje nam kaze kolika je blackjack vrijednost karte
    /// </summary>
    public int Card_Value { get; set; }
    /// <summary>
    /// Svojstvo koje govori je li karta broj ili znak sluzi za dodavanje karata na ekran
    /// </summary>
    public bool IDNumber
    {
        get
        {
            if (ID == "J" || ID == "Q" || ID == "K" || ID == "A") return true;
            else return false;
        }
    }

    //konstruktori
    public Card()
    { ID = ""; Card_Value = 0; }
    public Card(string ID_karte)//prima string ID,dakle oznaku karte,brojeve standardno te "J","Q","K","A"
    {
        ID = ID_karte;
        //ako se moze pretvoriti u broj
        try
        {
            Card_Value = int.Parse(ID_karte);//karte 2,3,4,5,6,7,8,9,10
        }
        catch //ako se ne moze pretvoriti u broj
        {
            if (ID_karte == "J" || ID_karte == "Q" || ID_karte == "K")//ako je karta J,Q ili K,vrijednost je 10
            {
                Card_Value = 10;
            }
            else Card_Value = 11;//ako je karta as,defaultno se stavi na pocetak 11,kasnije se mjenja tijekom igre po potrebi
        }
    }
}