using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    [SerializeField] private CardStatus cardStatus;
    [SerializeField] private Deck deck;
    [SerializeField] private Image artwork;
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI cost;
    [SerializeField] private TextMeshProUGUI attack;
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI description;

    private void Start()
    {
        var contain = GameObject.FindGameObjectWithTag("Deck");
        deck = contain.GetComponent<Deck>();
        cardStatus = GetComponent<CardStatus>();
    }

    private void Update()
    {
        if (card == null)
        {
            card = GameManager.instance.placeholder;
        }
        artwork.sprite = card.artwork;
        cardName.text = card.cardName;
        cost.text = cardStatus.currCost.ToString();
        attack.text = cardStatus.currAttack.ToString();
        health.text =cardStatus.currHealth.ToString();
        description.text = card.description;
    }

    private void Display()
    {
        artwork.sprite = card.artwork;
        cardName.text = card.cardName;
        cost.text = card.cost.ToString();
        attack.text = card.attack.ToString();
        health.text = card.health.ToString();
        description.text = card.description;
    }
}
