using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatationTest : MonoBehaviour {
    public Vector3 m_vDir;
    public Vector3 m_vMinDir;
    public Vector3 m_vMaxDir;
    public float m_fLimitAngle;
    public float m_fCurAngle;
    public float m_fAngleSpeed;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        AccumulateLimilt();   
    }

    //1.제한 각도를 설정하고, 그값을 쌓아서 오브젝트를 회전시키고.
    //2.해당각도가 일정값이 되면 각도를 증가시키지않는다.
    void AccumulateLimilt()
    {
        float fAngle = m_fAngleSpeed * Time.deltaTime;

        if(m_fLimitAngle > m_fCurAngle)
            m_fCurAngle += fAngle;

        transform.localRotation = Quaternion.Euler(new Vector3(0, m_fCurAngle, 0));
    }

    void DotLimilt()
    {
        //각도가 90도가 넘어가면 -값으로 결과가 도출되므로 이방식으로는 해결이 불가능하다.
        //m_vDir = transform.forward;
        //float fDist = Vector3.Dot(m_vDir, m_vMinDir);

        //float fAngle = Mathf.Cos(fDist);
        //Debug.Log("Angle:" + fAngle);

        //if (m_fLimitAngle >= Mathf.Abs(fAngle))
        //    transform.Rotate(Vector3.up);
    }
}
