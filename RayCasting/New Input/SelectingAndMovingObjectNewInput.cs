using UnityEngine;
using UnityEngine.InputSystem;

public class SelectingAndMovingObjectNewInput : MonoBehaviour
{
    [SerializeField]
    private LayerMask objectLayer;
    [SerializeField]
    private LayerMask groundLayer;
    private Transform selectedObject;
    private Vector3 dropPoint;

    private new Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        this.camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //using the old input system as it's simple and MAYBE still more common
        if (Mouse.current.leftButton.isPressed && selectedObject == null)
        {
            //gets a ray from the camera to the mouse - very handy!
            Ray ray = this.camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100, objectLayer))
            {
                //store the selected object
                selectedObject = hit.transform;
            }
        }
        else if (Mouse.current.leftButton.isPressed && selectedObject != null)
        {
            //gets a ray from the camera to the mouse - very handy!
            Ray ray = this.camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100, groundLayer))
            {
                //no duration needed as we are not using GetMouseButtonDown
                Debug.DrawLine(ray.origin, hit.point, Color.red);

                //move the obect and cache the position
                selectedObject.transform.position = hit.point + Vector3.up;
                dropPoint = hit.point;
            }
        }
        //put the object back down
        else if (!Mouse.current.leftButton.isPressed && selectedObject != null)
        {
            selectedObject.transform.position = dropPoint;
            selectedObject = null;
        }
    }
}
