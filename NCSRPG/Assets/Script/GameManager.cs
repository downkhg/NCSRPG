using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject m_objPlayer;
    public NPC m_cNPC;
    public List<GameObject> m_listMonsters;
    public ResponManager m_cResponManager;
    public MonsterManager m_cMonsterManager;
    public ItemManager m_cItemManager;
    public GUIManager m_cGUIManager;
    public int m_nMonsterMax;
    public int m_nResponTime;

    public Transform m_cDeadDumy;

    public Queue<Player> m_queResponQueue = new Queue<Player>();

    static GameManager m_cInstance;

    public static GameManager GetInstance()
    {
        return m_cInstance;
    }

	// Use this for initialization
	void Start () {
        m_cInstance = this;
        Dynamic cDynamic  = m_objPlayer.GetComponent<Dynamic>();
        cDynamic.Init();
        m_listMonsters = new List<GameObject>(m_nMonsterMax);
        m_cMonsterManager = new MonsterManager();
        m_cMonsterManager.LoadMonsterInfo();
        m_cNPC.Init();

        for (int i = 0; i < m_nMonsterMax; i++)
        {
            GameObject prefapMonster = Resources.Load("Prefaps/Monster") as GameObject;
            GameObject objMonster =  Instantiate(prefapMonster);
            Player cMonster = objMonster.GetComponent<Player>();

            string name = string.Format("Monster{0}", i);
            m_cMonsterManager.SetMonsterInfo("Slime", cMonster);
            cMonster.m_nDebugStatusStartX = 100 *( i+1);
            m_cResponManager.SetResponPoint(i, objMonster);
            Debug.Log(m_objPlayer.transform.position);
            cMonster.name = name+ objMonster.transform.position;

            m_listMonsters.Add(objMonster);
        }
    }
	
	// Update is called once per frame
	void Update () {
        Dynamic cPlayerDynamic = m_objPlayer.GetComponent<Dynamic>();
        cPlayerDynamic.SphereCollisionProcess(m_listMonsters);

        for (int i = 0; i < m_listMonsters.Count; i++)
        {
            NPCNavTarcking cNavTracking = m_listMonsters[i].GetComponent<NPCNavTarcking>();
            Player cMonster = m_listMonsters[i].GetComponent<Player>();
            cNavTracking.SphereCollisionProcess(m_objPlayer);

            if (cMonster.Dead())
            {
                m_listMonsters[i].SetActive(false);
                m_listMonsters[i].transform.position = m_cDeadDumy.position;

                m_cResponManager.SetResponPoint(i, m_listMonsters[i]);
                m_queResponQueue.Enqueue(m_listMonsters[i].GetComponent<Player>());
                StartCoroutine("MonsterRespron");
            }
        }

        if (m_cGUIManager.m_objSelect.activeSelf == false)
        {
            if (User.Collision.ColSphere(m_cNPC.transform.position, 3, cPlayerDynamic.transform.position))
            {
                m_cGUIManager.m_objSelect.SetActive(true);
            }
        }

        Player cPlayer = m_objPlayer.GetComponent<Player>();
        m_cGUIManager.m_cHPStatus.SetHP(cPlayer.Status.m_nHP, cPlayer.MaxHP);


        Dynamic cDynamic = m_objPlayer.GetComponent<Dynamic>();
        cDynamic.JoystickMove(m_cGUIManager.m_cJoystick.m_vecDir);

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (m_cGUIManager.m_cInventoryManager.gameObject.activeSelf == false)
            {
                m_cGUIManager.m_cInventoryManager.Set(cPlayer);
                m_cGUIManager.m_cInventoryManager.gameObject.SetActive(true);
            }
            else
            {
                m_cGUIManager.m_cInventoryManager.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator MonsterRespron()
    {
        yield return new WaitForSeconds(m_nResponTime);

        Player cMonster = m_queResponQueue.Dequeue();
        m_cMonsterManager.SetMonsterInfo("Slime", cMonster);
        cMonster.gameObject.SetActive(true);
    }

    public void PlayerAttack()
    {
        Dynamic cDynamic = m_objPlayer.GetComponent<Dynamic>();
        cDynamic.Attack();
    }
}
