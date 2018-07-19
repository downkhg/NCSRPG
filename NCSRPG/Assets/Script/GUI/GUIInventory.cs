using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIInventory : MonoBehaviour {
    public Transform m_transContent;
    public GameObject[] m_listButtons;

	// Use this for initialization
	void Start () {
        m_listButtons = m_transContent.GetComponentsInChildren<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetList(string datas)
    {

    }
}
