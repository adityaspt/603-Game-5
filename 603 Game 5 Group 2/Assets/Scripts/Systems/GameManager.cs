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

    [SerializeField]
    private List<Sprite> playerSprites;
    public List<Sprite> PlayerSprites {
        get { return playerSprites; }
    }

    [SerializeField]
    public bool isStartingFromBar = false;

    // Start is called before the first frame Update
    void Start() {

        playerParty = new Party();
        Cursor.visible = false;
        // Move to the main menu
        //SceneManager.LoadScene("MainMenu");
        SceneManager.LoadScene("BarScene"); //Change this later*****
    }

    // Update is called once per frame
    void Update() {
        
    }
}
