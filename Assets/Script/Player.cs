using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public enum PlayerType { PLAYER, ENEMY };

public class Player : Entity
{
    [Header("Player Info")]
    public string username;
    public TextMeshProUGUI userName;

    [Header("Spawn Players")]
    public GameObject playerPrefab;
    public RectTransform enemyTransform;
    [HideInInspector] public PhotonView view;
    [HideInInspector] public bool isFirst = false;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        if (!newPlayer.IsLocal)
        {
            Debug.Log(PhotonNetwork.CountOfPlayersInRooms);
            var enemy = PhotonNetwork.Instantiate(playerPrefab.name, enemyTransform.position, Quaternion.identity);
            enemy.transform.SetParent(enemyTransform.parent);
            enemy.transform.localScale = Vector3.one;
            isFirst = true;
        }
    }
}
