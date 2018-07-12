using UnityEngine;
using System.Collections;

public class DynmicAxisTest : MonoBehaviour
{
    public float m_fSpeed = 10.0F;
    public float m_fRotSpeed = 100.0F;
    bool m_bJump = false;

    private void Start()
    {
  
    }

    void Update()
    {
        //float translation = Input.GetAxis("Vertical") * speed;
        //float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        //translation *= Time.deltaTime;
        //rotation *= Time.deltaTime;
        //transform.Translate(0, 0, translation);
        //transform.Rotate(0, rotation, 0);
    }

    private void OnGUI()
    {
        float fVertical = Input.GetAxis("Vertical");
        float fHorizontal = Input.GetAxis("Horizontal");

        if (Mathf.Abs(fVertical) > 0 )
        {
            float fTranslation = fVertical * m_fSpeed;
            fTranslation *= Time.deltaTime;
            transform.Translate(0, 0, fTranslation);
        }
        else if(Mathf.Abs(fHorizontal) > 0)
        {
            float fRotation = fHorizontal * m_fRotSpeed;
            fRotation *= Time.deltaTime;
            transform.Rotate(0, fRotation, 0);
        }
        else
        {
 
        }

        if (Input.GetKey(KeyCode.Space) && !m_bJump)
        {
            Debug.Log("jump");
            GetComponent<Rigidbody>().AddForce(0, 3, 0, ForceMode.Impulse);
            m_bJump = true;
        }

        GUI.Box(new Rect(0, 0, 300, 100),
                "Vertical:" + fVertical +
                "\nHorizontal:" + fHorizontal);
    }

    //void OnCollisionEnter(Collision collision) //충돌체 안에 있을때
    //{
    //    m_bJump = false;
    //    GetComponent<Rigidbody>().isKinematic = true;
    //    Debug.Log("OnCollisionEnter:" + collision.gameObject.name);
    //}

    //void OnCollisionExit(Collision collision)  //충돌체 벗어날때
    //{
    //    GetComponent<Rigidbody>().isKinematic = false;
    //    Debug.Log("OnCollisionExit:" + collision.gameObject.name);
    //}
}