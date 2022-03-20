// Base code source: Katarina Tretter

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverlayManager : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;

    private GameManager gM;

    // Start is called before the first frame update
    void Start()
    {
        gM = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
