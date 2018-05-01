using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject m_objPlayer;
    public List<GameObject> m_listMonsters;
    public ResponManager m_cResponManager;
    public int m_nMonsterMax;

    public Transform m_cDeadDumy;

	// Use this for initialization
	void Start () {
        m_objPlayer.GetComponent<Player>().Set("Player",100,100,20,10,9);
        m_listMonsters = new List<GameObject>(m_nMonsterMax);

        for (int i = 0; i < m_nMonsterMax; i++)
        {
            GameObject prefapMonster = Resources.Load("Prefaps/Monster") as GameObject;
            GameObject objMonster =  Instantiate(prefapMonster);
            Player cMonster = objMonster.GetComponent<Player>();

            string name = string.Format("Monster{0}", i);
            cMonster.Set(name);
            cMonster.m_nDebugStatusStartX = 100 *( i+1);
            m_cResponManager.SetResponPoint(i, objMonster);
            Debug.Log(m_objPlayer.transform.position);
            cMonster.name = name+ objMonster.transform.position;
            //cMonster.GetComponent<Rigidbody>().isKinematic = false;
            m_listMonsters.Add(objMonster);
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
