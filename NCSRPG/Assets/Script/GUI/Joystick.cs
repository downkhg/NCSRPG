using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour {
    public RectTransform m_transJoyStickHead;
    public Vector3 m_vecDir;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RectTransform rect = GetComponent<RectTransform>();
        rect.localPosition = m_transJoyStickHead.localPosition;
        //Debug.Log(rect.localPosition);
        m_vecDir = rect.localPosition;
    }
}

public class CopyOfJoystick : MonoBehaviour
{
    public RectTransform m_transJoyStickHead;
    public Vector3 m_vecDir;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.position = m_transJoyStickHead.position;

        m_vecDir = rect.localPosition - Vector3.zero;
    }
}
