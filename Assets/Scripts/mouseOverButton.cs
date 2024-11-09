using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class mouseOverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler// required interface when using the OnPointerEnter method.
{
    RectTransform m_rectTransform;
    public float yTransform;

    public void Start()
    {
        m_rectTransform = GetComponent<RectTransform>();
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        m_rectTransform.anchoredPosition = new Vector2(m_rectTransform.anchoredPosition.x, -50);
    }


    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        m_rectTransform.anchoredPosition = new Vector2(m_rectTransform.anchoredPosition.x, yTransform);
    }


}