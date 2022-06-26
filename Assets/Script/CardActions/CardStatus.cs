using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStatus : MonoBehaviour
{
    protected Card card;
    private bool once = false;
    public int baseCost;
    public int currCost;
    public int baseAttack;
    public int currAttack;
    public int baseHealth;
    public int currHealth;

    protected virtual void Update()
    {
        var cardDisplay = GetComponent<CardDisplay>().card;
        if (!once && cardDisplay != null)
        {
            card = cardDisplay;
            baseCost = card.cost;
            currCost = baseCost;
            baseAttack = card.attack;
            currAttack = baseAttack;
            baseHealth = card.health;
            currHealth = baseHealth;
            once = true;
        }
    }

    protected virtual void ReceiveDamage(int damage)
    {
        currHealth -= damage;

        if (currHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
