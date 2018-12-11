using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : Character
{
    public override void Initialize()
    {
        level = 1;
        maxhp = 500;
        nowhp = maxhp;
        power = 50;
        defense = 50;
        type = Elements.RED;
    }

}