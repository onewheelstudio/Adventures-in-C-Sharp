using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWithUpdate : MonoBehaviour
{
    [SerializeField]
    private float lerpSpeed = 0.1f;
    [SerializeField]
    private Vector3 nextPosition;

    // Start is called before the first frame update
    void Start()
    {
        nextPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                nextPosition = hit.collider.transform.position;
                nextPosition.y = 0;
            }
        }

        float distanceToTarget = (this.transform.position - nextPosition).sqrMagnitude;
        if (distanceToTarget > 0.01f)
            MoveObject(nextPosition);
    }

    private Vector3 MoveObject(Vector3 targetLocation)
    {
        this.transform.position = Vector3.Lerp(this.transform.position, targetLocation, lerpSpeed);

        return this.transform.position;
    }
}
