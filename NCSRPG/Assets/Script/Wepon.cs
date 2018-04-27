using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour {
    bool m_bHit;
    Collider m_cCollider;
    Arm m_cArm;

    public Collider GetCollider()
    {
        return m_cCollider;
    }

    public bool Hit
    {
        get { return m_bHit; }
    }

    public void InitArm(Arm arm)
    {
        m_cArm = arm;
    }

	// Use this for initialization
	void Start () {
        m_cCollider = GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Monster")
        {
            m_bHit = true;
            m_cArm.Attack();
            m_cCollider.enabled = false;
            //Debug.Log("OnTriggerEnter:" + other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            m_bHit = false;
            //Debug.Log("OnTriggerExit:"+other.gameObject.name);
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(200, 0, 100, 20), ""+m_bHit);
    }
}
