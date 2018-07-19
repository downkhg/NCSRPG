using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTareck : MonoBehaviour {
    public Transform m_cTarget;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 vTargetPos = m_cTarget.position;
        vTargetPos.y = transform.position.y;

        transform.position = vTargetPos;

    }
}
