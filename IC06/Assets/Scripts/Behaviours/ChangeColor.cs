using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    Color tileColor = new Color(1, 1, 1, 1);
    SpriteRenderer rend;
    GameObject gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.color = tileColor;
        gameManager = GameObject.FindWithTag("GameManager");
        gameManager.GetComponent<GameManagerScript>().addColorToDict(tileColor);
    }

    // Update is called once per frame
    void Update()
    {
        rend.color = tileColor;
    }

    public void setColor(Color c) 
    {
        if (!gameManager.GetComponent<GameManagerScript>().getGameHasEnded()) {
            gameManager.GetComponent<GameManagerScript>().substractOneFromColor(tileColor);
            gameManager.GetComponent<GameManagerScript>().addOneFromColor(c);
            tileColor = c;
        }
	}

    public Color getColor() {return tileColor;}
}
