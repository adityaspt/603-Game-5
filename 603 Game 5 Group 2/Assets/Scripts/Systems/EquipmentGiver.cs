using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystems;

public class EquipmentGiver : MonoBehaviour {
    [SerializeField]
    private Sprite availableSprite;
    [SerializeField]
    private Sprite unavailableSprite;

    [SerializeField]
    private GameObject equipmentChooseUI;
    [SerializeField]
    private GameObject partyChooseUI;

    private bool available;


    private Equipment[] availableEquipment;
    public Equipment[] AvailableEquipment {
        get { return availableEquipment; }
    }

    private Equipment chosenEquipment;
    public Equipment ChosenEquipment {
        get { return chosenEquipment; }
    }

    // Start is called before the first frame update
    void Start() {
        available = GameManager.Instance.ChallengeCompleted;
        if(available) {
            GetComponent<SpriteRenderer>().sprite = availableSprite;
            availableEquipment = new Equipment[3];
            for(int i = 0; i < availableEquipment.Length; i++) {
                availableEquipment[i] = new Equipment();
            }
        } else {
            GetComponent<SpriteRenderer>().sprite = unavailableSprite;
        }
    }

    /// <summary>
    /// Chooses the equipment and hides the selection UI
    /// </summary>
    /// <param name="index"></param>
    public void ChooseEquipment(int index) {
        if(index < 0) {
            index = 0;
        } else if(index >= availableEquipment.Length) {
            index = availableEquipment.Length - 1;
        }

        // Choose the equipment
        ChooseEquipment(availableEquipment[index]);
    }

    /// <summary>
    /// Chooses the equipment and hides the selection UI
    /// </summary>
    /// <param name="e"></param>
    public void ChooseEquipment(Equipment e) {
        chosenEquipment = e;
        equipmentChooseUI.SetActive(false);
        available = false;
        GetComponent<SpriteRenderer>().sprite = unavailableSprite;
        GameManager.Instance.ChallengeCompleted = false;

        // TODO: Show the PartyUI

        // TODO: Clicking a party member calls partyMember.Equip(chosenEquipment);
            // NOTE: I've made ChosenEquipment a public property, so if you need to access it from another script you can GetComponent<EquipmentGiver>().ChosenEquipment on this object
            // NOTE: The code for this may have to go into another file. I'm just writing these comments here to keep them all in one place
            // NOTE: Person.ForceEquip overrides previous equipment, Person.Equip does not and returns false if the Person already has one
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(available) {
            if(collision.gameObject.CompareTag("Player")) {
                // TODO: Populate EquipmentChooseUI with the items in availableEquipment

                // Show the ui
                equipmentChooseUI.SetActive(true);

                // TODO: Clicking an equipment equipmentGiver.ChooseEquipment(whateverEquipmentYouJustClickedOn);
                    // NOTE: I've made ChooseEquipment a public method, so if you need to access it from another script you can GetComponent<EquipmentGiver>().ChooseEquipment on this object
                    // NOTE: The code for this may have to go into another file. I'm just writing these comments here to keep them all in one place
                    // NOTE: I created an overload of ChooseEquipment that takes in an int. That int corresponds to the index of the equipment in the AvailableEquipment array. Use
                    //            whichever one you want.
            }
        }
    }
}
