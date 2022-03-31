using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using GameSystems;
using UnityEngine.UI;

public class PartyUI : MonoBehaviour
{
    public static PartyUI partyUIinstance;

    [SerializeField]
    private GameObject PartyCanvas;

    [SerializeField]
    private int currentPartyPeople;

    [SerializeField]
    private GameObject emptyPartyText;

    [SerializeField]
    private GameObject cancelButton; //For Mansion scene

    private PlayerController player;

    private void Awake()
    {
        partyUIinstance = this;
    }

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        currentPartyPeople= GameManager.Instance.PlayerParty.People.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            print("Tab button");
            currentPartyPeople = GameManager.Instance.PlayerParty.People.Count;
            if (PartyCanvas.activeSelf) //Sets when the NPC Canvas is reset
            {
                PartyCanvas.SetActive(false);
                return;
            }
            else
            {
                if (currentPartyPeople > 0)
                {
                    emptyPartyText.SetActive(false); //If this object was active, make sure to deactivate it
                    PartyCanvas.SetActive(true);
                    ShowNPCBlocks();
                }
                else
                {
                    StartCoroutine(ActiveAndDisappearObject(2f, emptyPartyText));
                }
            }
        }
    }

    /// <summary>
    /// This Function loads the required number of NPC blocks in party UI and then calls SetPartyValues function
    /// </summary>
    public void ShowNPCBlocks()
    {
        //currentPartyPeople = GameManager.Instance.PlayerParty.People.Count;
        print(GameManager.Instance.PlayerParty.People.Count + " people in party");
        for (int i = 0; i < GameManager.Instance.PlayerParty.People.Count; i++)
            PartyCanvas.transform.GetChild(i).gameObject.SetActive(true);
        SetPartyValues();
    }

    /// <summary>
    /// This function sets all the hired npc person's values in the Party UI
    /// </summary>
    void SetPartyValues()
    {
        for (int i = 0; i < GameManager.Instance.PlayerParty.People.Count; i++)
        {
            PartyCanvas.transform.GetChild(i).GetComponent<PersonBlockUI>().person = GameManager.Instance.PlayerParty.People[i];
            PartyCanvas.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = GameManager.Instance.PlayerParty.People[i].Name; //For name
            PartyCanvas.transform.GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text = GameManager.Instance.PlayerParty.People[i].Title; //For Title
            PartyCanvas.transform.GetChild(i).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = GameManager.Instance.PlayerParty.People[i].Strength.ToString(); //For Strength
            PartyCanvas.transform.GetChild(i).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = GameManager.Instance.PlayerParty.People[i].Dexterity.ToString(); //For Dexterity
            PartyCanvas.transform.GetChild(i).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = GameManager.Instance.PlayerParty.People[i].Intelligence.ToString(); //For Intelligence
                                                                                                                                                                             //Still need to write logic for this
                                                                                                                                                                             // PartyCanvas.transform.GetChild(i).GetChild(5).GetComponent<TextMeshProUGUI>().text = GameManager.Instance.PlayerParty.People[i].HeldEquipment.Name.ToString(); //For Equipment
        }
    }

    /// <summary>
    /// Appear and disappear coroutine, Use it anywhere this script is used
    /// </summary>
    /// <param name="waitTime">Set the timing of disappering</param>
    /// <param name="g">Function acts on the gameobject</param>
    /// <returns></returns>
    public IEnumerator ActiveAndDisappearObject(float waitTime, GameObject g)
    {
        g.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        g.SetActive(false);
        print("disappear " + g);
    }

    /// <summary>
    /// Stop the player movement and animation if any
    /// </summary>
    void StopPlayerController()
    {
        player.playerAnimator.SetFloat("Speed", 0); //Stop the player's animation with speed parameter in animator
        player.GetComponent<PlayerController>().enabled = false;
    }

    Challenge currentChallengeHolder;

    /// <summary>
    /// To be executed in the mansion scene
    /// </summary>
    public void StartPersonSelect(Challenge challenge)
    {
        if (GameManager.Instance.PlayerParty.People.Count > 0)
        {
            currentChallengeHolder = challenge;
            Cursor.visible = true;
            //currentPartyPeople = GameManager.Instance.PlayerParty.People.Count;
            PartyCanvas.SetActive(true);
            cancelButton.SetActive(true);
            ShowNPCBlocks();
            ActivateButtons();
            StopPlayerController();
        }
        else
        {
            StartCoroutine(ActiveAndDisappearObject(2f, emptyPartyText));
        }
    }

    void ActivateButtons()
    {
        for (int i = 0; i < GameManager.Instance.PlayerParty.People.Count; i++)
            PartyCanvas.transform.GetChild(i).GetChild(6).GetComponent<Button>().gameObject.SetActive(true); //Hardcoded now but change later
    }

    void DeActivateButtons()
    {
        for (int i = 0; i < 4; i++)
            PartyCanvas.transform.GetChild(i).GetChild(6).GetComponent<Button>().gameObject.SetActive(false); //Hardcoded now but change later
    }


    /// <summary>
    /// TO be executed in the mansion scene 
    /// </summary>
    public void pressPersonBlock()
    {
        GameObject personBlockButton = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        Person p = personBlockButton.GetComponent<PersonBlockUI>().person;
        //print("Person clicked " + p.Name);
        //currentChallengeHolder.Attempt(GameManager.Instance.PlayerParty.People[0]);
        currentChallengeHolder.Attempt(p);

        //Closing loop
        p = null;
        personBlockButton.SetActive(false);
        DeActivateButtons();
        PartyCanvas.SetActive(false);
        cancelButton.SetActive(false);
        print("Current party member count " + GameManager.Instance.PlayerParty.People.Count);
        EnablePlayerController();
        ReleaseAnyHolderReferences();
    }

    /// <summary>
    /// Move the player again, after freezing them
    /// </summary>
    void EnablePlayerController()
    {
        player.GetComponent<PlayerController>().enabled = true;
    }

    /// <summary>
    /// Clear all the holder variables
    /// </summary>
    void ReleaseAnyHolderReferences()
    {
        currentChallengeHolder = null;
    }


    /// <summary>
    /// On clicking the cancel button
    /// </summary>
    public void CancelPersonSelect()
    {
        PartyCanvas.SetActive(false);
        cancelButton.SetActive(false);
        print("Current party member count " + GameManager.Instance.PlayerParty.People.Count);
        EnablePlayerController();
        ReleaseAnyHolderReferences();
    }
}