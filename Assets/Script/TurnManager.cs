using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnManager : MonoBehaviour
{
    public bool enemyTurn;
    public bool playerTurn;
    public int enemyCount = 0;
    public int playerCount = 0;
    public int currMana;
    public int maxMana = 0;
    public int maximumMana = 10;
    public TextMeshProUGUI manaText;

    private void Start()
    {
        // OnSetup();
    }

    public void OnSetup()
    {
        playerCount += 1;
        playerTurn = true;
        enemyTurn = false;

        if (GameManager.instance.currMaxMana != GameManager.instance.maximumMana)
            GameManager.instance.currMaxMana += 1;
            
        GameManager.instance.currMana = GameManager.instance.currMaxMana;

        var draw = GameObject.FindGameObjectWithTag("Deck");
        var deckCheck = draw.GetComponent<Deck>();
        if (deckCheck.deck.Count != 0)
        {
            draw.SendMessage("Draw");
        }
    }

    private void Update()
    {
        manaText.text = GameManager.instance.currMana.ToString();

        if (Input.GetKeyDown(KeyCode.K) && playerTurn == false)
        {
            _TestEnemyEndTurn();
        }
    }

    public void OnEndTurn()
    {
        print("End Turn");
        enemyCount += 1;
        playerTurn = false;
        enemyTurn = true;
    }

    public void _TestEnemyEndTurn()
    {
        print("Enemy End Turn");
        playerTurn = true;
        enemyTurn = false;
        OnSetup();
    }
}
