using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    public GameObject m_objSelect;
    public GameObject m_objList;

    public Text m_textListTitle;
    public RectTransform m_rectListContent;
    public GridLayoutGroup m_gridListLayout;
    public List<GameObject> m_listButton;

    public void SetList(Player target, bool buy)
    {
        ReleaseList();
        m_textListTitle.text = target.Name;
        int nSize = target.GetIventorySize();
        for (int i = 0; i < target.GetIventorySize(); i++)
        {
            GameObject objButton =  Instantiate(Resources.Load("Prefaps/Button") as GameObject);
            Text text = objButton.transform.Find("Text").GetComponent<Text>();
            text.text = target.GetInvetory(i).Name;
            if (text)
                m_listButton.Add(objButton);
            else
                Debug.LogError("Button Text Not Find");
            objButton.transform.SetParent(m_rectListContent.gameObject.transform);

            Button button = objButton.GetComponent<Button>();
            int nSelectIdx = i;
            if(buy)
                button.onClick.AddListener(() => EventButtonBuy(nSelectIdx));
            else
                button.onClick.AddListener(() => EventButtonSell(nSelectIdx));
        }
        int nContextHight = nSize * (int)(m_gridListLayout.cellSize.y + m_gridListLayout.spacing.y);
        m_rectListContent.sizeDelta = new Vector3(m_rectListContent.sizeDelta.x, nContextHight);
    }

    public void DeleteButton(int idx)
    {
        GameObject obj = m_listButton[idx].gameObject;
        Destroy(m_listButton[idx].gameObject);
        m_listButton.Remove(obj);
    }

    public void ReleaseList()
    {
        int nSize = m_listButton.Count;
        for (int i = nSize-1;  i >= 0; i--)
        {
            Destroy(m_listButton[i].gameObject);
        }
        m_listButton.Clear();
    }

    //private void OnGUI()
    //{
    //    if(GUI.Button(new Rect(0,100,100,100),""))
    //    {
    //        Player cPlayer = GameManager.GetInstance().m_cNPC.m_cPlayer;
    //        SetList(cPlayer);
    //    }
    //}

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EventButtonBuy(int idx)
    {
        Player cNPC = GameManager.GetInstance().m_cNPC.m_cPlayer;
        Player cPlayer = GameManager.GetInstance().m_objPlayer.GetComponent<Dynamic>().m_cPlayer;

        cPlayer.Buy(idx, cNPC);
        Debug.Log("Buy:"+idx);
    }

    public void EventButtonSell(int idx)
    {
        Player cPlayer = GameManager.GetInstance().m_objPlayer.GetComponent<Dynamic>().m_cPlayer;
        cPlayer.Sell(idx);
        SetList(cPlayer, false);
        Debug.Log("Sell:" + idx);
    }

    public void EventBuy()
    {
        m_objSelect.SetActive(false);
        m_objList.SetActive(true);
        Player cPlayer = GameManager.GetInstance().m_cNPC.m_cPlayer;
        SetList(cPlayer,true);
    }

    public void EventSell()
    {
        m_objSelect.SetActive(false);
        m_objList.SetActive(true);
        Player cPlayer = GameManager.GetInstance().m_objPlayer.GetComponent<Dynamic>().m_cPlayer;
        SetList(cPlayer,false);
    }

    public void EventExit()
    {
        m_objList.SetActive(false);
        m_objSelect.SetActive(false);
    }

    public void EventCloseList()
    {
        m_objList.SetActive(false);
        m_objSelect.SetActive(true);
        ReleaseList();
    }

}
