using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe regroupant les paramètres généraux du jeu (Menu Options)
// On stocke une instance de cette classe sous forme de config.xml, puis on la charge au lancement du jeu
// Si aucune config trouvée, on instancie la classe avec les valeurs par défaut

public class Parameters
{
    public enum displayMode
    {
        Windowed = 0,
        Fullscreen
    }

    private int luminosite = 100;

    public int Luminoste
    {
        get { return luminosite; }
        set { luminosite = value; }
    }

    private int musicVolume = 100;

    public int MusicVolume
    {
        get { return musicVolume; }
        set { musicVolume = value; }
    }

    private int sfxVolume = 100;

    public int SFXVolume
    {
        get { return sfxVolume; }
        set { sfxVolume = value; }
    }

    private displayMode display = displayMode.Windowed;

    public displayMode Display
    {
        get { return display; }
        set { display = value; }
    }

    // Controller à configurer


}
