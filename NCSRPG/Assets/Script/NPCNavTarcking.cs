using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCNavTarcking : MonoBehaviour {
    NavMeshAgent m_cNavMeshAgent;

    public int m_fRotSpeed;
    public Arm m_cArm;
    public float m_fDetectRad;
    public float m_fAttakSpeed;
    Player m_cPlayer;
    public Player m_cTarget;

    bool m_bAuto = false;

    // Use this for initialization
    void Start () {
        m_cNavMeshAgent = GetComponent<NavMeshAgent>();
        m_cPlayer = this.gameObject.GetComponent<Player>();
        m_cArm.Init(m_fRotSpeed, m_cPlayer);
    }
	
	// Update is called once per frame
	void Update () {
     
       
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, m_fDetectRad);
    }

    public void SphereCollisionProcess(GameObject objTarget)
    {
        if (m_cTarget == null)
        { 
            if(User.Collision.ColSphere(transform.position, m_fDetectRad, objTarget.transform.position))
            {
                m_cTarget = objTarget.GetComponent<Player>();
                m_cArm.m_cTarget = m_cTarget;
            }
        }
        else
        {

           float fDist = User.Collision.ColSphereDist(transform.position, m_fDetectRad, m_cTarget.transform.position);

            if (fDist == -1)
            {
                m_cTarget = null;
                m_bAuto = false;
            }
            else if (fDist > 2)
            {
                //타겟을 잃으면 다시 물리연산을 하도록변경한다.
                GetComponent<Rigidbody>().isKinematic = false;
                m_cTarget.GetComponent<Rigidbody>().isKinematic = false;

                m_cNavMeshAgent.SetDestination(m_cTarget.transform.position);
                transform.LookAt(m_cTarget.transform.position);
                m_bAuto = false;
            }
            else
            {
                if (m_bAuto == false)
                {
                    //밀러나지않도록 대상과 자신의 강체를 물리연산을 하지않도록한다.
                    m_cTarget.GetComponent<Rigidbody>().isKinematic = true;
                    GetComponent<Rigidbody>().isKinematic = true;

                    transform.LookAt(m_cTarget.transform.position);
                    m_bAuto = true;
                    StartCoroutine("AutoAttack");
                    Debug.Log("AutoAttack Start!");
                }
            }
        }
    }

    //private void OnGUI()
    //{
    //    if(GUI.Button(new Rect(0,0,100,20),"test"))
    //    {
    //        StartCoroutine("AutoAttack");
    //    }
    //}

    IEnumerator AutoAttack()
    {
        //Debug.Log("AutoAttack! 1");
        while (m_cArm == true)
        {
            m_cArm.AttackStart();
            //Debug.Log("AutoAttack! loop");
            yield return new WaitForSeconds(m_fAttakSpeed);//공격속도마다 공격을 부른다.
        }
        //Debug.Log("AutoAttack! 2");
    }
}
