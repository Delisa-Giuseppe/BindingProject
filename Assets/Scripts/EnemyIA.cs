using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour {

    public int health;
    public int damage;

    protected Animator anim;
    HUDManager manager;


    protected void SetAnim()
    {
        anim = GetComponent<Animator>();
        
    }

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

    protected void OnHitPlayer()
    {
        manager = GameObject.Find("HUD").GetComponent<HUDManager>();
        manager.ModifyHealth(damage);
    }
}