using UnityEngine;
using System.Collections;

public abstract class Action : MonoBehaviour {

    #region member variables

    public int m_actionCost;
    public bool m_requiresInput;

    #endregion

    public abstract void Perform();
}
