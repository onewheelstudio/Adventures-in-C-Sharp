            using UnityEngine;

            //no movement. just aiming using POV from cinemachine
            public class FirstPersonTargetShooting : MonoBehaviour
            {
                [SerializeField]
                private GameObject flashPoof; //has SFX, light and particles

                private new Camera camera;
    
                void Start()
                {
                    this.camera = Camera.main;
                    Cursor.visible = false;
                }

                void Update()
                {
                    if(Input.GetMouseButtonDown(0))
                    {
                        Ray ray = new Ray(camera.transform.position, camera.transform.forward);

                        if(Physics.Raycast(ray,out RaycastHit hit,100f))
                        {
                            if (hit.transform.TryGetComponent<Target>(out Target ts))
                                ts.GetShot(ray.direction);

                            Instantiate(flashPoof, hit.point, Quaternion.identity);
                        }    
                    }
                }
            }


