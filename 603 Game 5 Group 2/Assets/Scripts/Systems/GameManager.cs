using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameSystems;

public class GameManager : MonoBehaviour {
    // Singleton stuff
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    // Awake is called before everything else
    private void Awake() {
        if(_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Variables
    private Party playerParty;
    public Party PlayerParty {
        get { return playerParty; }
    }

    // Start is called before the first frame Update
    void Start() {

        // Move to the main menu
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update() {
        
    }
}
