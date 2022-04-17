using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UIDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 startScale;
    private Vector2 offset;

    void Start()
    {
        startScale = this.transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.DOScale(startScale * 1.1f, 0.25f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.DOScale(startScale, 0.25f);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
        this.transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.transform.position = eventData.position - offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        FindObjectOfType<SFXManager>().PlayEndDrag();
    }

}
