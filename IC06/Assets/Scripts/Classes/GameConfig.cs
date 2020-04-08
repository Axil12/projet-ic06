using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Paramètres d'une partie avant son lancement, utilisée par le GameManager pour instancier la partie

public class GameConfig
{

    // ENUM

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

    // PROPRIETES

    // A terme : Il faudra créer une classe personnage : Nom, PositionPays, Couleurs possibles, couleur choisie
    private Character player1Character;

    public Character Player1Character
    {
        get { return player1Character; }
        set { player1Character = value; }
    }

    private Character player2Character;

    public Character Player2Character
    {
        get { return player2Character; }
        set { player2Character = value; }
    }

    private Arena selectedArena;

    public Arena SelectedArena
    {
        get { return selectedArena; }
        set { selectedArena = value; }
    }

    private TimeMode time = TimeMode.minute3;

    public TimeMode Time
    {
        get { return time; }
        set { time = value; }
    }

    private PowerUpsMode powerUpsFrequency = PowerUpsMode.Normal;

    public PowerUpsMode PowerUpsFrequency
    {
        get { return powerUpsFrequency; }
        set { powerUpsFrequency = value; }
    }

    private RespawnTimeMode respawnTime = RespawnTimeMode.sec2;

    public RespawnTimeMode RespawnTime
    {
        get { return respawnTime; }
        set { respawnTime = value; }
    }

    private PlayersPVMode pvMode = PlayersPVMode.percent100;

    public PlayersPVMode PVMode
    {
        get { return pvMode; }
        set { pvMode = value; }
    }

    private bool isMutatorEnabled = false;

    public bool IsMutatorEnabled
    {
        get { return isMutatorEnabled; }
        set { isMutatorEnabled = value; }
    }

}
