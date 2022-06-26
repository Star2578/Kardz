using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static CardDatabase _instance;

    public List<GameObject> cardList = new List<GameObject>();

    void Awake()
    {
        _instance = this;
    }
}
