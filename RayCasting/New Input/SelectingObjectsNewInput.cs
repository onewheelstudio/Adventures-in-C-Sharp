using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectingObjectsNewInput : MonoBehaviour
{
    [SerializeField]
    private LayerMask objectLayer;
    [SerializeField]
    private new Camera camera;

    //color changing
    [SerializeField]
    private Color selectedColor, originalColor;
    private MeshRenderer lastSelected;

    private SelectingActions sa;

    private void Awake()
    {
        sa = new SelectingActions();
    }

    private void OnEnable()
    {
        sa.Player.Select.started += Clicked;
        sa.Player.Select.canceled += Released;
        sa.Player.Enable();
    }

    private void OnDisable()
    {
        sa.Player.Select.started -= Clicked;
        sa.Player.Select.canceled -= Released;
    }


    void Start()
    {
        //caching this to avoid calling Camera.main every time we raycast
        this.camera = Camera.main;
    }


    private void Released(InputAction.CallbackContext obj)
    {
        if (lastSelected != null)
            lastSelected.material.color = originalColor;
    }

    private void Clicked(InputAction.CallbackContext obj)
    {
        //gets a ray from the camera to the mouse - very handy!
        Ray ray = this.camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100, objectLayer))
        {
            //Can also use Draw Ray
            Debug.DrawLine(ray.origin, hit.point, Color.red, 1f);

            //cache material and colors before changing the color
            lastSelected = hit.transform.GetComponent<MeshRenderer>();
            originalColor = lastSelected.material.color;
            lastSelected.material.color = selectedColor;
        }
    }
}


