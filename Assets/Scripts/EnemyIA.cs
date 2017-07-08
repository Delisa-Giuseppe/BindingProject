using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour {

    public int health;
    public int damage;

    protected Animator anim;
    HUDManager manager;


    private void Start()
    {
        anim = GetComponent<Animator>();
        manager = GameObject.Find("HUD").GetComponent<HUDManager>();
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
        manager.ModifyHealth(damage);
    }
}