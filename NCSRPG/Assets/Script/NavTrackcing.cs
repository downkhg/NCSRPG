using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavTrackcing : MonoBehaviour {
    public Transform m_transformTarget;
    public Player m_cPlayer;
    float m_fMinDist = 5;
    NavMeshAgent m_cNavMeshAgent;
    
	// Use this for initialization
	void Start () {
        m_cPlayer = new Player();
        m_cNavMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
       

    }

    void TrackingTarget()
    {
        Vector3 vPos = transform.position;
        Vector3 vTargetPos = m_transformTarget.position;
        float fDist = Vector3.Distance(vPos, vTargetPos);

        GUI.Box(new Rect(0, 100, 100, 20), "Dist:" + fDist);

        if (fDist < m_fMinDist)
            m_cNavMeshAgent.SetDestination(vTargetPos);
    }

    private void OnGUI()
    {
        TrackingTarget();
    }
}
