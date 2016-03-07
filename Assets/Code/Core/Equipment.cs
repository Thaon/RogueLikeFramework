using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum equipmentType { weapon, armor, ring, potion, scroll}

public class Equipment : MonoBehaviour {

    #region member variables

    public Item m_weapon;
    public Item m_armor;

    #endregion

    void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}

    public void Equip(Item item)
    {
        switch(item.m_type)
        {
            case equipmentType.weapon:
                m_weapon = item;
            break;

            case equipmentType.armor:
                m_armor = item;
            break;

            default:
                print("Can't equip that, boy");
            break;
        }
    }
}
