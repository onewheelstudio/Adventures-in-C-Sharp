    using UnityEngine;
    using UnityEngine.InputSystem;
    using Cinemachine;

    public class InputHandler : MonoBehaviour, AxisState.IInputAxisProvider
    {
        [HideInInspector]
        public InputAction horizontal;
        [HideInInspector]
        public InputAction vertical;


    public float GetAxisValue(int axis)
        {
            switch (axis)
            {
                case 0: return horizontal.ReadValue<Vector2>().x;
                case 1: return horizontal.ReadValue<Vector2>().y;
                case 2: return vertical.ReadValue<float>();
            }

            return 0;
        }
    }


