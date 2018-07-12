using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//1.AI가진 객체를 동적으로 생성한다.
//2.1의 객체에 장애물을 설정한다.
//3.모든 1의 객체가 한쪽으로 밀려난다.
//결론: 그런 현상은 발생하지않음. 기본오브젝트로 테스트 후 차근차근 차례대로 완성해볼것! 

public class NavMeshTest : MonoBehaviour {
    public GameObject m_objTarget;
    NavMeshAgent m_cNavMeshAgent;
	// Use this for initialization
	void Start () {
        m_cNavMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {

        if (m_objTarget)
        {
            float fDist = Vector3.Distance(m_objTarget.transform.position,
                                           this.transform.position);

            if (fDist > 2)
                m_cNavMeshAgent.SetDestination(m_objTarget.transform.position);
        }
	}
}
