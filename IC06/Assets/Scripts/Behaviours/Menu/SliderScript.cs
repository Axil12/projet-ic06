using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.UI.Slider;

public class SliderScript : MonoBehaviour
{
    // ENUM
    public enum TypeSlider
    {
        volume = 0,
        sfx,
        luminosite
    }

    // PROPRIETES
    public TypeSlider typeSlider;

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
        switch (typeSlider)
        {
            case TypeSlider.volume:
                sliderScript.onValueChanged.AddListener(MAJVolume);
                break;
            case TypeSlider.sfx:
                sliderScript.onValueChanged.AddListener(MAJSFX);
                break;
            case TypeSlider.luminosite:
                sliderScript.onValueChanged.AddListener(MAJLuminosite);
                break;
            default:
                break;
        }
    }

    public void MAJVolume(float sliderValue)
    {
        valeur.text = (sliderValue * 100).ToString("N0") + "%";
        MenuScript.instance.musicAudio.volume = sliderValue;
        GameParameters.MusicVolume = sliderValue;
    }

    public void MAJSFX(float sliderValue)
    {
        valeur.text = (sliderValue * 100).ToString("N0") + "%";
        MenuScript.instance.sfxAudio.volume = sliderValue;
        MenuScript.instance.JouerSon(Sons.Menu.Move);
        GameParameters.SfxVolume = sliderValue;
    }

    public void MAJLuminosite(float sliderValue)
    {
        valeur.text = (sliderValue * 100).ToString("N0") + "%";
        Color tempColor = MenuScript.instance.cacheLuminosite.color;
        if(sliderValue >= 0.1f)
        {
            tempColor.a = Math.Abs(1 - sliderValue);
        }
        else
        {
            valeur.text = "5%";
            tempColor.a = 0.95f;
        }
        MenuScript.instance.cacheLuminosite.color = tempColor;
        GameParameters.Luminosite = sliderValue;
    }
}
