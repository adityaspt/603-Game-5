using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MansionGM : MonoBehaviour
{
    public static MansionGM mansionGMInstance;

    [SerializeField]
    GameObject endgameUI;

    [SerializeField]
    GameObject deathCountVal;
    private Player player;

    private void Awake()
    {
        mansionGMInstance = this;
    }


    //public void EndGameUI()
    //{
    //    endgameUI.SetActive(true);
    //    deathCountVal.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.DeathCount.ToString(); //Set the death count value here
    //}

    public void QuitGame()
    {
        player.SaveData();
        Application.Quit();
    }
    private void OnApplicationQuit()
    {
        
    }
}
