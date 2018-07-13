using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIBarStatus : MonoBehaviour {
    public Image m_imgMaskLayer;
    public GameObject m_objBackground;

    public void SetHP(float cur, float max)
    {
        RectTransform rectBG = m_objBackground.GetComponent<RectTransform>();
        Vector2 vOriginSize = rectBG.sizeDelta;
        Vector2 vMaskSize = m_imgMaskLayer.gameObject.GetComponent<RectTransform>().sizeDelta;
        float fRat = cur / max;
        vMaskSize.Set(vOriginSize.x * fRat, vOriginSize.y);
        m_imgMaskLayer.gameObject.GetComponent<RectTransform>().sizeDelta = vMaskSize;
    }
}
