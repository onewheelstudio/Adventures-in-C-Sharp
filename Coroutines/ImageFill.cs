using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class ImageFill : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Button button;
    [SerializeField]
    private Image image;
    private bool isOn = true;
    private Coroutine currentCoroutine;

    private void OnEnable()
    {
        button = this.GetComponent<Button>();
    }

    IEnumerator FadeToFull()
    {
        while (image.fillAmount < 1f)
        {

            image.fillAmount += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator FadeToEmpty()
    {
        while (image.fillAmount > 0f)
        {

            image.fillAmount -= Time.deltaTime;
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
}
