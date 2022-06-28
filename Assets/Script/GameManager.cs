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

    [Header("Mana")]
    public int currMana;
    public int currMaxMana = 0;
    public int maximumMana = 10;
    
    [Header("Health")]
    public int currHealth;
    public int maxHealth = 40;

    [Header("Deck")]
    public int deckSize = 40;
    public int handSize = 8;
    public int cardInHand;

    [Header("Calls")]
    public Card placeholder;
    public GameObject cardPf;
    public GameObject cardSummonedPf;
    public Canvas maincanva;
    public RectTransform dropZone;

    [Header("Target")]
    public List<Collider2D> targetContainer = new List<Collider2D>();
    public GameObject targetPointer;

    [Header("Graveyard")]
    public List<Card> graveyardPlayer = new List<Card>();
    public List<Card> graveyardEnemy = new List<Card>();
    [HideInInspector] public bool isActive;
    [HideInInspector] public bool canLook = true;
}
