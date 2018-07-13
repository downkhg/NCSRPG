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

    public void SetList(Player target, bool buy) //플레이어의 인벤토리의 아이템을 보여줌.
    {
        ReleaseList(); //이전에 추가된 목록이 있다면 모두 삭제
        m_textListTitle.text = target.Name; //제목 플레이어의 이름으로 변경
        int nSize = target.GetIventorySize();
        for (int i = 0; i < nSize; i++)
        {
            GameObject objButton =  Instantiate(Resources.Load("Prefaps/Button") as GameObject);
            //버튼의 자식객체중에 "Text"게임오브젝트를 찾아서 그 오브젝트의 UI Text스크립트를 가져옴.
            Text text = objButton.transform.Find("Text").GetComponent<Text>();
            text.text = target.GetInvetory(i).Name;
            if (text)
                m_listButton.Add(objButton);
            else
                Debug.LogError("Button Text Not Find");
            //버튼을 컨텍스트의 자식으로 변경해서 레이아웃이 적용되도록한다.
            objButton.transform.SetParent(m_rectListContent.gameObject.transform);

            Button button = objButton.GetComponent<Button>();
            //i는 반복문이 수행되는동안 존제하는 함수이므로 값을 넘겼을때 참조해서 값이 넘어가게된다.
            int nSelectIdx = i;//그러나 for{}안에 nSelectIdx는 지역변수이므로, 매루프마다 새롭게 생성된다. 그러므로 참조할수없게된다.
            if(buy)
                button.onClick.AddListener(() => EventButtonBuy(nSelectIdx));//버튼의 기능을 동적으로 추가함.
            else
                button.onClick.AddListener(() => EventButtonSell(nSelectIdx));
        }
        //컨텍스트의 사이즈를 버튼의 크기와 여백에 맞도록 수정.
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
        //배열을 삭제할때 첫번째부터 삭제를 하면 계속 원소의 인덱스가 변경되어 원하지않는 결과를 만든다.
        //그러므로, 원소를 뒤에서 부터삭제하면 문제가 없이 삭제할수있다.
        int nSize = m_listButton.Count;
        for (int i = nSize-1;  i >= 0; i--)
            Destroy(m_listButton[i].gameObject); //동적생성된 게임오브젝트는 가비지에의해 관리되지않음. 그러므로 반드시 그 오브젝트를 직접삭제해야한다.
        m_listButton.Clear();
    }

    public Joystick m_cJoystick;
    public GUIBarStatus m_cHPStatus;
    public GUIBarStatus m_cSpeedStatus;

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
        Debug.Log("Buy:" + idx);
        cPlayer.Buy(idx, cNPC);
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
