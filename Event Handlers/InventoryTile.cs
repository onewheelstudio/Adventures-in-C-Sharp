using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryTile : MonoBehaviour, IBeginDragHandler,IEndDragHandler, IDragHandler
{
    private Vector2 offset;
    private Transform startingSlot;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //cache parent in case of cancel
        startingSlot = transform.parent;

        //unparent from inventory slot and set to last sibiling
        this.transform.SetParent(this.transform.parent.root);
        this.transform.SetAsLastSibling();

        //get offset to keep object/mouse position relative
        offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
        
        //turn off raycast target so OnDrop on inventory slot can work correctly
        this.GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //move the object with mouse
        this.transform.transform.position = eventData.position - offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //toggle raycast target back on
        this.GetComponent<Image>().raycastTarget = true;
        FindObjectOfType<SFXManager>().PlayEndDrag();

        //if not dropped on an inventory slot - reparent to starting slot
        if(this.transform.parent.GetComponent<InventorySlot>() == null) //in case of not being dropped on a slot
            this.transform.SetParent(startingSlot);
    }
}