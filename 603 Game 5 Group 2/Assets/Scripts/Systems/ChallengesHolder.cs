using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChallengesHolder : MonoBehaviour {
    // Singleton stuff
    private static ChallengesHolder _instance;
    public static ChallengesHolder Instance { get { return _instance; } }

    // Awake is called before everything else
    private void Awake() {
        if(_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [SerializeField]
    private GameObject endgameUI;

    [SerializeField]
    private TextMeshProUGUI deathCountVal;

    private string lastLoadedScene = "";

    [SerializeField]
    private List<GameObject> allChallenges;
    private List<Challenge> incompleteChallenges;
    public bool AllChallengesCompleted {
        get { return (incompleteChallenges.Count > 0); }
    }

    // Start is called before the first frame update
    void Start() {
        allChallenges = new List<GameObject>();
        incompleteChallenges = new List<Challenge>();
        for(int i = 0; i < transform.childCount; i++) {
            allChallenges.Add(transform.GetChild(i).gameObject);
            incompleteChallenges.Add(transform.GetChild(i).GetComponent<Challenge>());
        }
    }

    // Update is called once per frame
    void Update() {
        if(!SceneManager.GetActiveScene().name.Equals(lastLoadedScene)) {
            if(SceneManager.GetActiveScene().name.Equals("MansionTest")) {
                ShowChallenges();
                lastLoadedScene = SceneManager.GetActiveScene().name;
            } else {
                HideChallenges();
                lastLoadedScene = SceneManager.GetActiveScene().name;
            }
        }
    }

    public void CompleteChallenge(Challenge c) {
        incompleteChallenges.Remove(c);
        GameManager.Instance.ChallengeCompleted = true;
        if(incompleteChallenges.Count == 0) {
            EndGameUI();
        }
    }

    public void HideChallenges() {
        foreach(GameObject c in allChallenges) {
            c.gameObject.SetActive(false);
        }
    }

    public void ShowChallenges() {
        foreach(GameObject c in allChallenges) {
            c.gameObject.SetActive(true);
        }
    }

    public void EndGameUI() {
        foreach(GameObject c in allChallenges) {
            c.gameObject.SetActive(false);
        }

        print("End game UI");
        endgameUI.SetActive(true);
        deathCountVal.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.DeathCount.ToString(); //Set the death count value here
    }

    public void QuitGame() {
        Application.Quit();
    }
}
