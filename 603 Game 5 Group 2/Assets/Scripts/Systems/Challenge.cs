using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystems;
using System.Linq;

public class Challenge : MonoBehaviour
{
    [SerializeField]
    private string challengeTitle;
    /// <summary>
    /// The name of the challenge
    /// </summary>
    public string ChallengeTitle
    {
        get { return challengeTitle; }
    }

    [SerializeField]
    private int[] statScoreRequirements;
    /// <summary>
    /// The stat score requirements to succeed in the challenge. [Strength, Dexterity, Intelligence]
    /// </summary>
    public int[] StatScoreRequirements
    {
        get { return StatScoreRequirements; } //Should be swaped with private variable??
    }

    [SerializeField]
    private string successText;
    /// <summary>
    /// The text to be printed when a person succeeds
    /// </summary>
    public string SuccessText
    {
        get { return successText; }
    }

    [SerializeField]
    private string[] failureTexts;
    /// <summary>
    /// The set of texts to be randomly picked from and printed when a Person fails
    /// </summary>
    public string[] FailureTexts
    {
        get { return failureTexts; }
    }

    [SerializeField]
    private bool isCompleted;
    /// <summary>
    /// Is this challenge completed yet?
    /// </summary>
    public bool IsCompleted
    {
        get { return isCompleted; }
    }

    [SerializeField]
    private Sprite incompleteSprite;
    /// <summary>
    /// The sprite to display when the challenge is not yet completed
    /// </summary>
    public Sprite IncompleteSprite
    {
        get { return incompleteSprite; }
    }

    [SerializeField]
    private Sprite completeSprite;
    /// <summary>
    /// The sprite to display when the challenge is completed
    /// </summary>
    public Sprite CompleteSprite
    {
        get { return completeSprite; }
    }

    // Start is called before the first frame update
    void Start()
    {
        isCompleted = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = incompleteSprite;

        //var listOfC = GameManager.Instance.cacheChallengeList;
        //if (listOfC.Contains(this))
        //{
        //  isCompleted =listOfC[listOfC.IndexOf(this)].IsCompleted;
        //}

    }

    /// <summary>
    /// Attempts the challenge with the given Person
    /// </summary>
    /// <param name="p"></param>
    public void Attempt(Person p)
    {
        // Bailout
        if (isCompleted)
        {
            Debug.LogError("You cannot attempt an already completed Challenge.");
            return;
        }

        // Setup the success
        bool success = true;

        // Roll the scores
        int[] statScore = p.RollStats();

        // Check the scores
        for (int i = 0; i < statScore.Length; i++)
        {
            if (statScore[i] < statScoreRequirements[i])
            {
                success = false;
            }
        }

        // Print out the roll
        string onScreenTitle = challengeTitle;
        string onScreenMessage = "";
        onScreenMessage += (p.Name + " scored " + statScore[0] + " in Strength, " + statScore[1] + " in Dexterity, and " + statScore[2] + " in Intelligence. ");

        // Resolve if success or not
        if (success)
        {
            // Print out the success message
            onScreenMessage += (p.Name + " " + successText);

            // Show the popup
            PopupSystem.Instance.ShowMessage(onScreenTitle, onScreenMessage);

            // Change the challenge sprite to a completed state
            gameObject.GetComponent<SpriteRenderer>().sprite = completeSprite;

            // Set completed to true
            isCompleted = true;

            GameManager.Instance.CheckIfAllChallengesAreDone();
        }
        else
        {
            // Print out a random failure message
            int failureIndex = Random.Range(0, failureTexts.Length);
            onScreenMessage += (p.Name + " " + failureTexts[failureIndex]);

            // Show the popup
            PopupSystem.Instance.ShowMessage(onScreenTitle, onScreenMessage);

            // Remove the Person from the Party
            GameManager.Instance.PlayerParty.People.Remove(p);
            //Increment death counter int here 
            GameManager.Instance.deathCount++;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsCompleted)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                print("Challenge " + challengeTitle + " hit");
                PartyUI.partyUIinstance.StartPersonSelect(this);
                //GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }
    }

}
