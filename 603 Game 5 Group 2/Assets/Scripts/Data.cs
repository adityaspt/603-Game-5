using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public int deathCount;

    public Data(Player player)
    {
        player.deathCount = deathCount;
    }
}