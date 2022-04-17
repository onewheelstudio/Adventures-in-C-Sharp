using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.EventSystems;
public class UIPopup : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    private CanvasGroup cg;    

    private void OnEnable()
    {
        UIPopupOnHover.onPointerEnter += DisplayInfo;
        UIPopupOnHover.onPointerExit += CloseWindow;

        cg = this.GetComponent<CanvasGroup>();
    }

    private void OnDisable()
    {
        UIPopupOnHover.onPointerEnter -= DisplayInfo;
        UIPopupOnHover.onPointerExit -= CloseWindow;
    }

    private void CloseWindow(GameObject obj)
    {
        //fade window out
        cg.DOFade(0, 0.15f);
    }

    private void DisplayInfo(GameObject obj, PointerEventData eventData)
    {
        //set position of the window
        this.transform.position = eventData.position + new Vector2(300, 0);

        //fade window in
        cg.DOFade(1f, 0.15f);

        //set info to display
        text.text = obj.name;
        text.text += $"\n Pos: {obj.transform.position}";
        text.text += $"\n Rot: {obj.transform.rotation.eulerAngles}";
    }
}
