using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using Cinemachine;


/// <summary>
/// This is an add-on to override the legacy input system and read input using the
/// UnityEngine.Input package API.  Add this behaviour to any CinemachineVirtualCamera 
/// or FreeLook that requires user input, and drag in the the desired actions.
/// </summary>
public class CinemachineInputHandler : MonoBehaviour, AxisState.IInputAxisProvider
{
    [HideInInspector]
    public InputAction look;

    public float GetAxisValue(int axis)
    {
        switch (axis)
        {
            case 0: return look.ReadValue<Vector2>().x;
            case 1: return look.ReadValue<Vector2>().y;
            case 2: return look.ReadValue<float>();
        }

        return 0;
    }
}
