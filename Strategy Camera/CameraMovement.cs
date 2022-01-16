    using UnityEngine;
    using UnityEngine.InputSystem;
    using Sirenix.OdinInspector;

    public class CameraMovement : MonoBehaviour
    {
        private CameraControls cameraActions;
        private InputAction movement;
        private Transform cameraTransform;

        [BoxGroup("Horizontal Translation")]
        [SerializeField]
        private float maxSpeed = 5f;
        private float speed;
        [BoxGroup("Horizontal Translation")]
        [SerializeField]
        private float acceleration = 10f;
        [BoxGroup("Horizontal Translation")]
        [SerializeField]
        private float damping = 15f;

        [BoxGroup("Vertical Translation")]
        [SerializeField]
        private float stepSize = 2f;
        [BoxGroup("Vertical Translation")]
        [SerializeField]
        private float elevateDamping = 7.5f;
        [BoxGroup("Vertical Translation")]
        [SerializeField]
        private float minHeight = 5f;
        [BoxGroup("Vertical Translation")]
        [SerializeField]
        private float maxHeight = 50f;
        [BoxGroup("Vertical Translation")]
        [SerializeField]
        private float zoomSpeed = 2f;

        [BoxGroup("Rotation")]
        [SerializeField]
        private float maxRotationSpeed = 1f;

        [BoxGroup("Edge Movement")]
        [SerializeField]
        [Range(0f,0.1f)]
        private float edgeTolerance = 0.05f;

        //value set in various functions 
        //used to update the position of the camera base object.
        private Vector3 targetPosition;

        //used to track and maintain velocity w/o a rigidbody
        private Vector3 horizontalVelocity;
        private Vector3 lastPosition;

        //tracks where the dragging action started
        Vector3 startDrag;

        private void Awake()
        {
            cameraActions = new CameraControls();
            cameraTransform = this.GetComponentInChildren<Camera>().transform;
        }

        private void OnEnable()
        {
            cameraTransform.LookAt(this.transform);

            lastPosition = this.transform.position;

            movement = cameraActions.Camera.MoveCamera;
            cameraActions.Camera.RotateCamera.performed += RotateCamera;
            cameraActions.Camera.EvalateCamera.performed += ElevateCamera;
            cameraActions.Camera.Enable();
        }

        private void OnDisable()
        {
            cameraActions.Camera.RotateCamera.performed -= RotateCamera;
            cameraActions.Camera.EvalateCamera.performed -= ElevateCamera;
            cameraActions.Camera.Disable();
        }

        private void Update()
        {
            //inputs
            GetKeyboardMovement();
            CheckMouseAtScreenEdge();
            DragCamera();

            //move base and camera objects
            UpdateVelocity();
            UpdateBasePosition();
        }

        private void UpdateVelocity()
        {
            horizontalVelocity = (this.transform.position - lastPosition) / Time.deltaTime;
            horizontalVelocity.y = 0f;
            lastPosition = this.transform.position;
        }

        private void GetKeyboardMovement()
        {
            Vector3 inputValue = movement.ReadValue<Vector2>().x * GetCameraRight()
                        + movement.ReadValue<Vector2>().y * GetCameraForward();

            inputValue = inputValue.normalized;

            if (inputValue.sqrMagnitude > 0.1f)
                targetPosition += inputValue;
        }

        private void DragCamera()
        {
            if (!Mouse.current.rightButton.isPressed)
                return;

            //create plane to raycast to
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        
            if(plane.Raycast(ray, out float distance))
            {
                if (Mouse.current.rightButton.wasPressedThisFrame)
                    startDrag = ray.GetPoint(distance);
                else
                    targetPosition += startDrag - ray.GetPoint(distance);
            }
        }

        private void CheckMouseAtScreenEdge()
        {
            //mouse position is in pixels
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector3 moveDirection = Vector3.zero;

            //horizontal scrolling
            if (mousePosition.x < edgeTolerance * Screen.width)
                moveDirection += -GetCameraRight();
            else if (mousePosition.x > (1f - edgeTolerance) * Screen.width)
                moveDirection += GetCameraRight();

            //vertical scrolling
            if (mousePosition.y < edgeTolerance * Screen.height)
                moveDirection += -GetCameraForward();
            else if (mousePosition.y > (1f - edgeTolerance) * Screen.height)
                moveDirection += GetCameraForward();

            targetPosition += moveDirection;
        }

        private void UpdateBasePosition()
        {
            if (targetPosition.sqrMagnitude > 0.1f)
            {
                //create a ramp up or acceleration
                speed = Mathf.Lerp(speed, maxSpeed, Time.deltaTime * acceleration);
                transform.position += targetPosition * speed * Time.deltaTime;
            }
            else
            {
                //create smooth slow down
                horizontalVelocity = Vector3.Lerp(horizontalVelocity, Vector3.zero, Time.deltaTime * damping);
                transform.position += horizontalVelocity * Time.deltaTime;
            }

            //reset for next frame
            targetPosition = Vector3.zero;
        }

        private void ElevateCamera(InputAction.CallbackContext obj)
        {
            float inputValue = -obj.ReadValue<Vector2>().y / 100f;
            float targetHeight = cameraTransform.position.y + inputValue * stepSize;

            if (Mathf.Abs(inputValue) > 0.1f)
            {
                if (targetHeight < minHeight)
                    targetHeight = minHeight;
                else if (targetHeight > maxHeight)
                    targetHeight = maxHeight;
            }

            //set height target
            Vector3 targetLocation = new Vector3(cameraTransform.position.x, targetHeight, cameraTransform.position.z);
            //add vector for forward/backward zoom
            targetLocation -= zoomSpeed * (targetHeight - cameraTransform.position.y) * cameraTransform.forward;

            cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetLocation, Time.deltaTime * elevateDamping);
            cameraTransform.LookAt(this.transform);
        }

        private void RotateCamera(InputAction.CallbackContext obj)
        {
            if (!Mouse.current.middleButton.isPressed)
                return;

            float inputValue = obj.ReadValue<Vector2>().x;
            transform.rotation = Quaternion.Euler(0f, inputValue * maxRotationSpeed + transform.rotation.eulerAngles.y, 0f);

        }

        //gets the horizontal forward vector of the camera
        private Vector3 GetCameraForward()
        {
            Vector3 forward = cameraTransform.forward;
            forward.y = 0f;
            return forward;
        }

        //gets the horizontal right vector of the camera
        private Vector3 GetCameraRight()
        {
            Vector3 right = cameraTransform.right;
            right.y = 0f;
            return right;
        }
    }
