using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        //set the parent when inventory item is dropped on the slot
        eventData.pointerDrag.transform.SetParent(this.transform);
    }
}