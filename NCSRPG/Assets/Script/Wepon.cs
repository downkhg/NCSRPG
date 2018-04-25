using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour {
    bool m_bHit;

    public bool Hit
    {
        get { return m_bHit; }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Monster")
        {
            m_bHit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            m_bHit = false;
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(200, 0, 100, 20), ""+m_bHit);
    }
}
