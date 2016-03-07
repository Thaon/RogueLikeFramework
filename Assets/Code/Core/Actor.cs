using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ActorState { normal, poisoned, burning, resting}

public class Actor : MonoBehaviour {

    #region member variables

    public string m_name;
    public bool m_isPlayer;

    [SerializeField]
    public List<Action> m_actions;
    public int m_healthPoints, m_manaPoints;
    public Inventory m_inventory;
    public Equipment m_equipment;
    private Map m_levelMap;

    #endregion

    void Start ()
    {
        //m_actions = new List<Action>();
        m_levelMap = FindObjectOfType(typeof(Map)) as Map;

        if (GetComponent<Inventory>() != null)
        {
            m_inventory = GetComponent<Inventory>();
        }
        if (GetComponent<Equipment>() != null)
        {
            m_equipment = GetComponent<Equipment>();
        }
    }
	
	void UpdateTurn ()
    {
	
	}

    public void TakeDamage(int damage)
    {
        m_healthPoints -= damage;
        if (m_healthPoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (m_inventory != null)
        {
            string items = "";
            foreach(Item item in m_inventory.m_items)
            {
                Vector2 position = m_levelMap.GetActorLocation(this.GetInstanceID());
                m_levelMap.DropItem(item, position);
                m_levelMap.m_levelMap[(int)position.x, (int)position.y].m_occupant = null; //we remove the actor from there for safety reasons
                items += item.m_name + " ";
            }
            GameManager.Log(m_name + " died, leaving on the ground: " + items);
        }
        else
        {
            GameManager.Log(m_name + " died");
        }
        Destroy(this.gameObject);
    }
}
