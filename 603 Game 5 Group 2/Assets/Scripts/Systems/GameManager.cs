using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameSystems;
using System.Linq;

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

    [SerializeField]
    public bool storedAllChallenges = false;


    public int deathCount = 0;
    public int DeathCount {
        get { return deathCount; }
        set { deathCount = value; }
    }

    private bool challengeCompleted = true;
    public bool ChallengeCompleted {
        get { return challengeCompleted; }
        set { challengeCompleted = value; }
    }

    // Start is called before the first frame Update
    void Start() {

        playerParty = new Party();
        Cursor.visible = true;

        // Move to the main menu
        //SceneManager.LoadScene("MansionTest");
        SceneManager.LoadScene("MainMenu"); //Change this later*****

        //Testing
       
        //playerParty.People.Add(new Person());

    }

    // Update is called once per frame
    void Update() {

    }
}
