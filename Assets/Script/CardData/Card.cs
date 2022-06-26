using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CardType : byte { CHAMPION, MINION, SPELL }
public enum Region : byte { DEMACIA, PILTOVER, NOXUS, IONIA, BANDLE, BILGEWATER, FRELJORD, TARGON, SHURIMA, SHADOWISLE}
public enum CreatureType : byte { NONE, YORDLES, SEAMONSTER, BEAST, DRAGON, MECH}

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public List<CardType> cardTypes;
    public List<Region> regions;
    public List<CreatureType> creatureTypes;
    public int id;
    public string cardName;
    public int cost;
    public int attack;
    public int health;
    public string description;
    public Sprite artwork;
    public int waitTurn = 1;
}
