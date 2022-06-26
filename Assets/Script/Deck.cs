using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public int deckSize = 40;

    private List<Card> deckInfo = new List<Card>();
    
    private void Start()
    {
        deckInfo = CardDatabase._instance.cardList;

        for (int i = 0; i < deckSize; i++)
        {
            deck.Add(deckInfo[Random.Range(0, deckInfo.Count)]);
        }
        
        BroadcastMessage("OnSetup");
    }

    public void Shuffle()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }
    }

    public void Draw()
    {
        if (deck.Count == 0)
        {
            return;
        }

        GameManager.instance.cardInHand += 1;

        if (GameManager.instance.cardInHand > 8)
        {
            deck.Remove(deck[0]);
            GameManager.instance.cardInHand--;
            return;
        }

        var newCard = Instantiate(GameManager.instance.cardPf);
        var hand = GameObject.FindGameObjectWithTag("Hand");

        newCard.SetActive(true);
        newCard.transform.SetParent(hand.transform);
        newCard.GetComponent<CardDisplay>().card = deck[0];
        newCard.GetComponent<RectTransform>().localScale = Vector3.one;
        newCard.GetComponent<RectTransform>().sizeDelta = GameManager.instance.cardSummonedPf.GetComponent<RectTransform>().sizeDelta;
        newCard.GetComponent<RectTransform>().localScale = GameManager.instance.cardSummonedPf.GetComponent<RectTransform>().localScale;
        newCard.GetComponent<RectTransform>().position = GameManager.instance.cardSummonedPf.GetComponent<RectTransform>().position;
        newCard.SendMessage("Display");

        deck.Remove(deck[0]);
    }
}
