using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject m_cWepon;
    public float m_fRotAngle;
    int m_nTimeCount = 0;
    int m_nFixedCount = 0;
    int m_nLastCount = 0;
    int m_nUpdateCount = 0;

    int m_fResetTime;

    IEnumerable CountReset()
    {
        m_nFixedCount = 0;
        m_nLastCount = 0;
        m_nUpdateCount = 0;

        yield return new WaitForSeconds(m_fResetTime);
    }

    // Use this for initialization
    void Start () {
        StartCoroutine("CountReset");
	}

    private void FixedUpdate()
    {
        m_nFixedCount++;
    }
    // Update is called once per frame
    void Update ()
    {
        m_nUpdateCount++;

        int nLayerMask = 1 << LayerMask.NameToLayer("Monster");

        //Collider[] colliders =  Physics.OverlapSphere(m_cWepon.transform.position,0.5f, nLayerMask);
        Collider[] colliders = Physics.OverlapBox(m_cWepon.transform.position, m_cWepon.transform.localScale, m_cWepon.transform.localRotation, nLayerMask);

        for (int i = 0; i < colliders.Length; i++)
        {
            Debug.Log(colliders[i].gameObject.name);
        }

        transform.Rotate(new Vector3(0, m_fRotAngle * Time.deltaTime, 0));
	}

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(m_cWepon.transform.position,0.5f);
        //Gizmos.DrawWireCube(m_cWepon.transform.position, m_cWepon.transform.localScale);
    }

    private void LateUpdate()
    {
        m_nLastCount++;
    }
}
