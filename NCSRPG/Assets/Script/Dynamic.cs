using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic : MonoBehaviour {
    int m_nKeyCount;
    public GameObject m_objArm;
    public int m_fMoveSpeed;
    public int m_fRotSpeed;
    public Arm m_cArm;
    bool m_bAttack;
   
    // Use this for initialization
    void Start () {
        m_cArm.Init(m_fRotSpeed);
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

    

    //코루틴을 사용하면, 매 프레임마다 반복문의 한스탭이 실행되므로,
    //따로 끝날때 처리를 하지않아도되고, 해당반복의 스탭이 끝나면 실행이 끝난다.
    //실행중 지역변수들은 코루틴이 끝날때까지 유지된다.
    IEnumerator AttackArm()
    {
        float fMaxRot = 45;
        float fCurRot = 0;

        while(fCurRot  < fMaxRot)
        {
            //매프레임마다 실행
            MoveArm(m_fRotSpeed);
            fCurRot += m_fRotSpeed;
            yield return null; //다음 프레임으로.
        }
        
        StartCoroutine("ReleaseArm");
    }

    IEnumerator ReleaseArm()
    {
        float fMaxRot = 45;
        float fCurRot = 0;

        while (fCurRot < fMaxRot)
        {
            MoveArm(-m_fRotSpeed);
            fCurRot += m_fRotSpeed;
            yield return null;
        }

        m_bAttack = false;
    }

    //케릭터이동 만들기. 키입력을하여만듦
    void InputProcess()
    {
        float fMoveDist = m_fMoveSpeed * Time.deltaTime;
        float fRotAngle = m_fRotSpeed * Time.deltaTime;

        //if (m_bAttack)
        //    AttackArmUpdate();

        if (Input.GetMouseButtonDown(0))
        {
            //MoveArm(m_fRotSpeed);
            //그냥 코루틴을 이용시에는 코루틴을 부를때마다 
            //해당 반복문이 실행되므로, 중복해서 계속 동작한다.
            //if (m_bAttack == false)
            //{
            //    StartCoroutine("AttackArm");
            //    m_bAttack = true;
            //}
            m_cArm.Attack();
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
