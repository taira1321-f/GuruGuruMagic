using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int level { get; set; }
    public int maxhp { get; set; }
    public int nowhp { get; set; }
    public int power { get; set; }
    public string type { get; set; }

    public Player()
    {
        level = 1;
        maxhp = 100;
        nowhp = maxhp;
        power = 10;
        type = "RED";
    }

}

public class PlayerState : MonoBehaviour
{

    void SetPlayerState(Player p)
    {
        p.level = 1;
        p.maxhp = 10;
        p.nowhp = p.maxhp;
        p.power = 10;
        p.type = "RED";
    }

    void Heal(int heal, Player p)
    {
        p.nowhp += heal;
        if (p.nowhp > p.maxhp) p.nowhp = p.maxhp;
    }

    void GetDamage(int dmg, Player p)
    {
        p.nowhp -= dmg;
        if (p.nowhp < 0) p.nowhp = 0;
    }

}
