        using UnityEngine;

        public class SelectingObjects : MonoBehaviour
        {
            [SerializeField]
            private LayerMask objectLayer;
            [SerializeField]
            private new Camera camera;

            //color changing
            [SerializeField]
            private Color selectedColor, originalColor;
            private MeshRenderer lastSelected;

            void Start()
            {
                //caching this to avoid calling Camera.main every time we raycast
                this.camera = Camera.main;
            }

            void Update()
            {
                //using the old input system as it's simple and MAYBE still more common
                if (Input.GetMouseButtonDown(0))
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
                //change the color back to the original
                else if (Input.GetMouseButtonUp(0) && lastSelected != null)
                    lastSelected.material.color = originalColor;
            }
        }


