using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ChangingValueUpdate : MonoBehaviour
{
    [SerializeField]
    private Text countText;
    private int count;
    private float time;

    // Update is called once per frame
    void Update()
    {
        DoTimer();
    }

    private void DoTimer(float countTime = 1f)
    {
        time += Time.deltaTime;
        if (time >= countTime)
        {
            count++;
            countText.text = count.ToString();
            time = 0;
        }
    }
}
