using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static CardDatabase _instance;

    public List<Card> cardList = new List<Card>();

    void Awake()
    {
        _instance = this;
    }
}
