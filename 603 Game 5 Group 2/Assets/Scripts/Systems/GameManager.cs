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
    private List<Challenge> challengeList;
    public List<Challenge> ChallengeList
    {
        get { return challengeList; }
    }


    public List<Challenge> cacheChallengeList; // For having a list to keep track of the previous challenges
    


    [SerializeField]
    public bool isStartingFromBar = false;

    [SerializeField]
    public bool storedAllChallenges = false;


    public int deathCount = 0;

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


    public void CheckIfAllChallengesAreDone()
    {
        bool isAllTrue = false;
        if (ChallengeList == null)
        {
            return;
        }
        foreach(Challenge c in ChallengeList)
        {
            if (!c.IsCompleted)
            {
                isAllTrue = false;
                break;
            }
            else
            {
                isAllTrue = true;
            }
        }
        if( isAllTrue)
        {
            MansionGM.mansionGMInstance.EndGameUI();
        }
    }

    // Update is called once per frame
    void Update() {
        //print("*** person count " + playerParty.People.Count);

        if (!storedAllChallenges && SceneManager.GetActiveScene().name== "MansionTest")
        {
            challengeList = GameObject.FindObjectsOfType<Challenge>().ToList();
            storedAllChallenges = true;
            //cacheChallengeList = challengeList.ToList();
        }
        if(storedAllChallenges && SceneManager.GetActiveScene().name == "BarScene")
        {
            storedAllChallenges = false;
        }

    }
}
