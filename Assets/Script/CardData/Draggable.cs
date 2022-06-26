using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler , IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private RectTransform moveUp;

    public Transform setParentTo;
    public Transform placeHolderParent;
    private GameObject placeHolder = null;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (GameManager.instance.canLook)
        {
            this.transform.localScale = Vector3.one * 2;
            moveUp.transform.localPosition = new Vector3(0, 100, 0);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.localScale = Vector3.one;
        moveUp.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("BeginDrag");
        GameManager.instance.canLook = false;

        placeHolder = Instantiate(GameManager.instance.cardPf);
        placeHolder.name = "placeholder";
        placeHolder.transform.SetParent(this.transform.parent);
        LayoutElement layoutElement = placeHolder.GetComponent<LayoutElement>();
        layoutElement.preferredHeight = 0;
        layoutElement.preferredWidth = 0;
        placeHolder.SetActive(true);
        placeHolder.GetComponent<RectTransform>().sizeDelta = GameManager.instance.cardPf.GetComponent<RectTransform>().sizeDelta;
        placeHolder.GetComponent<RectTransform>().localScale = GameManager.instance.cardPf.GetComponent<RectTransform>().localScale;
        placeHolder.GetComponent<RectTransform>().position = GameManager.instance.cardPf.GetComponent<RectTransform>().position;
        placeHolder.GetComponent<CanvasGroup>().alpha = 0;
        placeHolder.GetComponent<CanvasGroup>().blocksRaycasts = false;

        placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        setParentTo = this.transform.parent;
        placeHolderParent = setParentTo;
        this.transform.SetParent(this.transform.parent.parent); // set parent to canvas

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;

        if (placeHolder.transform.parent != placeHolderParent)
            placeHolder.transform.SetParent(placeHolderParent);

        for (int i = 0; i < placeHolderParent.childCount; i++)
        {
            if (this.transform.position.x < placeHolderParent.GetChild(i).position.x)
            {
                // Debug.Log(i);
                placeHolder.transform.SetSiblingIndex(i);
                break;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("EndDrag");
        GameManager.instance.canLook = true;

        this.transform.SetParent(setParentTo);
        this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Destroy(placeHolder);

        if (this.transform.parent == GameManager.instance.dropZone)
        {
            var summon = Instantiate(GameManager.instance.cardSummonedPf);

            summon.SetActive(true);
            summon.transform.SetParent(this.transform.parent);
            summon.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
            summon.GetComponent<CardDisplay>().card = this.GetComponent<CardDisplay>().card;
            summon.GetComponent<RectTransform>().sizeDelta = GameManager.instance.cardSummonedPf.GetComponent<RectTransform>().sizeDelta;
            summon.GetComponent<RectTransform>().localScale = GameManager.instance.cardSummonedPf.GetComponent<RectTransform>().localScale;
            summon.GetComponent<RectTransform>().position = GameManager.instance.cardSummonedPf.GetComponent<RectTransform>().position;
            Destroy(gameObject);

            var cardCost = summon.GetComponent<CardDisplay>().card.cost;
            if (cardCost <= GameManager.instance.currMana)
            {
                summon.SendMessage("Summon");
                GameManager.instance.currMana -= cardCost;
            }
            else
            {
                summon.SendMessage("ReturnToHand", summon.GetComponent<CardDisplay>().card);
            }
        }
    }
}
