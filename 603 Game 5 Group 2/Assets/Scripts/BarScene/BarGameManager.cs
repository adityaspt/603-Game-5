using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameSystems;

public class BarGameManager : MonoBehaviour
{
    public static BarGameManager barGameManagerInstance;

    [Header("Player Reference")]
    [SerializeField]
    private PlayerController player;

    [Header("NPC References")]
    [SerializeField]
    private List<Sprite> npcSprites;

    [SerializeField]
    List<GameObject> npcObjects;

    [Header("References for NPC Canvas")]
    [SerializeField]
    private GameObject npcCanvas;

    [SerializeField]
    private GameObject nameValue;

    [SerializeField]
    private GameObject professionValue;

    [SerializeField]
    private GameObject pictureValue;


    [Header("Reference holders for each current NPC")]
    [SerializeField]
    Person CurrentbarNPC;

    [SerializeField]
    GameObject CurrentNPCGameObject;

    [Header("NPC Canvas")]
    [SerializeField]
    GameObject partyCanvas;


    private void Start()
    {
        foreach(GameObject npc in npcObjects)
        {
            npc.GetComponent<SpriteRenderer>().sprite = npcSprites[UnityEngine.Random.Range(0, npcSprites.Count)];
        }
    }


    public void openNPCcanvas(object sender, EventTriggerSet.eventTrigger e)
    {
        Cursor.visible = true;
        StopPlayerController();
        npcCanvas.SetActive(true);
        partyCanvas.SetActive(false); //If party canvas was open it will turnoff to avoid redundancy
        SetNPCcanvas(e);
    }

    /// <summary>
    /// Sets up the NPC interactable canvas
    /// </summary>
    /// <param name="e">Event parameters check the EventTriggerSet class</param>
    void SetNPCcanvas(EventTriggerSet.eventTrigger e)
    {
        nameValue.GetComponent<TextMeshProUGUI>().text =e.personReference.Name ;
        professionValue.GetComponent<TextMeshProUGUI>().text = e.personReference.Title;
        CurrentbarNPC = e.personReference;
        CurrentNPCGameObject = e.personGameobjectReference;
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
    /// Close the NPC interactable canvas
    /// </summary>
    void closeNPCcanvas()
    {
        Cursor.visible = false;
        npcCanvas.SetActive(false);
    }

    /// <summary>
    /// Yes button in NPC interactable canvas on click calls this function
    /// </summary>
    public void RecruitYesButton()
    {
        closeNPCcanvas();
        player.GetComponent<PlayerController>().enabled = true;
        GameManager.Instance.PlayerParty.Hire(CurrentbarNPC);
        print("Party man title " + GameManager.Instance.PlayerParty.People[0].Title);
        if (GameManager.Instance.PlayerParty.People.Count>0) // Do this only if party people are more than 0 //Test again later this maybe useless
        {
            StartCoroutine(PartyUI.partyUIinstance.ActiveAndDisappearObject(3, partyCanvas));
            PartyUI.partyUIinstance.ShowNPCBlocks();
        }
        Destroy(CurrentNPCGameObject);
    }

    /// <summary>
    /// No button in NPC interactable canvas on click calls this function
    /// </summary>
    public void RecruitNoButton()
    {
        closeNPCcanvas();
        player.GetComponent<PlayerController>().enabled = true;
        ReleaseNPCHolderReferences();
    }

    /// <summary>
    /// Clear all the temporary variables for CurrentbarNPC and CurrentNPCGameObject
    /// </summary>
    void ReleaseNPCHolderReferences()
    {
        CurrentbarNPC = null;
        CurrentNPCGameObject = null;
    }

}
