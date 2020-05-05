using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Paramètres d'une partie avant son lancement, utilisée par le GameManager pour instancier la partie

public static class GameParameters
{

    // ENUM
    public enum TypeArena
    {
        Bomby = 0,
        Bowtie,
        Deos,
        Destiny,
        Hash,
        OddBone,
        Shapes,
        Snake,
        Sonar,
        Space,
        Zalam
    }

    public enum TimeMode
    {
        minute1,
        minute3,
        minute5
    }

    public enum PowerUpsMode
    {
        Aucun,
        Peu,
        Normal,
        Beaucoup
    }

    public enum RespawnTimeMode
    {
        sec2,
        sec4,
        sec6
    }

    public enum PlayersPVMode
    {
        percent50,
        percent100,
        percent200
    }

    // PROPRIETES GENERALES
    private static float musicVolume = 0.5f;

    public static float MusicVolume
    {
        get { return musicVolume; }
        set { musicVolume = value; }
    }

    private static float sfxVolume = 0.5f;

    public static float SfxVolume
    {
        get { return sfxVolume; }
        set { sfxVolume = value; }
    }

    private static float luminosite = 1f;

    public static float Luminosite
    {
        get { return luminosite; }
        set { luminosite = value; }
    }


    // PROPRIETES DE PARTIE

    // A terme : Il faudra créer une classe personnage : Nom, PositionPays, Couleurs possibles, couleur choisie
    private static Character player1Character;

    public static Character Player1Character
    {
        get { return player1Character; }
        set { player1Character = value; }
    }

    private static Character player2Character;

    public static Character Player2Character
    {
        get { return player2Character; }
        set { player2Character = value; }
    }

    private static TypeArena selectedArena = TypeArena.Bomby;

    public static TypeArena SelectedArena
    {
        get { return selectedArena; }
        set { selectedArena = value; }
    }

    private static TimeMode time = TimeMode.minute3;

    public static TimeMode Time
    {
        get { return time; }
        set { time = value; }
    }

    public static float getTimeModeInSeconds() {
        switch(time)
        {
        case TimeMode.minute1:
            return 60.0f;
        case TimeMode.minute3:
            return 180.0f;
        case TimeMode.minute5:
            return 300.0f;
        default:
            return 180.0f;
		}

	}

    private static PowerUpsMode powerUpsFrequency = PowerUpsMode.Normal;

    public static PowerUpsMode PowerUpsFrequency
    {
        get { return powerUpsFrequency; }
        set { powerUpsFrequency = value; }
    }

    private static RespawnTimeMode respawnTime = RespawnTimeMode.sec4;

    public static RespawnTimeMode RespawnTime
    {
        get { return respawnTime; }
        set { respawnTime = value; }
    }

    private static PlayersPVMode pvMode = PlayersPVMode.percent100;

    public static PlayersPVMode PVMode
    {
        get { return pvMode; }
        set { pvMode = value; }
    }
}
