using UnityEngine;
using System.Collections;

public class PlayerMovement : Action {

    #region member variables

    private Map m_gameMap;
    private Actor m_thisActor;

    int m_currentX;
    int m_currentY;

    #endregion

    void Start()
    {
        base.m_requiresInput = false;

        m_thisActor = GetComponent<Actor>();
        m_gameMap = FindObjectOfType(typeof(Map)) as Map;
    }

    void Update ()
    {
	    //get input and fire it to the perform action
        if (Input.GetButtonDown("Up"))
        {
            UpdatePosition();
            //print(m_currentX + " : " + currentX);
            m_gameMap.MoveActor(m_thisActor, new Vector2(m_currentX, m_currentY --));
        }
        if (Input.GetButtonDown("Right"))
        {
            UpdatePosition();
            m_gameMap.MoveActor(m_thisActor, new Vector2(m_currentX ++, m_currentY));
        }
        if (Input.GetButtonDown("Down"))
        {
            UpdatePosition();
            m_gameMap.MoveActor(m_thisActor, new Vector2(m_currentX, m_currentY++));
        }
        if (Input.GetButtonDown("Left"))
        {
            UpdatePosition();
            m_gameMap.MoveActor(m_thisActor, new Vector2(m_currentX++, m_currentY));
        }
    }

    public void UpdatePosition()
    {
        m_currentX = (int)m_gameMap.GetActorLocation(m_thisActor.GetInstanceID()).x;
        m_currentY = (int)m_gameMap.GetActorLocation(m_thisActor.GetInstanceID()).y;
    }

    override public void Perform() { } //Perform is not used in input driven actions
}
