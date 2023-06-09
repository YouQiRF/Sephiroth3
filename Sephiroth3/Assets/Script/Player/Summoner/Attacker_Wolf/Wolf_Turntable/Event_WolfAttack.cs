﻿using System.Collections;
using System.Collections.Generic;
using Project;
using Project.Event;
using UnityEngine;

public class Event_WolfAttack : TurntableGeneric
{
    public override void OnPointed()
    {
        //var AttackNumber = FindObjectOfType<LocationManager>();
        var AttackAN = GameObject.Find("WolfAN").GetComponent<AttackDisPlay_Player>();
        if (FindObjectOfType<WolfFettle>().StatyLocation > FindObjectOfType<PlayerFettle>().StatyLocation)
        {
            LocationManager.instance.EnemyOnAttackDetected(4);
        }
        else
        {
            LocationManager.instance.EnemyOnAttackDetected(2);
        }
        
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Shake_Camera_M,Creat_Effect_Player.instance.Buff_Hit_pos[0]);
        AttackAN.OnAttackDisPlay();//Debug.Log("Attackwolf");
    }
}
