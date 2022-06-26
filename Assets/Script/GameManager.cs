using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    public int currMana;
    public int currMaxMana = 0;
    public int maximumMana = 10;
    
    public Card placeholder;
    public GameObject cardPf;
    public GameObject cardSummonedPf;

    public Canvas maincanva;
    public RectTransform dropZone;

    public int cardInHand;
    public bool canLook = true;

    public List<Collider2D> targetContainer = new List<Collider2D>();
    public GameObject targetPointer;
    public bool isActive;

    public List<Card> graveyardPlayer = new List<Card>();
    public List<Card> graveyardEnemy = new List<Card>();
}
