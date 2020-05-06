using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winnerText : MonoBehaviour
{
    //Displays who won the game

    private GameObject gameManager;
    public Text winnerDisplay;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        bool gameHasEnded = gameManager.GetComponent<GameManagerScript>().getGameHasEnded();
        if (gameHasEnded) {
            winnerDisplay.text = gameManager.GetComponent<GameManagerScript>().getWinner();
		}
    }
}
