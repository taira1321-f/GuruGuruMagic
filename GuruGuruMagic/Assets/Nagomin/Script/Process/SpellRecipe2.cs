using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellRecipe2 : PlayerBase
{
    [SerializeField]
    [Header("鍋に入っている石の情報")]
    Stack<string> stack;

    const int STACK_MAX = 4;// 石の個数の上限
    const int STACK_MIN = 2;// 石の個数の下限
    
    // Use this for initialization
    void Start()
    {
        Stack<string> stack = new Stack<string>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Push(string jewel)
    {
        if (stack.Count < STACK_MAX) stack.Push(jewel);
    }

    public void StackCnt(Stack<string> s)
    {
        short greenCount = 0;
        short blueCount = 0;
        short redCount = 0;

        if (s.Count >= STACK_MIN)
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

            stack.Clear();

            //for (int i = s.Count; i >= 0; i--)
            //{
            //    string jewel = s.Pop();
            //    switch (jewel)
            //    {
            //        case "eme":
            //            greenCount++;
            //            break;
            //        case "sap":
            //            blueCount++;
            //            break;
            //        case "ruby":
            //            redCount++;
            //            break;
            //        default:
            //            break;
            //    }
            //}
        }

    }

    public Character.Elements GetRecipe()
    {
        short greenCount = 0;
        short blueCount = 0;
        short redCount = 0;

        if (greenCount == 4 || greenCount == 3 || greenCount == 2)
        {
            return Elements.GREEN;
        }
        if (blueCount == 4 || blueCount == 3 || blueCount == 2)
        {
            return Elements.BLUE;
        }
        if (redCount == 4 || redCount == 3 || redCount == 2)
        {
            return Elements.RED;
        }
        if (redCount == 1 & blueCount == 1 || redCount == 2 & blueCount == 2)
        {
            return Elements.VENOM;
        }
        if (redCount == 1 & greenCount == 1)
        {
            return Elements.HEAL;
        }
        if (redCount == 2 & greenCount == 2)
        {
            return Elements.PHEAL;
        }
        if (blueCount == 1 & greenCount == 1 || blueCount == 2 & greenCount == 2)
        {
            return Elements.JAMA;
        }
        if (blueCount == 2 & redCount == 1)
        {
            return Elements.BUFF;
        }
        if (blueCount == 1 & greenCount == 2)
        {
            return Elements.GUARD;
        }
        if (redCount == 1 & greenCount == 2)
        {
            return Elements.BOOST;
        }

        return Elements.NONE;

    }



}
