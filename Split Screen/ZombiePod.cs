using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePod : MonoBehaviour
{
    [SerializeField]
    private GameObject zombie;
    private void OnCollisionEnter(Collision collision)
    {
        zombie.SetActive(true);
        zombie.transform.parent = null;
        this.gameObject.SetActive(false);
    }
}
