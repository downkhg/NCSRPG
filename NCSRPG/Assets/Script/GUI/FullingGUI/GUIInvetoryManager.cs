using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIInvetoryManager : MonoBehaviour {
    public Sprite m_spriteSlotNone;
    public Transform m_tranformContent;
    public List<GUIItemSlot> m_listItemSlots;
    public int m_nMaxSlot;
    int m_nItemCount = 0;
    int m_nLastSetIdx = 0;

    public void Set(int idx,Item item)
    {
        m_listItemSlots[idx].Set(item,idx);
        Button btn = m_listItemSlots[idx].gameObject.GetComponent<Button>();
        btn.onClick.AddListener(() => GameManager.GetInstance().m_cGUIManager.EvnetClockItemSlot(idx));
        m_nItemCount++;
        if(m_nLastSetIdx > idx)
            m_nLastSetIdx = idx;
    }

    public void Delete(int idx)
    {
        m_listItemSlots[idx].Delete(m_spriteSlotNone);
        m_nItemCount--;
    }

    public void Initialize()
    {
        m_listItemSlots = new List<GUIItemSlot>(m_nMaxSlot);

        for(int i = 0; i<m_nMaxSlot; i++)
        {
            GameObject prefap = Resources.Load<GameObject>("Prefaps/ItemSlot");
            GameObject instance = Instantiate(prefap);
            instance.transform.SetParent(m_tranformContent);
            GUIItemSlot cItemSlot = instance.GetComponent<GUIItemSlot>();
            
            cItemSlot.Delete(m_spriteSlotNone);
            m_listItemSlots.Add(cItemSlot);
        }
    }

    public void Set(Player player)
    {
        if (player.GetIventorySize() < m_nLastSetIdx+1) return;
        //인벤토리에서는 항상 뒤에 새로운 아이템이 추가되므로,
        //기존에 추가되어있는 인벤토리의 갯수 뒤의 아이템만 추가하면된다.
        int nInvenIdx = m_nItemCount;
        Debug.Log("nInvenIdx:" + nInvenIdx +"/"+ m_nItemCount);
        for (int i = 0; i < m_listItemSlots.Count; i++)
        {
            if (nInvenIdx < player.GetIventorySize()) 
            {
                if (m_listItemSlots[i].GetItem() == null)
                {
                    Item item = player.GetInventory(nInvenIdx);
                    Debug.Log("ItemIdx(" + item.Name + "):" + i +"/"+nInvenIdx );
                    Set(i,item);
                    nInvenIdx++;
                }
            } //인벤토리의 인덱스가 초과하면 반복문을 종료시킨다.
            else break;
            
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0,0,100,20), string.Format("Count:{0}/Last:{1}",m_nItemCount,m_nLastSetIdx) );
    }

    // Use this for initialization
    void Start () {
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
