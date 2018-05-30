using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassItem
{
    public string name;
    public ClassItem(string name)
    {
        this.name = name;
    }
}

public class SceneChange : MonoBehaviour {
    public List<ClassItem> m_listItems = new List<ClassItem>();
    public List<GameObject> m_listGameObject = new List<GameObject>();
    public static int m_nSceneIdx = 0;

	// Use this for initialization
	void Start () {
        if (m_nSceneIdx == 0)
        {
            //첫번째 씬이라면 필요한 오브젝트를 생성하고 파괴시키지않는다.
            m_listItems.Add(new ClassItem("A"));
            m_listItems.Add(new ClassItem("B"));
            m_listItems.Add(new ClassItem("C"));
            m_listItems.Add(new ClassItem("D"));
            m_listItems.Add(new ClassItem("E"));

            //하위오브젝트라면 파괴되지않고 유지된다.
            m_listGameObject.Add(GameObject.Find("A"));
            m_listGameObject.Add(GameObject.Find("A"));
            m_listGameObject.Add(GameObject.Find("B"));
            m_listGameObject.Add(GameObject.Find("C"));
            m_listGameObject.Add(GameObject.Find("D"));

            m_nSceneIdx = 1;
            //해당씬에서 만든 모든 오브젝트를 파괴시키지않도록 설정한다.
            DontDestroyOnLoad(this);
            //for (int i = 0; i < m_listGameObject.Count; i++)
                //DontDestroyOnLoad(m_listGameObject[i]);
            SceneManager.LoadScene(m_nSceneIdx);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - 100, 0, 100, 30), "Change:" + m_nSceneIdx))
        {
            if (m_nSceneIdx == 1)
            {
                m_nSceneIdx = 2;
                
            }
            else if (m_nSceneIdx == 2)
            {
                m_nSceneIdx = 1;
            }
            SceneManager.LoadScene(m_nSceneIdx);
        }

        if (GUI.Button(new Rect(Screen.width - 100, 30, 100, 30), "Change Resouce"))
        {
            m_nSceneIdx = 0;
            SceneManager.LoadScene("Resouce");
        }

        for (int i = 0; i<m_listItems.Count; i++)
            GUI.Box(new Rect(0,20*i,100,20),m_listItems[i].name+":"+ m_listItems.Count);
        
        for (int i = 0; i < m_listGameObject.Count; i++)
            GUI.Box(new Rect(100, 20 * i, 100, 20), m_listGameObject[i].name);
    }
}
