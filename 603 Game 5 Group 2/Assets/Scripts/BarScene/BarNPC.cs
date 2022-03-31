using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystems;
using System;

public class BarNPC : MonoBehaviour
{
    public event EventHandler<EventTriggerSet.eventTrigger> onInteractBarNPC;

    [Header("References")]
    [SerializeField]
    BarGameManager barGM;

    [Header("Check the assigned person values to this object")]
    [SerializeField]
    string personName = "";

    [SerializeField]
    string profName = "";

    Person person;

    private void OnEnable()
    {
        onInteractBarNPC += barGM.openNPCcanvas; //Subscribe the openNPCCanvas function to this event
    }

    private void OnDisable()
    {
        onInteractBarNPC -= barGM.openNPCcanvas; //UnSubscribe the openNPCCanvas function to this event
    }

    // Start is called before the first frame update
    void Start()
    {
        person = new Person(); //IMP!! Sets the new person values from Gamesystems//Thanks CJ!
        personName = person.Name;
        profName = person.Title;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.Instance.PlayerParty.People.Count >= 4)
                return;
            onInteractBarNPC?.Invoke(this, new EventTriggerSet.eventTrigger
            {
              personReference=person,
              personGameobjectReference=this.gameObject
            }) ; //Pass the person value and gameobject to the event while invoke
        }
    }
}
