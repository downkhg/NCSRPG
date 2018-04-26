using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCNavTarcking : MonoBehaviour {
    NavMeshAgent m_cNavMeshAgent;

    public int m_fRotSpeed;
    public Arm m_cArm;
    public float m_fDetectRad;
    Player m_cPlayer;
    public Player m_cTarget;

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
            }
        }
        else
        {
            //m_cNavMeshAgent.SetDestination(m_cTarget.transform.position);

            if (User.Collision.ColSphere(transform.position, m_fDetectRad, m_cTarget.transform.position) == false)
                m_cTarget = null;
        }
    }

}
