using UnityEngine;
using System.Collections;

public static class BattleSystem {

    #region member variables

    #endregion

    public static void PerformBattleAction(Actor actor1, Actor actor2)
    {
        if (PlayerFirst())
        {
            BattleRound(actor1, actor2);
        }
        else
        {
            BattleRound(actor2, actor1);
        }
    }

    static void BattleRound(Actor actor1, Actor actor2)
    {
        //check if actor1 can fight
        if (actor1.m_equipment != null)
        {
            //check if actor1 hits
            if (Random.Range(0, 100) < actor1.m_equipment.m_weapon.m_chancheToHit)
            {
                //then we apply damage
                int damage = CalculateDamage(actor1, actor2);
                actor2.TakeDamage(damage);
                //then we log it in some way
                GameManager.Log(actor1.m_name + " hit " + actor2.m_name + "for " + damage + " points");
            }
            else
            {
                GameManager.Log(actor1.m_name + " misses...");
            }
        }
        //check if actor1 can fight
        if (actor2.m_equipment != null)
        {
            //check if actor1 hits
            if (Random.Range(0, 100) < actor2.m_equipment.m_weapon.m_chancheToHit)
            {
                //then we apply damage
                int damage = CalculateDamage(actor2, actor1);
                actor1.TakeDamage(damage);
                //then we log it in some way
                GameManager.Log(actor2.m_name + " hit " + actor1.m_name + "for " + damage + " points");
            }
            GameManager.Log(actor2.m_name + " misses...");
        }
    }

    static int CalculateDamage(Actor actor1, Actor actor2)
    {
        int totalDamage = actor1.m_equipment.m_weapon.m_damageOutput;
        //check if we have armor or damage reduction in general
        if (actor2.m_equipment.m_armor.m_damageReduction != 0)
        {
            totalDamage -= actor2.m_equipment.m_armor.m_damageReduction; //damage reduction can be negative and actually boost damage
        }
        if (actor2.m_equipment.m_weapon.m_damageReduction != 0)
        {
            totalDamage -= actor2.m_equipment.m_weapon.m_damageReduction; //damage reduction can be negative and actually boost damage
        }
        return totalDamage;
    }

    static bool PlayerFirst() //maybe roll initiative, for now it returns true if player 1 goes first
    {
        return true;
    }
}
