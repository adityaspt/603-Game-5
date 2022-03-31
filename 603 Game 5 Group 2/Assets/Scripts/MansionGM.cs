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

    private void Awake()
    {
        mansionGMInstance = this;
    }


    public void EndGameUI()
    {
        endgameUI.SetActive(true);
        deathCountVal.GetComponent<TextMeshProUGUI>().text = 100.ToString(); //Set the death count value here
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
