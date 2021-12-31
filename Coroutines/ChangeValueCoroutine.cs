using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ChangeValueCoroutine : MonoBehaviour
{
    [SerializeField]
    private Text countText;
    
    // Start is called before the first frame update
    void Start()
    {


        StartCoroutine(DoTimer());

    }

    private void OnDisable()
    {
        StopCoroutine(DoTimer());
    }

    IEnumerator DoTimer(float countTime = 1f)
    {
        int count = 0;
        while(true)
        {
            yield return new WaitForSeconds(countTime);
            count++;
            countText.text = count.ToString();
        }
    }
}
