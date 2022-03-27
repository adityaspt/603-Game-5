using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public string[] namesOfPeople;
    public int deathCount;
    public string[] dead;

    public Data(Player player)
    {
        player.name1 = namesOfPeople[0];
        player.name2 = namesOfPeople[1];
        player.deathCount = deathCount;
        player.name1 = dead[0];
        //deathCount;
/*        foreach(string name in namesOfPeople)
        {

        }*/
    }
}