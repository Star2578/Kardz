using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum PlayerType { PLAYER, ENEMY };

public class Player : Entity
{
    [Header("Player Info")]
    public string username;
    public TextMeshProUGUI userName;

    [HideInInspector] public static Player localPlayer;
    [HideInInspector] public bool hasEnemy = false;
    [HideInInspector] public PlayerInfo enemyInfo;
    [HideInInspector] public bool firstPlayer = false;
}
