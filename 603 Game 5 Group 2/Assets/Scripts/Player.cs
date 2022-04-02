using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Player player;
    public string name1 = "Josh";
    public string name2 = "Jake";
    public int deathCount = 10;
//for testing purposes, will be filled in later
    public void SaveData()
    {
        DataCollection.CollectData(this);
    }
}
