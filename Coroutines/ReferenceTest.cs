using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceTest : MonoBehaviour
{
    Coroutine coroutine;

    // Start is called before the first frame update
    void Start()
    {
        coroutine = StartCoroutine(SomeCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutine == null)
            Debug.Log("Coroutine is null");
        else
            Debug.Log("Coroutine is not null");
    }

    IEnumerator SomeCoroutine()
    {
        yield return new WaitForSeconds(2f);
    }
}
