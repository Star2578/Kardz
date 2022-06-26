using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSelect : MonoBehaviour
{
    private GameObject sentFrom;
    private int chooseFor;
    private Collider2D choosed;
    public LayerMask layer;

    private void Update()
    {
        transform.position = Input.mousePosition;
        if (GameManager.instance.isActive && Input.GetMouseButtonDown(1))
        {
            // cancel action
            GameManager.instance.targetPointer.GetComponent<CircleCollider2D>().enabled = false;
            GameManager.instance.targetPointer.GetComponent<Image>().enabled = false;
            GameManager.instance.isActive = false;
        }

        if (Input.GetMouseButtonDown(0) && choosed != null)
        {
            var targetContainer = GameManager.instance.targetContainer;

            if (!targetContainer.Contains(choosed) && chooseFor != 0)
            {
                targetContainer.Add(choosed);
                choosed = null;
                chooseFor--;

                if (chooseFor == 0)
                {
                    GameManager.instance.targetPointer.GetComponent<CircleCollider2D>().enabled = false;
                    GameManager.instance.targetPointer.GetComponent<Image>().enabled = false;
                    GameManager.instance.isActive = false;
                    sentFrom.SendMessage("AttackPhase");
                }
            }
            else
            {
                CannotSelectTarget();
            }
        }
    }

    private void SelectTargetFor(int count)
    {
        chooseFor = count;
    }

    private void PointerVisual(GameObject from)
    {
        sentFrom = from;
    }

    private void CannotSelectTarget()
    {
        Debug.Log("Can't choose that!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent != GameManager.instance.dropZone && other.IsTouchingLayers(layer))
        {
            choosed = other;
        }
        else
        {
            choosed = null;
        }
    }
}
