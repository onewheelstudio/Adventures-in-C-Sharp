using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CoroutineTurnOff : MonoBehaviour
    {

        private Coroutine someCoroutine;

        private void OnDisable()
        {
            //ensure the coroutine stops
            //when the component turns off
            StopCoroutine(AnnoyingCorountine());
            //or
            StopAllCoroutines();
        }

    void Start()
        {
            
        }



    IEnumerator AnnoyingCorountine()
        {
            while(true)
            {
                Debug.Log("I'm still on!");
                yield return null;
            }
        }
    }
