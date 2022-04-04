using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public int deathCountVal;

    public Data(Player player)
    {
        //player.deathCount = deathCount;
        deathCountVal = player.deathCount;
    }
}