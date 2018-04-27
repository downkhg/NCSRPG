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
        if (m_cPlayer.Dead())
        {
            gameObject.SetActive(false);
        }
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

           float fDist = User.Collision.ColSphereDist(transform.position, m_fDetectRad, m_cTarget.transform.position);

            if (fDist == -1)
                m_cTarget = null;
            else if (fDist > 2)
                m_cNavMeshAgent.SetDestination(m_cTarget.transform.position);
            else
                m_cArm.AttackStart();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter:"+other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit:" + other.gameObject.name);
    }
}
