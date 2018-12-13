using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : EnemyBase {

    [SerializeField]
    public E_EnemyStatus enemy;

    private Text timerText;
    Player player;

    void Start()
    {
        timerText = GameObject.Find("TimerText").GetComponent<Text>() ;
        player = GameObject.Find("Player_01").GetComponent<Player>();
        Initialize(enemy);
    }

    void Update()
    {
        atkTime -= Time.deltaTime;
        timerText.text = ((int)atkTime).ToString();

        if (atkTime <= 0.0f)
        {
            Attack();
        }

    }

    public void Attack()
    {
        atkTime = interval; //攻撃の間隔をリセット
        int damage = (int)(power * Random.Range(0.9f, 1.1f));
        player.GetDamage(damage);
    }

    public void GetDamage(int dmg)
    {
        Debug.Log((int)dmg + "のダメージを与えた。");

        NowHP -= dmg;
        Debug.Log("HP:" + NowHP);

        if (IsDead(NowHP))
        {
            Debug.Log(this.name + "はしにました");
            this.gameObject.SetActive(false);
        }
    }

    public string GetElement()
    {
        return this.type;
    }
    

}
