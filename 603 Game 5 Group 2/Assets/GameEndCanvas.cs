using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEndCanvas : MonoBehaviour
{
    [SerializeField]
    GameObject endGameUIPanel,deathcountValue;


    void Start()
    {
        ChallengesHolder.Instance.endgameUI = endGameUIPanel;
        ChallengesHolder.Instance.deathCountVal = deathcountValue.GetComponent<TextMeshProUGUI>();
    }
}
