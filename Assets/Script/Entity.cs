using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Stats")]
    public int health = 0;
    public int attack = 0;

    [Header("Targeting Arrow")]
    public Target casterType;
    public Transform spawnOffset;
    [HideInInspector] public bool isTargeting = false;
    [HideInInspector] public GameObject arrowObject;

    public bool isTargetable = true;
    [Header("Special")]
    public int waitTurn = 1;
    public bool taunt = false;

    public bool Death() => health <= 0;
    public bool CanAttack() => GameManager.instance.isOurTurn && waitTurn == 0 && casterType == Target.FRIENDLIES;
    public bool CantAttack() => GameManager.instance.isOurTurn && waitTurn > 0 && casterType == Target.FRIENDLIES;

    public virtual void Update()
    {

    }
}
