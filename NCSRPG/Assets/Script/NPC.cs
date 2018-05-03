using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
    public Player m_cPlayer;
    public Player GetPlayer { get { return m_cPlayer; } }

    public void Init()
    {
        m_cPlayer = new Player("NPC");
        ItemManager cItemManager = GameManager.GetInstance().m_cItemManager;

        for (ItemManager.eItem i = 0; i < ItemManager.eItem.MAX; i++)
        {
            m_cPlayer.SetInvetory(cItemManager.GetItem(i));
        }

    }

    //private void OnGUI()
    //{
    //    int nIventorySize = m_cPlayer.GetIventorySize();
    //    int nIventoryWidth = 200;
    //    int nIventoryHeight = 30 * nIventorySize;
    //    GUI.BeginGroup(new Rect(Screen.width/2 - nIventoryWidth/2, Screen.height/2 - nIventorySize/2,
    //                                      nIventoryWidth,nIventoryHeight));

    //    Player cBuyer = GameManager.GetInstance().m_objPlayer.GetComponent<Player>();

    //    for (int i = 0; i < m_cPlayer.GetIventorySize() ; i++)
    //    {
    //        Item sItem = m_cPlayer.GetInvetory(i);
    //        if (GUI.Button(new Rect(0, 30*i, 200, 30), sItem.Name))
    //        {
    //            cBuyer.SetInvetory(sItem);
    //        }
    //    }

    //    GUI.EndGroup();
    //}
}
