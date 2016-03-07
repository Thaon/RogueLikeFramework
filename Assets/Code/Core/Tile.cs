using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SpriteRenderer))]

public class Tile : MonoBehaviour {

    #region member variables

    public string m_name;
    public Actor m_occupant;
    public List<Item> m_itemsInTile;
    [HideInInspector]
    public SpriteRenderer m_spriteRenderer;
    public bool m_isLit = false;
    public bool m_isBlocking = false;

    #endregion


    void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }
}
