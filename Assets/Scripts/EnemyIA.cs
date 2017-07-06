using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour {

    public int health;
    public int damage;


    protected bool IsDead()
    {
        if(health <=0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}