using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic : MonoBehaviour {
    int m_nKeyCount;
    public GameObject m_objArm;
    public int m_fMoveSpeed;
    public int m_fRotSpeed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space key was " + m_nKeyCount);
            m_nKeyCount++;
        }

        InputProcess();
	}
    //게임에서 간단한 테스트용 UI로 사용됨.
    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 20), //시작위치x,y,넓이,높이
                    string.Format("{0}", m_nKeyCount));
    }

    void MoveArm(float rotSpeed)
    {
        m_objArm.transform.Rotate(Vector3.right * rotSpeed);
    }

    //케릭터이동 만들기. 키입력을하여만듦
    void InputProcess()
    {
        float fMoveDist = m_fMoveSpeed * Time.deltaTime;
        float fRotAngle = m_fRotSpeed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            MoveArm(m_fRotSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * fMoveDist);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * fMoveDist);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -m_fRotSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * m_fRotSpeed);
        }
    }
}
