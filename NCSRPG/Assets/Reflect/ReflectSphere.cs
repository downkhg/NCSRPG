using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectSphere : MonoBehaviour {
    public Transform m_transTarget;
    public Vector3 m_vDir;
    public float m_fSpeed;
	// Use this for initialization
	void Start () {
        //내가 향할 방향의 거리를 구하고 평준화를 해서 방향값을 구함.ㅣ
        m_vDir = (m_transTarget.transform.position - transform.position).normalized; 
        //m_transTarget.LookAt(m_transTarget.transform);
	}

    private void FixedUpdate()
    {
        //벡터의 합을 이용하여 이동을 시켜줌
        transform.position += (m_vDir * m_fSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update () {
        
	}

    private void OnCollisionEnter(Collision collision)
    {
        //GetComponent<Collider>().enabled = false;
        Debug.Log("OnCollisionEnter():" + collision.gameObject.name);
        CPlane cPlane = collision.gameObject.GetComponent<CPlane>();
        Vector3 vInDir = m_vDir; //입사각
        Debug.Log("InDir(U):" + vInDir);
        Vector3 vNor = cPlane.m_plane.normal; //평면이 바라보는 방향
        Vector3 vOutDir;
        Vector3 vInDirRev = (vInDir * -1); //1.입사각 뒤집기
        float fDot = Vector3.Dot(vInDirRev, vNor); //2.뒤집은 입사각과 평면의 방향 내적(삼각함수, 가장 긴변의 길이 구하기)
        Vector3 vDoubleNor = fDot * 2 * vNor; //3. 2의 값을 평면에 곱하면 평면 노말의 두배크기의 벡터
        vOutDir = vDoubleNor + vInDir; //4. 3의 결과에 입사각을 더함.
        Debug.Log("Dot:"+fDot+" Cos("+Mathf.Cos(fDot) + ")");
        Debug.Log("RefrectDir(U):"+ vOutDir);
        vOutDir = Vector3.Reflect(vInDir, vNor);
        Debug.Log("RefrectDir:" + vOutDir);
        m_vDir = vOutDir;
        Debug.Log("Dir(U):" + m_vDir);  
    }
}
