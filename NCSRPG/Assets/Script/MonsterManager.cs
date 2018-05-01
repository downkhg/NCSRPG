using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager {
    enum eMonsterInfo { NAME,HP,MP,STR,INT,EXP,GOLD }
    Dictionary<string,string> m_listMonsters;

    public void LoadMonsterInfo()
    {
        m_listMonsters = new Dictionary<string, string>();
        TextAsset textAsset = Resources.Load("Data/monster_infos") as TextAsset;

        char[] split = new char[] { '\n' };
        string[] lines = textAsset.text.Split(split);

        for (int i = 1; i < lines.Length; i++)
        {
            char[] splitInfo = new char[] { ',' };
            string[] infos = lines[i].Split(splitInfo);
            m_listMonsters.Add(infos[(int)eMonsterInfo.NAME], lines[i]);
            Debug.Log(string.Format("{0}:{1}",infos[(int)eMonsterInfo.NAME], lines[i]));
        }
    }

    public void SetMonsterInfo(string name, Player target)
    {
        char[] splitInfo = new char[] { ',' };
        string[] infos = m_listMonsters[name].Split(splitInfo);
        int[] nInfos = new int[infos.Length];
        for (int i = 1; i < nInfos.Length; i++)
            nInfos[i] = int.Parse(infos[i]);
        target.Set(name, nInfos[(int)eMonsterInfo.HP], nInfos[(int)eMonsterInfo.MP], 
                              nInfos[(int)eMonsterInfo.STR], nInfos[(int)eMonsterInfo.INT], 
                              nInfos[(int)eMonsterInfo.EXP], nInfos[(int)eMonsterInfo.GOLD]);
    }
}
