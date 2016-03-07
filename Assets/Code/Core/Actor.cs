using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Actor : MonoBehaviour {

    #region member variables

    [SerializeField]
    public List<Action> m_actions;
    public Inventory m_inventory;
    public int m_healthPoints, m_manaPoints;

    #endregion

    void Start ()
    {
        m_actions = new List<Action>();
	}
	
	void Update ()
    {
	
	}

    public void UpdateTurn()
    {

    }
}
