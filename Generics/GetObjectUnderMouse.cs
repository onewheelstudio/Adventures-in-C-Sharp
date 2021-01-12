using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetObjectUnderMouse : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI displayText;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //this is not particularly efficent...
            //it's just an example of how to call a generic function
            if (IsShapeUnderMouse<Cube>())
            {
                displayText.text = "Shape Under the Mouse: Cube!!";
                return;
            }
            else if(IsShapeUnderMouse<Sphere>())
            {
                displayText.text = "Shape Under the Mouse: Sphere!!";
                return;
            }
            else if (IsShapeUnderMouse<Capsule>())
            {
                displayText.text = "Shape Under the Mouse: Capsule!!";
                return;
            }
        }
    }

    private bool IsSphereUnderMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out RaycastHit hit))
        {
            if (hit.collider != null && hit.collider.GetComponent<Sphere>() != null)
                return true;
        }

        return false;
    }

    private bool IsCubeUnderMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider != null && hit.collider.GetComponent<Cube>() != null)
                return true;
        }

        return false;
    }

    private bool IsCapsuleUnderMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider != null && hit.collider.GetComponent<Capsule>() != null)
                return true;
        }

        return false;
    }

    private bool IsShapeUnderMouse<T>() where T : Component
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider != null && hit.collider.GetComponent<T>() != null)
                return true;
        }

        return false;
    }
}
