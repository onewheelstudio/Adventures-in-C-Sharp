        using UnityEngine;

        public class FlyingCube : MonoBehaviour
        {
            private new Camera camera;
    
            void Start()
            {
                this.camera = Camera.main;
            }

            void Update()
            {
                //using the old input system as it's simple and MAYBE still more common
                if (Input.GetMouseButton(0))
                {
                    //gets a ray from the camera to the mouse - very handy!
                    Ray ray = this.camera.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out RaycastHit hit, 100))
                    {
                        //creates flying cube!!! Don't do this!
                        hit.transform.position = hit.point;
                    }
                }
            }
        }
