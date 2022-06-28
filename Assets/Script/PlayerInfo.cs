using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public GameObject player;

    public PlayerInfo(GameObject player)
    {
        this.player = player;
    }

    public Player data
    {
        get
        {
            // Return ScriptableItem from our cached list, based on the card's uniqueID.
            return player.GetComponentInChildren<Player>();
        }
    }
}
