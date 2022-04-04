using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public Player player;
    public int deathCount=0;
    public GameManager gameManager;
    //for testing purposes, will be filled in later

    

    public static event EventHandler<EventArgs> onDeath;

    public void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void Update()
    {
        deathCount = gameManager.DeathCount;
        print("Death count " + deathCount + " " + gameManager.DeathCount);
    }
    public void SaveData()
    {
        DataCollection.CollectData(this);
    }

    public void SetDeathCount(object sender, EventArgs empty)
    {
        deathCount = gameManager.DeathCount;
        print(deathCount + " " + gameManager.deathCount);
    }

}
