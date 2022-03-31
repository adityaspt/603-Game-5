using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CarSceneTransition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Bar Entrance")
        {
            SceneManager.LoadScene("BarScene");
        }
        else if (other.gameObject.name == "Mansion Entrance")
        {
            Debug.Log("Check");
            SceneManager.LoadScene("MansionTest");
        }
    }
}
