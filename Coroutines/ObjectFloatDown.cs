using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFloatDown : MonoBehaviour
{
    [SerializeField]
    private float amount = 0.5f;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
        this.transform.position += Vector3.up * amount;
        StartCoroutine(FloatDown());
    }

    IEnumerator FloatDown()
    {
        while(this.transform.position.y > startPosition.y + 0.05f)
        {
            this.transform.position = Vector3.Lerp(this.transform.position,
                                                   startPosition, 0.1f );
            yield return new WaitForSeconds(0.02f);
        }

        this.transform.position = startPosition;
    }
}
