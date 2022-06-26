using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCardInteraction : CardStatus
{
    protected void Attack()
    {
        // effect after / while attack / before attack
    }
    protected void GotAttacked()
    {
        // reflect damage / decrease damage
    }
    protected void Battlecry()
    {
        // after summon effect
    }
    protected void Deathrattle()
    {
        // after dead effect
    }
    protected void OnField()
    {
        // while alive effect
    }
    protected void ReturnToHand(Card cardInfo)
    {
        var hand = GameObject.FindGameObjectWithTag("Hand");
        var returnCard = Instantiate(GameManager.instance.cardPf, hand.transform);

        returnCard.GetComponent<CardDisplay>().card = cardInfo;
        returnCard.SetActive(true);

        Destroy(gameObject);
    }
}
