using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum eItemKind { Weapon, Armor, Acc, Etc }
    public Item(eItemKind eItemkind, string name, string comment, Status sStatus, int nGold)
    {
        m_eItemKind = eItemkind;
        m_strName = name;
        m_strComment = comment;
        m_sFunc = sStatus;
        m_nGold = nGold;
    }

    eItemKind m_eItemKind;
    string m_strName;
    string m_strComment;
    Status m_sFunc;
    int m_nGold;

    public eItemKind ItemKind //Setter,Getter
    {
        get { return m_eItemKind; }
        set { m_eItemKind = value; }
    }
    public string Name //Setter,Getter
    {
        get { return m_strName; }
        set { m_strName = value; }
    }
    public string Comment //Setter,Getter
    {
        get { return m_strComment; }
        set { m_strComment = value; }
    }
    public Status Function
    {
        get { return m_sFunc; }
        set { m_sFunc = value; }
    }
    public int Gold
    {
        get { return m_nGold; }
        set { m_nGold = value; }
    }
}

public class ItemManager : MonoBehaviour {

    public enum eItem { WoodSword, BoneSword, WoodArmor, BoneArmor, WoodRing, BoneRing, HPPotion, MPPotion, Stone, Boom, MAX };
    List<Item> m_listItemList;

    public ItemManager()
    {
        m_listItemList = new List<Item>((int)eItem.MAX);
        m_listItemList.Add(new Item(Item.eItemKind.Weapon, "목검", "데미지증가", new Status(100), 100));
        m_listItemList.Add(new Item(Item.eItemKind.Weapon, "본소드", "데미지증가", new Status(200), 200));
        m_listItemList.Add(new Item(Item.eItemKind.Weapon, "나무갑옷", "방어력증가", new Status(0, 100), 100));
        m_listItemList.Add(new Item(Item.eItemKind.Weapon, "본아머", "방어력증가", new Status(0, 200), 200));
        m_listItemList.Add(new Item(Item.eItemKind.Weapon, "나무반지", "체력증가", new Status(0, 0, 0, 100), 100));
        m_listItemList.Add(new Item(Item.eItemKind.Weapon, "해골반지", "체력증가", new Status(0, 0, 0, 200), 200));
        m_listItemList.Add(new Item(Item.eItemKind.Weapon, "힐링포션", "HP회복", new Status(0, 0, 0, 100), 100));
        m_listItemList.Add(new Item(Item.eItemKind.Weapon, "마나포션", "MP회복", new Status(0, 0, 0, 0, 100), 100));
        m_listItemList.Add(new Item(Item.eItemKind.Weapon, "짱돌", "단일개체데미지", new Status(100), 100));
        m_listItemList.Add(new Item(Item.eItemKind.Weapon, "폭탄", "다수개체데미지", new Status(200), 200));
    }

    public Item GetItem(eItem idx)
    {
        return m_listItemList[(int)idx];
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
