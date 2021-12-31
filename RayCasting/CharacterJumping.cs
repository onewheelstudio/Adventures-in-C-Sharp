        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;

        public class CharacterJumping : MonoBehaviour
        {
            private Rigidbody rb;
            [SerializeField]
            private LayerMask groundLayer;

            private void Start()
            {
                rb = this.GetComponent<Rigidbody>();
            }

            // Update is called once per frame
            void Update()
            {
                if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
                    rb.AddForce(Vector3.up * 8, ForceMode.Impulse);
            }

            private bool IsGrounded()
            {
                Ray ray = new Ray(this.transform.position, Vector3.down);
        
                Debug.DrawLine(ray.origin, ray.origin + Vector3.down * 1.1f, Color.red, 2f);

                //the distance cast depends on the size of the character
                //it's intended to exten just below the bottom of the character
                return Physics.Raycast(ray, 1.1f, groundLayer);
            }
        }
