using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public LayerMask typeOfCard;
    public int id;
    public string cardName;
    public int cost;
    public int attack;
    public int health;
    public string description;
    public Sprite artwork;
    public int waitTurn = 1;
}
