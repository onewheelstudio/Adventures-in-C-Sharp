using System;
using UnityEngine;
using UnityEngine.InputSystem;

//no movement. just aiming using POV from cinemachine
public class FirstPersonTargetShootingNewInput : MonoBehaviour
{
    [SerializeField]
    private GameObject flashPoof; //has SFX, light and particles

    private new Camera camera;

    private ShootingActions sa;

    private void Awake()
    {
        sa = new ShootingActions();
    }

    private void OnEnable()
    {
        sa.Player.Shoot.performed += Shoot;
        sa.Player.Enable();
    }

    private void OnDisable()
    {
        sa.Player.Shoot.performed -= Shoot;
    }

    void Start()
    {
        this.camera = Camera.main;
        Cursor.visible = false;
    }

    private void Shoot(InputAction.CallbackContext obj)
    {
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            if (hit.transform.TryGetComponent<Target>(out Target ts))
                ts.GetShot(ray.direction);

            Instantiate(flashPoof, hit.point, Quaternion.identity);
        }
    }

}


