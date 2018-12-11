using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerBase {

    rotarScript2 Guruguru;
    SpellRecipe2 Recipe;

    void Start()
    {
        Guruguru = gameObject.GetComponent<rotarScript2>();
        Recipe = gameObject.GetComponent<SpellRecipe2>();
    }

    public Player(int lv = 1)
    {
        Initialize();
        double LEVEL = (1 + (lv - 1) * 0.2);
        level = lv;
        maxhp = (int)(maxhp * LEVEL);
        nowhp = maxhp;
        power = (int)(power * LEVEL);
        defense = (int)(defense * LEVEL);
        type = type;
    }


    // ダメージ計算
    public int DamageCal(int power, Character.Elements type)
    {
        float dmg;  // ダメージの基礎値
        Character.Elements recipe;  // レシピの属性

        /* ダメージ計算式
         * 1.キャラの攻撃力をダメージの基礎値にする
         * 2.レシピを取得
         * 3.得意属性であればプレイヤーのレベルに応じてダメージアップ
         * 4.相手の属性相性を計算する
         * 5.鍋の回し具合を計算に入れる
         * */

        dmg = power;
        recipe = GetRecipe();
        if (recipe == type) dmg *= (1 / 20) * 2.0f;
        dmg *= Correction(type);
        dmg *= Guruguru.getGuruguru();

        return (int)dmg;
    }


    // レシピの取得(仮置き)
    public Character.Elements GetRecipe()
    {
        return Elements.BLUE;
    }

    // 相性の判定
    float Correction(Character.Elements type)
    {
        int pType = (int)(type - 1);
        int eType = (int)(Elements.RED - 1);

        return damageRate[pType, eType];
    }


 
}