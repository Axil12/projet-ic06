using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Information concernant un personnage

public class Character
{

    private string nom;

    public string Nom
    {
        get { return nom; }
        set { nom = value; }
    }

    private List<Color> couleursPossibles;

    public List<Color> CouleursPossibles
    {
        get { return couleursPossibles; }
        set { couleursPossibles = value; }
    }

    private Color couleurChoisie;

    public Color CouleurChoisie
    {
        get { return couleurChoisie; }
        set { couleurChoisie = value; }
    }
}
