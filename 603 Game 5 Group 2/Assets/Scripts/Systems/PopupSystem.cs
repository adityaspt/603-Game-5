using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSystem : MonoBehaviour {
    // Singleton stuff
    private static PopupSystem _instance;
    public static PopupSystem Instance { get { return _instance; } }

    public bool IsPopupOpen {
        get { return (messageWindow.activeInHierarchy || noticeWindow.activeInHierarchy); }
    }

    private string indentation = "     ";

    [SerializeField]
    private GameObject messageWindow = null;
    [SerializeField]
    private Text messageWindowTitle = null;
    [SerializeField]
    private Text messageWindowMessage = null;

    [SerializeField]
    private GameObject noticeWindow = null;
    [SerializeField]
    private Text noticeWindowMessage = null;

    // Awake is called before everything else
    private void Awake() {
        if(_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    /// <summary>
    /// Closes all popups
    /// </summary>
    private void CloseAll() {
        CloseMessage();
        CloseNotice();
    }

    /// <summary>
    /// Pops up a message window with the given title and message
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    public void ShowMessage(string title, string message) {
        CloseAll();
        messageWindowTitle.text = title;
        messageWindowMessage.text = indentation + message;
        messageWindow.SetActive(true);
        Cursor.visible = true;
    }

    /// <summary>
    /// Closes the message window
    /// </summary>
    public void CloseMessage() {
        messageWindow.SetActive(false);
        Cursor.visible = false;
    }

    /// <summary>
    /// Pops up a notice window with the given message
    /// </summary>
    /// <param name="message"></param>
    public void ShowNotice(string message) {
        CloseAll();
        noticeWindowMessage.text = indentation + message;
        noticeWindow.SetActive(true);
        Cursor.visible = true;
    }

    /// <summary>
    /// Closes the notice window
    /// </summary>
    public void CloseNotice() {
        noticeWindow.SetActive(false);
        Cursor.visible = false;
    }
}
