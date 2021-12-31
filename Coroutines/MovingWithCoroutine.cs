using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWithCoroutine : MonoBehaviour
{
    [SerializeField]
    private float lerpSpeed = 0.1f;
    private Coroutine moveCoroutine;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if(moveCoroutine != null)
                    StopCoroutine(moveCoroutine);

                moveCoroutine = StartCoroutine(DoMove(hit.collider.transform.position));
            }
        }
    }

    IEnumerator DoMove(Vector3 targetLocation)
    {
        float distanceToTarget = (this.transform.position - targetLocation).sqrMagnitude;
        while (distanceToTarget > 0.01f)
        {
            this.transform.position = Vector3.Lerp(this.transform.position,
                                                    targetLocation,
                                                    lerpSpeed);
            yield return null;
        }
    }
}
