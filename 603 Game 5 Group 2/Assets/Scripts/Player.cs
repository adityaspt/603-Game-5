using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public Player player;
    public int deathCount;
    public GameManager gameManager;
    //for testing purposes, will be filled in later

    public void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void Update()
    {
        deathCount = gameManager.deathCount;
        print(deathCount + " " + gameManager.deathCount);
    }
    public void SaveData()
    {
        DataCollection.CollectData(this);
    }
}
