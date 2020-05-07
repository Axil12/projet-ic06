using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderScore : MonoBehaviour
{
    // PROPRIETES
    public GameManagerScript gameManager;
    public Slider sliderScript;
    public Image sliderColor1;
    public Image sliderColor2;

    // METHODES
    void Awake()
    {
        // REFERENCEMENT
        if(sliderScript == null)
        {
            sliderScript = this.GetComponent<Slider>();
        }
        if (sliderColor1 == null)
        {
            sliderColor1 = this.transform.Find("Background").GetComponent<Image>();
        }
        if (sliderColor2 == null)
        {
            sliderColor2 = this.transform.Find("Fill Area").Find("Fill").GetComponent<Image>();
        }
        if (gameManager == null)
        {
            gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>();
        }

        // EVENT
        gameManager.MAJScore.AddListener(MAJScore);
    }

    public void MAJScore()
    {
        // RECUPERATION SCORE COULEUR
        List<Color> ListeCouleurs = new List<Color>();
        foreach (Color c in gameManager.tilesColors.Keys)
        {
            if(c != Color.white)
            {
                ListeCouleurs.Add(c);
            }
        }
        int Color1Score = gameManager.tilesColors[ListeCouleurs[0]];
        int Color2Score = gameManager.tilesColors[ListeCouleurs[1]];

        // MAJ SLIDER
        sliderColor1.color = ListeCouleurs[1];
        sliderColor2.color = ListeCouleurs[0];
        sliderScript.maxValue = Color1Score + Color2Score;
        sliderScript.value = Color1Score;

        if(Color1Score == 0)
        {
            sliderColor2.color = ListeCouleurs[1];
        }

    }

}
