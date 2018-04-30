using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject m_objPlayer;
    public List<GameObject> m_listMonsters;

    public Transform m_cDeadDumy;

	// Use this for initialization
	void Start () {
        m_objPlayer.GetComponent<Player>().Set("Player",100,100,20,10,9);

        for (int i = 0; i < m_listMonsters.Count; i++)
        {
            Player cMonster = m_listMonsters[i].GetComponent<Player>();
            cMonster.Set(string.Format("Monster{0}", i));
            cMonster.m_nDebugStatusStartX = 100 *( i+1);
        }
    }
	
	// Update is called once per frame
	void Update () {
        Dynamic cPlayerDynamic = m_objPlayer.GetComponent<Dynamic>();
        Player cPlayer = m_objPlayer.GetComponent<Player>();
        cPlayerDynamic.SphereCollisionProcess(m_listMonsters);

        for (int i = 0; i < m_listMonsters.Count; i++)
        {
            NPCNavTarcking cNavTracking = m_listMonsters[i].GetComponent<NPCNavTarcking>();
            Player cMonster = m_listMonsters[i].GetComponent<Player>();

            cNavTracking.SphereCollisionProcess(m_objPlayer);
            if (cMonster.Dead())
            {
                m_listMonsters[i].SetActive(false);
                m_listMonsters[i].transform.position = m_cDeadDumy.position;
            }
        }
    }
}
