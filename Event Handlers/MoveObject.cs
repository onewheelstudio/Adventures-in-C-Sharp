using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MoveObject : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IUpdateSelectedHandler, ICancelHandler
{
    private Vector3 startLocation;

    public void OnPointerDown(PointerEventData eventData)
    {
        //cache the start location in case of canceling
        startLocation = this.transform.position;
        //For scene objects we need to set the selected object
        EventSystem.current.SetSelectedGameObject(this.gameObject);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //When done "unselect" object
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void OnCancel(BaseEventData eventData)
    {
        //put object back if canceled
        this.transform.position = startLocation;
        //"unselect" object
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        //create and raycast to plane
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        plane.Raycast(ray, out float distance);

        //move object to point on plane
        this.transform.position = ray.GetPoint(distance) + Vector3.up * 1.5f;
    }
}
