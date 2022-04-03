using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using GameSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private GameObject fullPartyText;

    [SerializeField]
    private GameObject npcBlockPrefab;

    //For Mansion scene
    [SerializeField]
    private GameObject cancelButton;

    private PlayerController player;

    [Header("Pointer references")]

    [SerializeField]
    private Challenge currentChallengeHolder;


    private void Awake()
    {
        partyUIinstance = this;
    }


    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        currentPartyPeople = GameManager.Instance.PlayerParty.People.Count;
    }


    /// <summary>
    /// Destroys all npc blocks under partycanvas-->panel //Not gonna be used
    /// </summary>
    public void DestroyAllChild_NPCblocks()
    {
        for (int i = currentPartyPeople - 1; i >= 0; i--)
        {
            Destroy(PartyCanvas.transform.GetChild(i).gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentPartyPeople = GameManager.Instance.PlayerParty.People.Count;

            //Sets when the NPC Canvas is reset
            if (PartyCanvas.activeSelf)
            {
                PartyCanvas.SetActive(false);
                return;
            }
            else
            {
                if (currentPartyPeople > 0)
                {
                    //Do this because, If this object was active, make sure to deactivate it
                    emptyPartyText.SetActive(false);
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
        for (int i = 0; i < GameManager.Instance.PlayerParty.People.Count; i++)
        {
            GameObject npcBlockObj = GameObject.Instantiate(npcBlockPrefab, PartyCanvas.transform);

            //Do this while setting NPC block in Mansion scene only and add button function then only
            if (SceneManager.GetActiveScene().name == "MansionTest")
                npcBlockObj.transform.GetChild(6).GetComponent<Button>().onClick.AddListener(buttonOnClickPersonBlock);
            SetPartyBlockValues(npcBlockObj, i);
        }
    }


    /// <summary>
    /// This function sets all the hired npc person's values in the Party UI
    /// </summary>
    void SetPartyBlockValues(GameObject npcBlockObj, int personIndex)
    {
        npcBlockObj.GetComponent<PersonBlockUI>().person = GameManager.Instance.PlayerParty.People[personIndex];
        npcBlockObj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = GameManager.Instance.PlayerParty.People[personIndex].Name; //For name
        npcBlockObj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = GameManager.Instance.PlayerParty.People[personIndex].Title; //For Title
        npcBlockObj.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = GameManager.Instance.PlayerParty.People[personIndex].Strength.ToString(); //For Strength
        npcBlockObj.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = GameManager.Instance.PlayerParty.People[personIndex].Dexterity.ToString(); //For Dexterity
        npcBlockObj.transform.GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = GameManager.Instance.PlayerParty.People[personIndex].Intelligence.ToString(); //For Intelligence
        if (GameManager.Instance.PlayerParty.People[personIndex].HeldEquipment == null)
        {
            npcBlockObj.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = "Nothing equipped";
        }
        else
        {
            npcBlockObj.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = GameManager.Instance.PlayerParty.People[personIndex].HeldEquipment.Name; // For Equipment
        }
        //Still need to write logic for this
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



    /// <summary>
    /// To be executed in the mansion scene
    /// </summary>
    public void StartPersonSelect(Challenge challenge)
    {
        if (GameManager.Instance.PlayerParty.People.Count > 0)
        {
            currentChallengeHolder = challenge;
            Cursor.visible = true;
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

    /// <summary>
    /// Activate NPC block buttons for Mansion Scene
    /// </summary>
    void ActivateButtons()
    {
        for (int i = 0; i < GameManager.Instance.PlayerParty.People.Count; i++)
            PartyCanvas.transform.GetChild(i).GetChild(6).gameObject.SetActive(true); //Hardcoded now but change later
    }


    /// <summary>
    /// Deactivate NPC block buttons for Mansion Scene
    /// </summary>
    void DeActivateButtons()
    {
        for (int i = 0; i < GameManager.Instance.PlayerParty.People.Count; i++)
            PartyCanvas.transform.GetChild(i).GetChild(6).gameObject.SetActive(false);
    }


    /// <summary>
    /// TO be executed in the mansion scene 
    /// </summary>
    public void buttonOnClickPersonBlock()
    {
        GameObject personBlockButton = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        Person p = personBlockButton.GetComponent<PersonBlockUI>().person;

        currentChallengeHolder.Attempt(p);

        //Closing the button components and UI (for assigning person to a task)
        //Setting the player to walk again
        p = null;
        personBlockButton.SetActive(false);
        DeActivateButtons();
        PartyCanvas.SetActive(false);
        cancelButton.SetActive(false);
        EnablePlayerController();
        ReleaseAnyHolderReferences();
        Cursor.visible = false;
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
        EnablePlayerController();
        ReleaseAnyHolderReferences();
    }


    public void ShowAndVanishFullPartyText()
    {
        StartCoroutine(ActiveAndDisappearObject(2f,fullPartyText));
    }

    //---------PARTY EQUIPMENT SELECT---------

    /// <summary>
    /// Shows Party UI (in Bar Scene)
    /// </summary>
    public void EquipPersonSelect()
    {
        if (GameManager.Instance.PlayerParty.People.Count > 0)
        {
            Cursor.visible = true;
            PartyCanvas.SetActive(true);
            ShowNPCBlocks();
            ActivateButtons();
            StopPlayerController();
        }
        else
        {
            StartCoroutine(ActiveAndDisappearObject(2f, emptyPartyText));
        }
    }

    /// <summary>
    /// Get reference to person from Party UI
    /// </summary>
    /// <returns>Reference to Person from Party UI</returns>
    public Person SelectPerson()
    {
        GameObject personBlockButton = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        Person p = personBlockButton.GetComponent<PersonBlockUI>().person;

        return p;
    }

    /// <summary>
    /// Disables Party UI after clicking
    /// </summary>
    public void onPersonBlockClick()
    {
        GameObject personBlockButton = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        Person p = personBlockButton.GetComponent<PersonBlockUI>().person;

        //Closing the button components and UI (for assigning person to a task)
        //Setting the player to walk again

        p = null;
        personBlockButton.SetActive(false);
        DeActivateButtons();
        PartyCanvas.SetActive(false);
        EnablePlayerController();
        ReleaseAnyHolderReferences();
        Cursor.visible = false;
    }
}