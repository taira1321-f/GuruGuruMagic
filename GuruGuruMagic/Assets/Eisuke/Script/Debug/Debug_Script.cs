using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Script : MonoBehaviour {
    const int Chara_num =4;
    const int Enemy_num = 15;
    public CharaDataBase cdb;
    public EnemyStatusDatabase esdb;
    CharaData[] charadata = new CharaData[Chara_num];
    E_EnemyStatus[] enemydata = new E_EnemyStatus[Enemy_num];
	// Use this for initialization
	void Start () {
        for (int i = 0; i < Chara_num; i++) charadata[i] = cdb.CharaDaraList[i];
        for (int i = 0; i < Enemy_num; i++) enemydata[i] = esdb.ES_DataList[i];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
