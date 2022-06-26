using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private int space;
    [SerializeField] private int offset;
    private HorizontalLayoutGroup horizontalLayoutGroup;

    private void Start()
    {
        horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
    }

    private void Update()
    {
        horizontalLayoutGroup.spacing = space;
        horizontalLayoutGroup.spacing += offset * this.gameObject.transform.childCount;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Debug.Log("Enter " + gameObject.name);
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.placeHolderParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Debug.Log("Exit " + gameObject.name);
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && d.placeHolderParent != this.transform)
        {
            d.placeHolderParent = d.setParentTo;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        // Debug.Log("Drop to " + gameObject.name);
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.setParentTo = this.transform;
        }
    }
}
