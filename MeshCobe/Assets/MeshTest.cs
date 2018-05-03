using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTest : MonoBehaviour {
    Mesh m_cMesh;
	// Use this for initialization
	void Start () {
        m_cMesh = GetComponent<MeshFilter>().mesh;
	}
	
	// Update is called once per frame
	void Update () {
        Matrix4x4 mat = this.transform.worldToLocalMatrix;
	}

    private void OnDrawGizmos()
    {
        Matrix4x4 mat = this.transform.worldToLocalMatrix;
        Vector3[] vectices = m_cMesh.vertices;

        for(int i = 0; i<vectices.Length; i++)
        {
            vectices[i] = mat.MultiplyPoint(vectices[i]);
            Gizmos.DrawSphere(vectices[i], 0.1f);
        }

        //Gizmos.DrawMesh(m_cMesh);
        Gizmos.DrawSphere(vectices[0], 0.1f);
        Gizmos.DrawLine(vectices[0], vectices[1]);
        Gizmos.DrawLine(vectices[1], vectices[2]);
        Gizmos.DrawLine(vectices[2], vectices[3]);
        Gizmos.DrawLine(vectices[0], vectices[3]);
    }

    private void OnGUI()
    {
        Matrix4x4 mat = this.transform.worldToLocalMatrix;
        Vector3 vVertices = m_cMesh.vertices[0];

        vVertices = mat.MultiplyPoint(vVertices);
        Quaternion q = transform.localRotation;

        GUI.Box(new Rect(0, 0, 200, 100), "Mesh:"+ vVertices);
        GUI.Box(new Rect(200, 0, 400, 100), "" + mat);
    }
}
