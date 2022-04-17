using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class AddObject : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IUpdateSelectedHandler
{
    [SerializeField]
    private GameObject prefab;
    private GameObject objectBeingPlaced;

    public void OnPointerDown(PointerEventData eventData)
    {
        //create new object when user clicks
        objectBeingPlaced = Instantiate(prefab);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //reset clear object when done
        objectBeingPlaced = null;
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        //check if there is an object to move
        if (objectBeingPlaced != null)
        {
            //create and raycast to a plane
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            plane.Raycast(ray, out float distance);

            //move object to point on plane plus an offset
            objectBeingPlaced.transform.position = ray.GetPoint(distance) + Vector3.up * 1.5f;
        }
    }
    
}
