using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class winnerText : MonoBehaviour
{
    //Displays who won the game

    public TextMeshProUGUI winnerDisplay;

    // Start is called before the first frame update
    void Start()
    {
        if(winnerDisplay == null)
        {
            winnerDisplay = GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool gameHasEnded = GameManagerScript.instance.GetComponent<GameManagerScript>().getGameHasEnded();
        if (gameHasEnded) {
            winnerDisplay.text = GameManagerScript.instance.GetComponent<GameManagerScript>().getWinner();
		}
    }
}
