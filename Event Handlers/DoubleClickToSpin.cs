using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class DoubleClickToSpin : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 startScale;

    void Start()
    {
        //cache the scale of the object
        startScale = this.transform.localScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //set selected object
        EventSystem.current.SetSelectedGameObject(this.gameObject);

        //compare count click and do tween if double clicked
        if (eventData.clickCount == 2)
            this.transform.DOShakeRotation(1f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //animate on point hover
        this.transform.DOScale(startScale * 1.1f, 0.15f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //animate on pointer exit
        this.transform.DOScale(startScale, 0.15f);
    }
}
