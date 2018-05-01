using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoDrawBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        Matrix4x4 mat = transform.worldToLocalMatrix;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
