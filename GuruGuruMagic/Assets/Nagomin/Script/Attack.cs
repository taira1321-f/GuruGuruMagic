using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    Player player = new Player();
    Enemy enemy = new Enemy();

    /* 属性の相性的な
     * 要素はダメージの倍率
     */
    float[,] damageRate = new float[,] {
        { 1.0f, 0.5f, 1.5f },   // 赤
        { 1.5f, 1.0f, 0.5f },   // 青
        { 0.5f, 1.5f, 1.0f },   // 緑
    };

    void Start()
    {
        int damage = DamageCal(player.power, player.type);
        Debug.Log("与えたダメージ：" + damage);
    }

    public int DamageCal(int power, string type)
    {
        float dmg;

        /* ダメージ計算式
         * 1.キャラの攻撃力をダメージの基礎値にする
         * 2.得意属性であればプレイヤーのレベルに応じてダメージアップ
         * 3.相手の属性相性を計算する
         * */
        dmg = power;
        if (IsSpecialty(type)) dmg *= (player.level / 20) * 2.0f;
        dmg *= Correction(player.type);

        return (int)dmg;
    }

    // 得意な属性かどうか
    bool IsSpecialty(string type)
    {
        if (player.type == type) return true;
        return false;
    }

    // 相性の判定
    float Correction(string type)
    {
        CharaState cs = new CharaState();
        int pType = cs.TypeToInt(type);
        int eType = cs.TypeToInt(enemy.type);

        return damageRate[pType, eType];
    }

}
