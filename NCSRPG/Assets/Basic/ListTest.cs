using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListTest : MonoBehaviour {

    struct StructA
    {
        public int nData;
    }

    class ClassA
    {
        public int nData;
    }

    public GameObject m_objObject;

    public List<GameObject> m_listGameObjects = new List<GameObject>();

    List<GameObject> GetList()
    {
        return m_listGameObjects;
    }

    void SwapStruct(StructA a, StructA b)
    {
        int temp = a.nData;
        a.nData = b.nData;
        b.nData = temp;
    }

    void SwapClass(ClassA a, ClassA b)
    {
        int temp = a.nData;
        a.nData = b.nData;
        b.nData = temp;
    }

    // Use this for initialization
    void Start () {
        m_listGameObjects = new List<GameObject>();
        m_listGameObjects.Add(Instantiate(m_objObject));
        m_listGameObjects.Add(Instantiate(m_objObject));
        m_listGameObjects.Add(Instantiate(m_objObject));
        m_listGameObjects.Add(Instantiate(m_objObject));
        List<GameObject> list = GetList();
        for(int i = 0; i < list.Count; i++ )
        {
            //Destroy(list[i]);
            Debug.Log("list.Count"+ list.Count);
        }
        list.Clear();

        ClassA cA = new ClassA();
        cA.nData = 10;
        ClassA cB = new ClassA();
        cB.nData = 20;
        StructA sA,sB;
        sA.nData = 10;
        sB.nData = 20;
        Debug.Log(string.Format("struct:{0}/{1}\n",sA.nData,sB.nData));
        Debug.Log(string.Format("class:{0}/{1}\n", cA.nData, cB.nData));
        SwapClass(cA, cB);
        SwapStruct(sA, sB);
        Debug.Log(string.Format("struct-Swap:{0}/{1}\n", sA.nData, sB.nData));
        Debug.Log(string.Format("class-Swap:{0}/{1}\n", cA.nData, cB.nData));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
