using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPush : MonoBehaviour {
    Rigidbody m_cRigidbody;
    public float m_fPower;
    public float m_fSpeed = 10.0F;
    public float m_fRotSpeed = 100.0F;

    // Use this for initialization
    void Start () {
        m_cRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float fVertical = Input.GetAxis("Vertical");
        float fHorizontal = Input.GetAxis("Horizontal");

        if (Mathf.Abs(fVertical) > 0 || Mathf.Abs(fHorizontal) > 0)
        {
            float fTranslation = fVertical * m_fSpeed;
            float fRotation = fHorizontal * m_fRotSpeed;
            fTranslation *= Time.deltaTime;
            fRotation *= Time.deltaTime;
            transform.Translate(0, 0, fTranslation);
            transform.Rotate(0, fRotation, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject objTarget = collision.gameObject;
        Rigidbody rigidbodyTarget = objTarget.GetComponent<Rigidbody>();
        rigidbodyTarget.AddForce(transform.forward * m_fPower * m_fSpeed);
    }
}
