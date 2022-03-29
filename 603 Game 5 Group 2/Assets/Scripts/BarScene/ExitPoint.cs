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
            if (GameManager.Instance.PlayerParty.People.Count >= 4)
            {
                GameManager.Instance.isStartingFromBar = true;
                print("Exit point hit only if the people count is 4 or greater");
                //Load the mansion scene here//SceneManager.LoadScene("GameScene or Mainsion Scene");
            }
        }
    }
}
