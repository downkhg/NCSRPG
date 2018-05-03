using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace User {
    public static class Collision
    {
        static public float ColSphereDist(Vector3 vPos, float fRad, Vector3 vTargetPos)
        {
            Vector3 vDist = vTargetPos - vPos;
            float fDist = vDist.magnitude;

            if (fDist < fRad)
                return fDist;

            return -1;
        }
        static public bool ColSphere(Vector3 vPos, float fRad, Vector3 vTargetPos)
        {
            Vector3 vDist = vTargetPos - vPos;
            float fDist = vDist.magnitude;

            if (fDist < fRad)
                return true;

            return false;
        }
        static public bool ColCircle(Vector2 vPos, float fRad, Vector2 vTargetPos)
        {
            Vector2 vDist = vTargetPos - vPos;
            float fDist = vDist.magnitude;

            if (fDist < fRad)
                return true;

            return false;
        }
    }
}

public class Dynamic : MonoBehaviour {
    public int m_fMoveSpeed;
    public int m_fRotSpeed;
    public Arm m_cArm;
    public float m_fDetectRad;
    Player m_cPlayer;
    public Player m_cTarget;
   
    // Use this for initialization
    void Start () {
        m_cPlayer = new Player("Player") ;// this.gameObject.GetComponent<Player>();
        m_cArm.Init(m_fRotSpeed, m_cPlayer);
    }
	
	// Update is called once per frame
	void Update () {
        if(m_cPlayer.Dead())
        {
            gameObject.SetActive(false);
        }
        if(tag == "Player")
            InputProcess();
    }
    //게임에서 간단한 테스트용 UI로 사용됨.
    private void OnGUI()
    {
       for(int i = 0; i<m_cPlayer.GetIventorySize(); i++)
        {
            GUI.Box(new Rect(Screen.width - 100, 20*i, 100, 20), m_cPlayer.GetInvetory(i).Name);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, m_fDetectRad);
    }

    public void SphereCollisionProcess(List<GameObject> listTarget)
    {
        int nNearIdx = -1;
        if (m_cTarget == null)
        {
            for (int i = 0; i < listTarget.Count; i++)
            {
                float fDist = User.Collision.ColSphereDist(transform.position, m_fDetectRad, listTarget[i].transform.position);
                if (fDist > 0)
                {
                    float fMin = m_fDetectRad;
                    if (fMin > fDist)
                    {
                        fDist = fMin;
                        nNearIdx = i;
                    }
                }
            }
    
            if (nNearIdx != -1)
            {
                m_cTarget = listTarget[nNearIdx].GetComponent<Player>();
                if (m_cTarget)
                    Debug.Log(m_cTarget.gameObject.name);
                else
                    Debug.Log("Not Find!");
            }
        }
        else
        {
            if (User.Collision.ColSphere(transform.position, m_fDetectRad, m_cTarget.transform.position) == false)
                m_cTarget = null;
        }
    }

    //OverlapSphere에서 레이어로 분리하는 기능이 정상작동되지않음. 확인필요.
    void OverlapShereProcess()
    {
        int nLayer = LayerMask.NameToLayer("Player");
        Collider[] arrColliders = Physics.OverlapSphere(transform.position, m_fDetectRad, nLayer);
        if (arrColliders.Length > 0)
            Debug.Log( ""+arrColliders.Length);

        if (m_cTarget == null)
        {
            int nNearIdx = -1;
            for (int i = 0; i < arrColliders.Length; i++)
            {
                Transform targetTrans = arrColliders[i].transform;
                //내위치와 상대위치를 확인
                Vector3 vPos = this.transform.position;
                Vector3 vTargetPos = targetTrans.position;
                Vector3 vDist = vTargetPos - vPos;
                float fDist = vDist.magnitude;
                float fMin = 99999999;
                if (fDist < fMin)
                {
                    fMin = fDist;
                    nNearIdx = i;
                }

            }
            if (nNearIdx != -1)
            {
                m_cTarget = arrColliders[nNearIdx].GetComponent<Player>();
                if (m_cTarget)
                    Debug.Log(m_cTarget.gameObject.name);
                else
                    Debug.Log("Not Find!");
            }
        }
    }

    //케릭터이동 만들기. 키입력을하여만듦
    void InputProcess()
    {
        float fMoveDist = m_fMoveSpeed * Time.deltaTime;
        float fRotAngle = m_fRotSpeed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            m_cArm.m_cTarget = m_cTarget;
            m_cArm.AttackStart();
            //if (m_cTarget)
            //    m_cPlayer.Attack(m_cTarget);
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
