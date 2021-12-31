using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class MoveSlider : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Button button;
    [SerializeField]
    private Slider slider;
    private bool isOn = true;
    private Coroutine currentCoroutine;

    private void Start()
    {
        //Strings? Yuck!
        StartCoroutine("ImACoroutine");
        //This works too
        StartCoroutine(ImACoroutine());
    }

    private void OnEnable()
    {
        button = this.GetComponent<Button>();
    }

    IEnumerator FadeToFull()
    {
        while (slider.value < 1f)
        {

            slider.value += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator FadeToEmpty()
    {
        while (slider.value > 0f)
        {

            slider.value -= Time.deltaTime;
            yield return null;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(FadeToFull());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(FadeToEmpty());
    }

    IEnumerator ImACoroutine()
    {
        //do stuff
        yield return new WaitForSeconds(1f);
        //do more stuff after one second
    }
}
