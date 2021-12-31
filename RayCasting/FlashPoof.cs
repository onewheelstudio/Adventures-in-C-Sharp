using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashPoof : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitOneSecond());
    }

    IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<Light>().enabled = false;
    }
}
