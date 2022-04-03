// Base code source: Katarina Tretter

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GameSystems;

public class ButtonManager : MonoBehaviour
{
    [Tooltip("UI Manager")][SerializeField] private GameObject uI;
    [Tooltip("Game Manager")][SerializeField] private GameObject gM;
    [Tooltip("EquipmentGiver")][SerializeField] private GameObject eG;

    //---------GENERAL BUTTONS---------

    public void OnStart()
    {
        Debug.Log("Clicked Start");
        Time.timeScale = 1;
        SceneManager.LoadScene("BarScene");
    }

    public void OnResume()
    {
        Debug.Log("Clicked Resume");
        uI.GetComponent<UIManager>().ButtonPress("resume");
    }

    public void OnPause()
    {
        Debug.Log("Clicked Pause");
        uI.GetComponent<UIManager>().ButtonPress("pause");
    }

    public void OnOptions()
    {
        Debug.Log("Clicked Options");
        uI.GetComponent<UIManager>().ButtonPress("options");
    }

    public void OnBack()
    {
        Debug.Log("Clicked Back");
        uI.GetComponent<UIManager>().ButtonPress("back");
    }

    public void OnCredits()
    {
        Debug.Log("Clicked Credits");
        SceneManager.LoadScene("CreditsMenu");
    }

    public void OnMainMenu()
    {
        Debug.Log("Clicked Main Menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void OnQuit()
    {
        Debug.Log("Clicked Quit");
        Application.Quit();
    }

    public void OnShop()
    {
        Debug.Log("Clicked Shop");
        SceneManager.LoadScene("ShopMenu");
    }

    public void OnCustomize()
    {
        Debug.Log("Clicked Customize");
        SceneManager.LoadScene("CustomizeMenu");
    }

    public void OnInventory()
    {
        Debug.Log("Clicked Inventory");
        uI.GetComponent<UIManager>().ButtonPress("inventory");
    }

    //---------EQUIPMENT---------
    public void OnEquip()
    {
        eG = GameObject.Find("EquipmentGiver");
        Text t = transform.GetComponentInChildren<Text>();
        Debug.Log(t.text);

        // Finding equipment based on text
        foreach (Equipment e in eG.GetComponent<EquipmentGiver>().AvailableEquipment)
        {
            if (e.Name == t.text)
            {
                Debug.Log("Equipment Match");
                eG.GetComponent<EquipmentGiver>().ShowEquipmentParty();
                eG.GetComponent<EquipmentGiver>().ChooseEquipment(e);
            }
        }
    }

    public void OnCloseEquip()
    {
        Debug.Log("Clicked Equip Close");
        uI.GetComponent<UIManager>().ButtonPress("equip");
        Time.timeScale = 1;
    }

    public void OnPersonClick()
    {
        eG = GameObject.Find("EquipmentGiver");
        Debug.Log("Clicked on Person");
        GameObject personBlockButton = transform.parent.gameObject;
        Person p = personBlockButton.GetComponent<PersonBlockUI>().person;

        eG.GetComponent<EquipmentGiver>().ChooseEquipment(p);
    }
}
