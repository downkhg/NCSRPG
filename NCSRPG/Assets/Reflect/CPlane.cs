using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlane : MonoBehaviour {
    public Plane m_plane;
	// Use this for initialization
	void Start () {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;
        Vector3[] vMeshs = mesh.vertices;

        m_plane.Set3Points(vMeshs[0], vMeshs[1], vMeshs[2]);
	}

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + m_plane.normal);
    }

    // Update is called once per frame
    void Update () {
		
	}

    
}
