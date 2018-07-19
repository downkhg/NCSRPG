using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIItemSlot : MonoBehaviour {
    public Image m_cImage;
    public Text m_cText;
    Sprite m_spriteImage;
    Item m_cItem;

    public Item GetItem()
    {
        return m_cItem;
    }

    public void Set(Item item)
    {
        //m_spriteImage = Resources.Load<Sprite>(""+m_cItem.Name);
        m_cImage.sprite = m_spriteImage;
        m_cText.text = item.Name;
        m_cItem = item;
    }

    public void Delete(Sprite none)
    {
        m_cItem = null;
        m_cText.text = "";
        m_cImage.sprite = none;
        Destroy(m_spriteImage); 
    }
}
