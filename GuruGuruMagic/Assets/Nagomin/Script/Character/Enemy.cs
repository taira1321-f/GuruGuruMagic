using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : EnemyBase {

    private Text timerText;

    void Start()
    {
        timerText = GameObject.Find("TimerText").GetComponent<Text>() ;
        Initialize();
    }

    void Update()
    {
        atkTime -= Time.deltaTime;
        timerText.text = atkTime.ToString();

        if (atkTime <= 0.0f)
        {
            Attack();
        }

    }

    public int Attack()
    {
        atkTime = interval; //攻撃の間隔をリセット
        int damage = (int)(power * Random.Range(0.9f, 1.1f));
        return damage;
    }


    

}
