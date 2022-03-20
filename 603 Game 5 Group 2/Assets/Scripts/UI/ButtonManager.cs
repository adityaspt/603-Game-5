// Base code source: Katarina Tretter

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [Tooltip("UI Manager")][SerializeField] private GameObject uI;
    [Tooltip("Game Manager")][SerializeField] private GameObject gM;

    //---------GENERAL BUTTONS---------

    public void OnStart()
    {
        Debug.Log("Clicked Start");
        Time.timeScale = 1;
        //SceneManager.LoadScene("GameScene");
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
        //uI.GetComponent<UIManager>().ButtonPress("options");
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
}