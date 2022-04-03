// Base code source: Katarina Tretter

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameSystems;

public class GameOverlayManager : MonoBehaviour
{
    [SerializeField] private Text deathCounter;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        deathCounter.text = GameManager.Instance.DeathCount.ToString();
    }
}
