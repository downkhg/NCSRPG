using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject m_objPlayer;
    public GameObject m_objMonster;

	// Use this for initialization
	void Start () {
        m_objPlayer.GetComponent<Player>().Set("Player",100,100,20);
        m_objMonster.GetComponent<Player>().Set("Monster");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
