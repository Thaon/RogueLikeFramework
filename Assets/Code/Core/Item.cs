using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    #region member variables

    public string m_name;
    [SerializeField]
    public equipmentType m_type;

    public int m_damageReduction, m_damageOutput;
    public int m_chancheToHit;//this is %

    #endregion

    void Start () {
	
	}
	
	void Update () {
	
	}
}
