using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    // SINGLETON : Evite de transformer toutes les autres variables en variables statiques, vu que l'on renseignera cette Toolbox à la place
    public static MenuScript instance = null;

    // SONS
    public enum Sons
    {
        PressStart = 0
    }

    // REFERENCES OBJETS
    public GameObject logo = null;
    public GameObject mainMenu = null;
    public GameObject optionsMenu = null;
    public Image cacheLuminosite = null;

    // REFERENCES COMPONENTS
    public AudioSource menuAudioSource = null;
    public PressStartScript scriptPressStart = null;

    // PROPRIETES PUBLIQUES

    // PROPRIETES PRIVATE
    bool isStarted = false;

    // METHODES
    private void Awake()
    {
        // INSTANCIATION SINGLETON
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        // REFERENCES MANQUANTES
        if (logo == null)
        {
            logo = this.transform.Find("TitleLogo").gameObject;
        }

        if (menuAudioSource == null)
        {
            menuAudioSource = this.GetComponent<AudioSource>();
        }

        if (mainMenu == null)
        {
            mainMenu = this.transform.Find("MainMenu").gameObject;
        }

        if (optionsMenu == null)
        {
            optionsMenu = this.transform.Find("OptionsMenu").gameObject;
        }

        if (scriptPressStart == null)
        {
            scriptPressStart = this.transform.Find("PressStart").GetComponent<PressStartScript>();
        }

        if(cacheLuminosite == null)
        {
            cacheLuminosite = this.transform.Find("CacheLuminosite").GetComponent<Image>();
        }

        // ECRAN DE DEPART
        InitAffichage();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit")){
            // DETECTION START (Ecran Titre)
            if (isStarted == false)
            {
                isStarted = true;
                scriptPressStart.Accelerer();
            }
        }
    }

    // METHODES BOUTONS

    public void PlayGame()
    {
        SceneManager.LoadScene("InGame");
    }

    public void EnterOptions()
    {
        // MAJ AFFICHAGE
        logo.SetActive(false);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        optionsMenu.transform.Find("VolumeSlider").GetComponent<Slider>().Select();
    }

    public void LeaveOptions()
    {
        // MAJ AFFICHAGE
        logo.SetActive(true);
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        mainMenu.transform.Find("PlayButton").GetComponent<Button>().Select();
    }

    public void ExitGame()
    {
        Debug.Log("Exiting the game...");
        if (Application.isEditor)
        {
            EditorApplication.ExecuteMenuItem("Edit/Play");
        }
        else
        {
            Application.Quit();
        }
    }

    // METHODES GENERALES

    private void InitAffichage()
    {
        logo.SetActive(true);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        scriptPressStart.gameObject.SetActive(true);
        AudioListener.volume = 0.5f;
    }

    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void JouerSon(Sons SonAJouer)
    {
        string chemin = "Sounds/" + SonAJouer.ToString();
        menuAudioSource.clip = Resources.Load(chemin, typeof(AudioClip)) as AudioClip;
        menuAudioSource.Play();
    }
}
