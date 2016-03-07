using UnityEngine;
using System.Collections;

public class PlayerMovement : Action {

    #region member variables

    #endregion

    void Start()
    {
        base.m_requiresInput = false;
    }

    void Update ()
    {
	    //get input and fire it to the perform action
        if (Input.GetButtonDown("Up"))
        {

        }
	}

    override public void Perform() { } //Perform is not used in input driven actions
}
