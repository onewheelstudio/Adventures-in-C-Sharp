using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class was used in the demo to disable objects
/// so they would be returned to the pool
/// </summary>
public class DisableObjects : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        collider.gameObject.SetActive(false);
    }
}
