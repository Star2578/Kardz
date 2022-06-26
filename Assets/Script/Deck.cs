using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<GameObject> deck = new List<GameObject>();
    public List<GameObject> container = new List<GameObject>();
    public int deckSize = 40;

    private List<GameObject> deckInfo = new List<GameObject>();
    
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

        var newCard = Instantiate(deck[0]);
        var hand = GameObject.FindGameObjectWithTag("Hand");

        newCard.SetActive(true);
        newCard.transform.SetParent(hand.transform);
        // newCard.GetComponent<RectTransform>().localScale = Vector3.one;
        newCard.GetComponent<RectTransform>().sizeDelta = GameManager.instance.cardSummonedPf.GetComponent<RectTransform>().sizeDelta;
        newCard.GetComponent<RectTransform>().localScale = GameManager.instance.cardSummonedPf.GetComponent<RectTransform>().localScale;
        newCard.GetComponent<RectTransform>().position = GameManager.instance.cardSummonedPf.GetComponent<RectTransform>().position;
        newCard.SendMessage("Display");

        deck.Remove(deck[0]);
    }
}
