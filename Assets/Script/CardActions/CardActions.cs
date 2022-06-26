using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardActions : AllCardInteraction, IPointerClickHandler
{
    private TurnManager turnManager;
    private int waitTurn;

    private void Start()
    {
        card = GetComponent<CardDisplay>().card;
        waitTurn = card.waitTurn;
        turnManager = GameObject.FindGameObjectWithTag("TurnManager").GetComponent<TurnManager>();
    }

    protected override void Update()
    {
        base.Update();
        if (!turnManager.playerTurn && waitTurn == 1)
            waitTurn -= 1;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // call for select target
        if (!GameManager.instance.isActive && turnManager.playerTurn && waitTurn == 0)
        {
            GameManager.instance.targetPointer.GetComponent<CircleCollider2D>().enabled = true;
            GameManager.instance.targetPointer.GetComponent<Image>().enabled = true;
            GameManager.instance.targetPointer.SendMessage("SelectTargetFor", 1);
            GameManager.instance.targetPointer.SendMessage("PointerVisual", gameObject);
            GameManager.instance.isActive = true;
        }
    }

    private void AttackPhase()
    {
        var targetContainer = GameManager.instance.targetContainer;
        for (int i = 0; i < targetContainer.Count; i++)
        {
            targetContainer[i].SendMessage("ReceiveDamage", currAttack);
            targetContainer[i].SendMessage("TradeDamage", gameObject);
            targetContainer.Remove(targetContainer[i]);
        }
    }
    
    private void Summon()
    {
        // summon effect for champions / spell
    }

    private void TradeDamage(GameObject attacker)
    {
        attacker.SendMessage("ReceiveDamage", currAttack);
    }

    protected override void ReceiveDamage(int damage)
    {
        currHealth -= damage;

        if (currHealth <= 0)
        {
            Death();

            Destroy(gameObject);
        }
    }

    private void Death()
    {
        Deathrattle();

        // Add to graveyard

        Destroy(gameObject);
    }
}
