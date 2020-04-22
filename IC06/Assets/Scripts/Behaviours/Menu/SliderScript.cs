using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.UI.Slider;

public class SliderScript : MonoBehaviour
{
    // REFERENCES
    public TextMeshProUGUI valeur;
    private Slider sliderScript;

    void Start()
    {
        // RECUP ELEMENT MANQUANT
        if(valeur == null)
        {
            valeur = transform.Find("Value").GetComponent<TextMeshProUGUI>();
        }

        if (sliderScript == null)
        {
            sliderScript = this.GetComponent<Slider>();
        }

        // AJOUT EVENT
        sliderScript.onValueChanged.AddListener(MiseAJour);
    }

    public void MiseAJour(float sliderValue)
    {
        valeur.text = (sliderValue * 100).ToString("N0") + "%";
        AudioListener.volume = sliderValue;
    }
}
