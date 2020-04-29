using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    //public float delayBeforeRestart = 1.0f;
    //public GameObject gameOverPanel;

    bool gameHasEnded = false;
    public float gameLength = 10.0f; //In seconds

    
    Dictionary<Color, string> players = new Dictionary<Color, string>();
    Dictionary<GameObject, Vector2> spawnPoints = new Dictionary<GameObject, Vector2>();
    Dictionary<Color, int> tilesColors = new Dictionary<Color, int>();

    void Awake() {
	}

    // Start is called before the first frame update
    void Start()
    {
        Invoke("endGame", gameLength);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addPlayerToDict(Color c, string playerName)
    {
        if (!players.ContainsKey(c))
            players.Add(c, playerName);
	}

    public void addSpawnPointToDict(GameObject go, Vector2 location)
    {
     if (!spawnPoints.ContainsKey(go))
        spawnPoints.Add(go, location);
	}

    public void killPlayer(GameObject player)
    {
        player.SetActive(false);
        player.transform.position = spawnPoints[player];
        player.SetActive(true);
	}

    public void addColorToDict(Color c)
    {
        if (!tilesColors.ContainsKey(c))
            tilesColors.Add(c, 0);
	}
    public void substractOneFromColor(Color c){tilesColors[c] -= 1;}
    public void addOneFromColor(Color c){tilesColors[c] += 1;}
    
    public bool getGameHasEnded(){return gameHasEnded;}

    public string getWinner() {
        int highestScore = 0;
        string winner = "No winner";
        foreach(KeyValuePair<Color, int> entry in tilesColors)
        {
            if (entry.Value > highestScore)
            {
                highestScore = entry.Value;
                winner = players[entry.Key];
            }
            else if (entry.Value == highestScore) //If mutiple players have the same number of tiles colored
            {
                winner = winner + " and " + players[entry.Key];
			}
        }
        return winner;
	}

    public void endGame() {
        gameHasEnded = true;
        Debug.Log("Winner : " + getWinner());
	}
}
