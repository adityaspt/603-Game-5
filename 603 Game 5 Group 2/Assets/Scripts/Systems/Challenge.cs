using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystems;

public class Challenge : MonoBehaviour {
    [SerializeField]
    private string challengeTitle;
    /// <summary>
    /// The name of the challenge
    /// </summary>
    public string ChallengeTitle {
        get { return challengeTitle; }
    }

    [SerializeField]
    private int[] statScoreRequirements;
    /// <summary>
    /// The stat score requirements to succeed in the challenge. [Strength, Dexterity, Intelligence]
    /// </summary>
    public int[] StatScoreRequirements {
        get { return StatScoreRequirements; }
    }

    [SerializeField]
    private string successText;
    /// <summary>
    /// The text to be printed when a person succeeds
    /// </summary>
    public string SuccessText {
        get { return successText; }
    }

    [SerializeField]
    private string[] failureTexts;
    /// <summary>
    /// The set of texts to be randomly picked from and printed when a Person fails
    /// </summary>
    public string[] FailureTexts {
        get { return failureTexts; }
    }

    private bool isCompleted;
    /// <summary>
    /// Is this challenge completed yet?
    /// </summary>
    public bool IsCompleted {
        get { return IsCompleted; }
    }

    // Start is called before the first frame update
    void Start() {
        isCompleted = false;
    }

    /// <summary>
    /// Attempts the challenge with the given Person
    /// </summary>
    /// <param name="p"></param>
    public void Attempt(Person p) {
        // Bailout
        if(isCompleted) {
            Debug.LogError("You cannot attempt an already completed Challenge.");
            return;
        }

        // Setup the success
        bool success = true;

        // Roll the scores
        int[] statScore = p.RollStats();

        // Check the scores
        for(int i = 0; i < statScore.Length; i++) {
            if(statScore[i] < statScoreRequirements[i]) {
                success = false;
            }
        }

        // Resolve if success or not
        if(success) {
            /*
             * TODO:
             * 1) Print out the success message
             * 2) Change the challenge sprite to a completed state
             * 3) isCompleted = true;
             * 4) Close / do whatever menu management is needed
             * 
             */
        } else {
            /*
             * TODO:
             * 1) Print out a random failure message
             * 2) Remove the Person from the Party
             * 3) Close / do whatever menu management is needed
             * 
             */
        }
    }
}
