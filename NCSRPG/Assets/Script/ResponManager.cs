using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponManager : MonoBehaviour {
    public List<Transform> m_listResponPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetResponPoint(int posIdx, GameObject target)
    {
        Vector3 pos = m_listResponPoint[posIdx].position;
        
        target.transform.position = new Vector3(pos.x,pos.y,pos.z);

        target.transform.SetParent(m_listResponPoint[posIdx]);
        target.transform.localPosition= new Vector3(0, 0, 0);
    }
}
