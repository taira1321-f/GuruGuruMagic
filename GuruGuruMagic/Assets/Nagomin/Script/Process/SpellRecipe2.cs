using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellRecipe2 : PlayerBase
{
    Stack<string> stack;

    const int STACK_MAX = 4;// 石の個数の上限
    public int stack_max { get { return STACK_MAX; } }
    const int STACK_MIN = 2;// 石の個数の下限
    public int stack_min { get { return STACK_MIN; } }
    
    // Use this for initialization
    void Start()
    {
        stack = new Stack<string>();
    }

    // スタックに石を入れる
    public void Push(string jewel)
    {
        if (stack.Count < STACK_MAX)  stack.Push(jewel);
    }

    // スタックに入っている石の個数を返す
    public int Count() {
        return stack.Count;
    }

    // 石の個数を調べて、レシピの内容を返す
    public string GetRecipe()
    {
        int jewelCount = stack.Count;
        short greenCount = 0;
        short blueCount = 0;
        short redCount = 0;

        // スタックの中の石の個数を数える
        if (stack.Count >= STACK_MIN)
        {
            foreach (string jewel in stack)
            {
                switch (jewel)
                {
                    case "eme":
                        greenCount++;
                        break;
                    case "sap":
                        blueCount++;
                        break;
                    case "ruby":
                        redCount++;
                        break;
                    default:
                        break;
                }
            }

            // スタックの中身をクリア
            stack.Clear();
            // 鍋の中身を削除
            foreach (Transform n in this.transform)
            {
                GameObject.Destroy(n.gameObject);
            }
        }
        
        // レシピを返す
        if (jewelCount >= STACK_MAX)
        {
            // 風(大)
            if (greenCount == 4) return "Wind3";
            // 水(大)
            if (blueCount >= 3) return "Water3";
            // 火(大)
            if (redCount >= 3) return "Fire3";
            // 猛毒
            if (redCount == 2 && blueCount == 2) return "DVenom";
            // スロウ(大)
            if (blueCount == 2 && greenCount == 2) return "Slow2";
            // 回復(大)
            if (redCount == 2 && greenCount == 2) return "Heal2";
        }

        else if (jewelCount == 3)
        {
            // 風(中)
            if (greenCount == 3) return "Wind2";
            // 水(中)
            if (blueCount == 3) return "Water2";
            // 火(中)
            if (redCount >= 3) return "Fire2";
            // 自分の攻撃力アップ
            if (blueCount == 2 && redCount == 1) return "Buff";
            // 自分の防御力アップ
            if (blueCount == 1 && greenCount == 2) return "Guard";
            // 次に混ぜる時間を短縮
            if (redCount == 1 && greenCount == 2) return "Boost";
        }

        else if (jewelCount <= STACK_MIN)
        {
            // 風
            if (greenCount == 2) return "Wind";
            // 水
            if (blueCount == 2) return "Water";
            // 火
            if (redCount == 2) return "Fire";
            // 毒
            if (redCount == 1 & blueCount == 1) return "Venom";
            // スロウ(小)
            if (blueCount == 1 & greenCount == 1) return "Slow";
            // 回復(小)
            if (redCount == 1 & greenCount == 1) return "Heal";
        }

        // どれでもない場合
        return "None";

    }



}
