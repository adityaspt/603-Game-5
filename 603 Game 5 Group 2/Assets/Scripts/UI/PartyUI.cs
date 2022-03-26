using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PartyUI : MonoBehaviour
{
    public static PartyUI partyUIinstance;

    [SerializeField]
    private GameObject PartyCanvas;

    [SerializeField]
    private int currentPartyPeople;

    [SerializeField]
    private GameObject emptyPartyText;


    private void Awake()
    {
        partyUIinstance = this;
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
        currentPartyPeople = GameManager.Instance.PlayerParty.People.Count;
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
            PartyCanvas.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = GameManager.Instance.PlayerParty.People[i].Name; //For name
            PartyCanvas.transform.GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text = GameManager.Instance.PlayerParty.People[i].Title; //For Title
            PartyCanvas.transform.GetChild(i).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = GameManager.Instance.PlayerParty.People[i].Strength.ToString(); //For Strength
            PartyCanvas.transform.GetChild(i).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = GameManager.Instance.PlayerParty.People[i].Strength.ToString(); //For Dexterity
            PartyCanvas.transform.GetChild(i).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = GameManager.Instance.PlayerParty.People[i].Strength.ToString(); //For Intelligence
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
}