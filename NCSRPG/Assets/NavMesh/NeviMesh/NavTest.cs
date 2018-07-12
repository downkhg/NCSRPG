using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavTest : MonoBehaviour {
    public GameObject m_objPlayer;
    public GameObject m_prefapMonster;
    public GameObject[] m_objDummy;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 3; i++)
        {
            GameObject obj = Instantiate(m_prefapMonster,m_objDummy[i].transform.position,Quaternion.identity,null);
            obj.GetComponent<NavMeshTest>().m_objTarget = m_objPlayer;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
