using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //Grab the player's exit action at the door only if the count is 4 and above
    {
        if (collision.CompareTag("Player"))
        {
            //if (GameManager.Instance.PlayerParty.People.Count >0)
            if (SceneManager.GetActiveScene().name == "BarScene")
            {
                GameManager.Instance.isStartingFromBar = true;
                print("Exit from bar");
                //Load the mansion scene here
                SceneManager.LoadScene("Driving Minigame");
            }
            else if (SceneManager.GetActiveScene().name == "MansionTest") {
                GameManager.Instance.isStartingFromBar = false;
                GameManager.Instance.storedAllChallenges = false; //Need to store all challenges again when we come back to Mansion scene
                SceneManager.LoadScene("Driving Minigame");
                print("Exit from mansion");
            }
            else
            {
                print("Exit from unknown");
                //Add code for car scene handle
            }


        }
    }
}
