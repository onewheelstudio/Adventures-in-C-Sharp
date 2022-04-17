using UnityEngine;
using UnityEngine.EventSystems;

public class UIPopupOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static System.Action<GameObject, PointerEventData> onPointerEnter;
    public static System.Action<GameObject> onPointerExit;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //invoke event when pointer hovers
        onPointerEnter?.Invoke(this.gameObject, eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //invoke event when pointer stops hovering
        onPointerExit.Invoke(this.gameObject);
    }
}
