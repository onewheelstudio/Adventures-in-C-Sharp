using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StarWiggle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DoWiggle", Random.Range(0f,0.5f));
    }

    private void DoWiggle()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(this.transform.DORotate(new Vector3(0, 10f, 0), 0.5f));
        sequence.Append(this.transform.DORotate(new Vector3(0, -10f, 0), 1f));
        sequence.Append(this.transform.DORotate(new Vector3(0, 0f, 0), 0.5f));
        sequence.SetLoops(-1);
    }

}
