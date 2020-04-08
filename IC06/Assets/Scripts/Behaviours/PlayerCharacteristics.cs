using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{
    public Color playerColor = new Color(1,1,0,1);
    public string playerName = "CountryName";
    public int maxHealthPoints = 3;
    public int healthPoints;
    public bool isAlive = true;

    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        gameManager.GetComponent<GameManagerScript>().addColorToDict(playerColor);
        gameManager.GetComponent<GameManagerScript>().addPlayerToDict(playerColor, playerName);
        gameManager.GetComponent<GameManagerScript>().addSpawnPointToDict(this.gameObject, this.gameObject.transform.position);

        healthPoints = maxHealthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0)
        {
              gameManager.GetComponent<GameManagerScript>().killPlayer(this.gameObject);
              healthPoints = maxHealthPoints;
		}
    }

    public string getName(){return playerName;}
    public Color getPlayerColor(){return playerColor;}

    public void takeDamage(int damage){healthPoints -= 1;}
    public void addHP(int damage){healthPoints -= 1;}
    public void die(){isAlive = false;}
}
