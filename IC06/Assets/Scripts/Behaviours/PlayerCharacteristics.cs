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
    public float respawnTime = 3.0f;

    Vector3 playerStartingPosition;

    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        gameManager.GetComponent<GameManagerScript>().addColorToDict(playerColor);
        gameManager.GetComponent<GameManagerScript>().addPlayerToDict(playerColor, playerName);
        gameManager.GetComponent<GameManagerScript>().addSpawnPointToDict(this.gameObject, this.gameObject.transform.position);

        playerStartingPosition = this.gameObject.transform.position;

        healthPoints = maxHealthPoints;

        Debug.Log(playerName + " : " 
            + " maxHP : " + maxHealthPoints + " HP"
            + " Respawn time : " + respawnTime + "s"
            );
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0)
        {
              //gameManager.GetComponent<GameManagerScript>().killPlayer(this.gameObject);
              Die();
              healthPoints = maxHealthPoints;
		}
    }

    public void Respawn() {
        this.gameObject.transform.position = playerStartingPosition;
	}

    public void Die(){
           this.gameObject.transform.position = playerStartingPosition + new Vector3(1, 1, 1)*100000;
           Invoke("Respawn", respawnTime);
	}

    public string getName(){return playerName;}
    public Color getPlayerColor(){return playerColor;}

    public void takeDamage(int damage){healthPoints -= 1;}
    public void addHP(int damage){healthPoints -= 1;}
    public void die(){isAlive = false;}

    public void setRespawnTime(float t){respawnTime = t;}
    public void setMaxHealthPoints(int hp){maxHealthPoints = hp;}
}
