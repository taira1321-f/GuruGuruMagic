using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerBase {

    [SerializeField]
    CharaData player;

    rotarScript2 Guruguru;
    SpellRecipe2 Recipe;
    Enemy[] enemy = new Enemy[3];//ステージの敵を格納する箱
    int enemycnt = 0;

    void Start()
    {
        Initialize(player);
        Guruguru = GameObject.Find("hitArea").GetComponent<rotarScript2>();
        Recipe = GameObject.Find("PotWater").GetComponent<SpellRecipe2>();
        enemy[0] = GameObject.Find("Enemy_01").GetComponent<Enemy>();
        enemy[1] = GameObject.Find("Enemy_02").GetComponent<Enemy>();
        enemy[2] = GameObject.Find("Enemy_03").GetComponent<Enemy>();
         
        // 先頭の敵以外を非アクティブにする
        for (int i = 1; i < 3; i++)
        {
            enemy[i].gameObject.SetActive(false);
        }
        enemycnt = 0;
    }



    void Update()
    {
        // 石が2個以上あれば回せる
        if (Recipe.Count() >= Recipe.stack_min)
        {
            if (!Guruguru.isEndGuruGuru()) Guruguru.Guru();
            else DamageCal(this.power, this.type);
        }
    }

    // ダメージ計算
    public void DamageCal(int power, string type)
    {
        float dmg;  // ダメージの基礎値
        string recipe;  // レシピの属性

        /* ダメージ計算式
         * ( 敵の防御力 - 攻撃力 + 魔法のダメージ + 混ぜた時の効果量 )
         * 1.キャラの攻撃力をダメージの基礎値にする
         * 2.レシピを取得し、ダメージを加算
         * 3.得意属性であればプレイヤーのレベルに応じてダメージアップ
         * 4.相手の属性相性を計算する
         * 5.鍋の回し具合を計算に入れる
         * */

        dmg = power;    // 1.
        recipe = Recipe.GetRecipe();    // 2.

        // 回復(仮)
        if (recipe == "Heal")
        {
            NowHP += (int)(MaxHP * 0.2f);
            Debug.Log("回復(小)が発動 現在のHP:"+ NowHP +" / " + MaxHP);
        }
        if (recipe == "Heal2")
        {
            NowHP += (int)(MaxHP * 0.5f);
            Debug.Log("回復(大)が発動 現在のHP:" + NowHP + " / " + MaxHP);
        }

        dmg += RecipeEffect(recipe); 
        if (recipe.Contains(type))      // 3.
        {
            dmg *= (((float)this.level / 20.0f) * 2.0f) + 1.0f;
        }
        dmg *= Correction(type);    // 4.
        dmg *= Guruguru.getGuruguru();  //  5.

        // アクティブな敵に攻撃
        if (enemy[enemycnt].gameObject.activeSelf)
        {
            // 敵にダメージを与える
            enemy[enemycnt].GetDamage((int)dmg);

            // 敵を倒したときに次の敵を呼び出す
            if (!enemy[enemycnt].gameObject.activeSelf && !enemy[enemycnt].boss_Flg)
            {
                if(enemycnt < 2) enemycnt++;
                enemy[enemycnt].gameObject.SetActive(true);
            }
            else if (enemy[enemycnt].boss_Flg)
            {
                // ここにステージクリア処理を書く
                Debug.Log("ボスを倒しました : ステージクリア");
            }
        }
    }

    // プレイヤーがダメージを受ける
    public void GetDamage(int dmg)
    {
        NowHP -= dmg;

        Debug.Log("HP:" + NowHP + " / " + MaxHP + ", Damage:" + dmg);

        if (IsDead(NowHP))
        {
            Debug.Log("プレイヤーがしにました : ゲームオーバー");
            Destroy(gameObject);
        };
    }


    // 相性の判定
    float Correction(string type)
    {
        float Rate = 1.0f;
        string etype = enemy[enemycnt].GetElement();

        switch (type)
        {
            case "Fire":
                if (etype == "Wind") Rate = 1.5f;
                else if (etype == "Water") Rate = 0.5f;
                break;
            case "Wind":
                if (etype == "Water") Rate = 1.5f;
                else if (etype == "Fire") Rate = 0.5f;
                break;
            case "Water":
                if (etype == "Fire") Rate = 1.5f;
                else if (etype == "Wind") Rate = 0.5f;
                break;
            default:
                break;
        }
        
        return Rate;
    }

    // 魔法のダメージを返す
    int RecipeEffect(string r)
    {
        switch (r)
        {
            case "Fire3":
                return 750;
            case "Fire2":
                return 400;
            case "Fire":
                return 250;
            case "Wind3":
                return 750;
            case "Wind2":
                return 400;
            case "Wind":
                return 250;
            case "Water3":
                return 750;
            case "Water2":
                return 400;
            case "Water":
                return 250;
            default:
                break;
        }

        return 100;
    }
 
}