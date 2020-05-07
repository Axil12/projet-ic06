using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hurryUpScript : MonoBehaviour
{
    // REFERENCES
    public Image rouge;

    // PROPRIETES PUBLIQUES
    [Range(0.5f, 5f)]
    public float vitesse = 1f;
    [Range(0f, 1f)]
    public float alphaMaximum = 0.3f;
    [Range(0.5f, 5f)]
    public float tempsAnimation = 3f;

    // PROPRIETES PRIVATE
    private bool animation_ok = false;
    private float delta = 0f;
    private bool apparition = false;
    private bool disparition = false;

    // METHODES

    private void Start()
    {
        // REFERENCES
        if(rouge == null)
        {
            rouge = GetComponent<Image>();
        }

        // EVENT
        GameManagerScript.instance.HurryUpEvent.AddListener(hurryUp);
    }

    private void Update()
    {
        if (apparition)
        {
            // 1 - INCREMENTATION DELTA
            delta += Time.deltaTime * vitesse;

            // 2 - INCREMENTATION ALPHA
            Color tempColor = rouge.color;
            tempColor.a = delta;
            rouge.color = tempColor;

            // 3 - TEST CONDITION ARRET
            if (delta >= alphaMaximum)
            {
                // On passe à l'autre animation
                delta = alphaMaximum;
                apparition = false;
                disparition = true;
            }
        }

        // DISPARITION
        if (disparition)
        {
            // 1 - DECREMENTATION DELTA
            delta -= Time.deltaTime * vitesse;

            // 2 - DECREMENTATION ALPHA
            Color tempColor = rouge.color;
            tempColor.a = delta;
            rouge.color = tempColor;

            // 3 - TEST CONDITION ARRET
            if (delta <= 0)
            {
                // On passe à l'autre animation
                delta = 0;
                disparition = false;
                if (animation_ok)
                {
                    apparition = true;
                }
            }
        }
    }

    public void hurryUp()
    {
        // VISUEL
        apparition = true;
        animation_ok = true;

        // AUDIO
        GameManagerScript.instance.musicAudio.Stop();
        GameManagerScript.instance.JouerSonJeu(Sons.InGame.HurryUp);
        GameManagerScript.instance.pausePossible = false;

        Invoke("stopAnimation", tempsAnimation);
    }

    public void stopAnimation()
    {
        animation_ok = false;
        GameManagerScript.instance.pausePossible = true;
        GameManagerScript.instance.musicAudio.pitch *= 1.1f;
        GameManagerScript.instance.musicAudio.Play();
    }
}
