using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase {

    EnemyList enemylist;

    void Start()
    {
        enemylist = gameObject.GetComponent<EnemyList>();
        Initialize();
    }

    void Update()
    {
    }

    public int Attack()
    {
        power = (int)(power * Random.Range(0.9f, 1.1f));
        return power;
    }


    

}
