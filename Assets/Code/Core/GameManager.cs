using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    #region member variables

    private Actor[] m_actors;

    #endregion

    void Start ()
    {
        m_actors = FindObjectsOfType(typeof(Actor)) as Actor[];
	}
	
	public void WorldUpdate ()
    {
	    foreach(Actor actor in m_actors)
        {
            foreach(Action action in actor.m_actions)
            {
                if (!action.m_requiresInput)
                {
                    action.Perform();
                }
            }
        }
	}

    public static void Log(string text)
    {
        print(text); //for now it just dumps it out, I may have to make this static
    }
}
