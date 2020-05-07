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
        minute2,
        minute3
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
        sec1,
        sec2,
        sec3
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

    private static TimeMode time = TimeMode.minute2;

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
        case TimeMode.minute2:
            return 120.0f;
        case TimeMode.minute3:
            return 180.0f;
        default:
            return 120.0f;
		}
	}

    private static PowerUpsMode powerUpsFrequency = PowerUpsMode.Normal;

    public static PowerUpsMode PowerUpsFrequency
    {
        get { return powerUpsFrequency; }
        set { powerUpsFrequency = value; }
    }

    private static RespawnTimeMode respawnTime = RespawnTimeMode.sec2;

    public static RespawnTimeMode RespawnTime
    {
        get { return respawnTime; }
        set { respawnTime = value; }
    }

    public static float getRespawnTimeInSeconds() {
        switch(respawnTime)
        {
        case RespawnTimeMode.sec1:
            return 1.0f;
        case RespawnTimeMode.sec2:
            return 2.0f;
        case RespawnTimeMode.sec3:
            return 3.0f;
        default:
            return 2.0f;
		}
	}

    private static PlayersPVMode pvMode = PlayersPVMode.percent100;

    public static PlayersPVMode PVMode
    {
        get { return pvMode; }
        set { pvMode = value; }
    }

    public static int getMaxHealthPointsSetting() {
        switch(pvMode)
        {
        case PlayersPVMode.percent100:
            return 3;
        case PlayersPVMode.percent50:
            return 2;
        case PlayersPVMode.percent200:
            return 6;
        default:
            return 3;
		}
	}
}
