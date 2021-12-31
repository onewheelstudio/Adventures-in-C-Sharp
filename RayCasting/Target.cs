        using UnityEngine;

        public class Target : MonoBehaviour
        {
            public void GetShot(Vector3 direction)
            {
                Vector3 force = direction * 5 + Vector3.up * 10;
                this.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
                this.transform.parent = null;
            }
        }


