using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PressStartScript : MonoBehaviour
{
    // PROPRIETES PUBLIQUES
    [Range(0.5f, 3f)]
    public float vitesseClignotement = 1.5f;
    [Range(0.5f, 3f)]
    public float tempsAvantAffichageMenu = 1;

    // PROPRIETES PRIVATE
    private TextMeshProUGUI texte;
    private bool visible = true;
    private bool startPressed = false;
    private float delta = 0;
    private float delta2 = 0;


    // METHODES
    void Awake()
    {
        texte = GetComponent<TextMeshProUGUI>();
        visible = true;
    }

    void Update()
    {
        // ACTION 1 : Start n'a pas encore été pressé
        // On fait clignoter le PressStart
        if (visible)
        {
            delta += Time.deltaTime * vitesseClignotement;
            if (delta > 1)
            {
                delta = 0;
                visible = false;
                texte.enabled = false;
            }
        }
        else
        {
            delta += Time.deltaTime * vitesseClignotement;
            if (delta > 1)
            {
                delta = 0;
                visible = true;
                texte.enabled = true;
            }
        }

        // ACTION 2 : Start a été pressé
        // On fait disparaître le PressStart après un temps et on affiche le menu
        if (startPressed)
        {
            delta2 += Time.deltaTime;
            if (delta2 > tempsAvantAffichageMenu)
            {
                delta2 = 0;
                AffichageMenu();
            }
        }
    }

    private void AffichageMenu()
    {
        this.gameObject.SetActive(false);
        MenuScript.instance.mainMenu.SetActive(true);
        MenuScript.instance.mainMenu.transform.Find("PlayButton").GetComponent<Button>().Select();
    }

    public void Accelerer()
    {
        vitesseClignotement *= 6;
        delta = 0;
        MenuScript.instance.JouerSon(Sons.Menu.PressStart);
        startPressed = true;
    }
}
