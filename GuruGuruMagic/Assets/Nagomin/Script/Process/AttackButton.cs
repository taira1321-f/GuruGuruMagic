using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour {

    GameObject enemy1;
    Enemy enemy;
    GameObject player1;
    Player player;

	// Use this for initialization
	void Start () {
        enemy1 = GameObject.Find("RedSlime");
        enemy = enemy1.GetComponent<Enemy>();
        player1 = GameObject.Find("Player");
        player = player1.GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        int dmg = 1;
        int lost = 1;

        if(!enemy.IsDead()) dmg = enemy.GetDamage(100);        
        lost = enemy.Attack();
    }
}
