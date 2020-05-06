using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    // ENUM
    public enum Sons
    {
        PressStart = 0,
    }

    public enum Musics
    {
        Action1 = 0,
        Action2,
        Action3,
    }

    // EVENTS
    public UnityEvent MAJScore;

    // REFERENCES
    public AudioSource musicAudio = null;
    public AudioSource sfxAudio = null;
    public TextMeshProUGUI timer = null;

    // PROPRIETES
    //public float delayBeforeRestart = 1.0f;
    //public GameObject gameOverPanel;

    private bool gameHasEnded = false;
    public float gameLength = 10.0f; //In seconds

    [HideInInspector]
    public Dictionary<Color, string> players = new Dictionary<Color, string>();                     // 
    [HideInInspector]
    public Dictionary<GameObject, Vector2> spawnPoints = new Dictionary<GameObject, Vector2>();     //
    [HideInInspector]
    public Dictionary<Color, int> tilesColors = new Dictionary<Color, int>();                       // Couleur / Score

    void Awake()
    {
        // On paramètre la partie avec les GameParameters du menu
        SetupInitial();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // TIMER : On décrémente le temps au fur et à mesure
        gameLength -= Time.deltaTime;
        TimeSpan ts = TimeSpan.FromSeconds(gameLength + 1f);
        timer.text = ts.ToString("mm\\:ss");
        if (gameLength <= -1)
        {
            endGame();
        }
    }

    // METHODES AXIL

    public void addPlayerToDict(Color c, string playerName)
    {
        if (!players.ContainsKey(c))
            players.Add(c, playerName);
	}

    public void addSpawnPointToDict(GameObject go, Vector2 location) //Might be useless now (since the spawn system is now included in the PlayerCharacteristics. I might delete it later
    {
        if (!spawnPoints.ContainsKey(go))
            spawnPoints.Add(go, location);
	}

    public void setMaxHealthPointsForPlayers(int hp) {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in players)
        {
            player.GetComponent<PlayerCharacteristics>().setMaxHealthPoints(hp);
		}
	}

    public void setRespawnTimeForPlayers(float t) {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in players)
        {
            player.GetComponent<PlayerCharacteristics>().setRespawnTime(t);
		}
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
    public void substractOneFromColor(Color c)
    {
        tilesColors[c] -= 1;
        MAJScore.Invoke();
    }
    public void addOneFromColor(Color c)
    {
        tilesColors[c] += 1;
        MAJScore.Invoke();
    }
    
    public bool getGameHasEnded(){return gameHasEnded;}

    public string getWinner() {
        int highestScore = -1;
        string winner = "No winner";

        foreach(KeyValuePair<Color, int> entry in tilesColors)
        {
            if (players.ContainsKey(entry.Key))
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
        }
        return winner;
	}

    public void endGame() 
    {
        gameHasEnded = true;
        Debug.Log("Winner : " + getWinner());
        SceneManager.LoadScene("Menu");// Go back to the menu after the game has ended. We need to add a "victory" screen/pop up.
	}

    // METHODES ROBIN

    public void SetupInitial()
    {
        // PARAMETRAGE VOLUME
        sfxAudio.volume = GameParameters.SfxVolume;
        musicAudio.volume = GameParameters.MusicVolume;

        // PARAMETRAGE JOUEURS
        //GameParameters.Player1Character;
        //GameParameters.Player2Character;

        // PARAMETRAGE ARENE
        //GameParameters.SelectedArena;

        // PARAMETRAGE PARTIE (Temps Respawn, Temps partie, Taux apparition powersUps, PVs)
        setRespawnTimeForPlayers(GameParameters.getRespawnTimeInSeconds());
        gameLength = GameParameters.getTimeModeInSeconds();
        //GameParameters.PowerUpsFrequency;
        setMaxHealthPointsForPlayers(GameParameters.getMaxHealthPointsSetting());

        // MUSIQUE ALEATOIRE
        System.Random rnd = new System.Random();
        int nbMusic = rnd.Next(1, 4);
        if (nbMusic == 1)
        {
            JouerMusic(Musics.Action1);
        }
        if (nbMusic == 2)
        {
            JouerMusic(Musics.Action2);
        }
        if (nbMusic == 3)
        {
            JouerMusic(Musics.Action3);
        }

        Debug.Log("Paramètres partie (1) : " + "Volume Musique : " + GameParameters.MusicVolume + " / Volume Son : " + GameParameters.SfxVolume);
        //Debug.Log("Paramètres partie (2) : " + "Player1 : " + GameParameters.Player1Character + " / Player2 : " + GameParameters.Player2Character);
        //Debug.Log("Paramètres partie (3) : " + "Arène : " + GameParameters.SelectedArena);
        Debug.Log("Paramètres partie (4) : " + "Temps : " + GameParameters.Time + " / PowerUps : " + GameParameters.PowerUpsFrequency + " / Respawn : " + GameParameters.RespawnTime  + " / PV : " + GameParameters.PVMode);
    }

    public void JouerSon(Sons SonAJouer)
    {
        string chemin = "Sounds/" + SonAJouer.ToString();
        sfxAudio.clip = Resources.Load(chemin, typeof(AudioClip)) as AudioClip;
        sfxAudio.Play();
    }

    public void JouerMusic(Musics MusicAJouer)
    {
        string chemin = "Musics/" + MusicAJouer.ToString();
        musicAudio.clip = Resources.Load(chemin, typeof(AudioClip)) as AudioClip;
        musicAudio.Play();
    }
}
