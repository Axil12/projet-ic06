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

    // REFERENCES OBJETS
    public GameObject logo = null;
    public GameObject mainMenu = null;
    public GameObject optionsMenu = null;
    public GameObject charactersMenu = null;
    public GameObject parametersMenu = null;
    public Image cacheLuminosite = null;

    // REFERENCES COMPONENTS
    public AudioSource musicAudio = null;
    public AudioSource sfxAudio = null;
    public PressStartScript scriptPressStart = null;
    public ParametersMenuScript parametersMenuScript = null;

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

        if (mainMenu == null)
        {
            mainMenu = this.transform.Find("MainMenu").gameObject;
        }

        if (parametersMenu == null)
        {
            parametersMenu = this.transform.Find("ParametersMenu").gameObject;
        }

        if (charactersMenu == null)
        {
            //charactersMenu = this.transform.Find("CharactersMenu").gameObject;
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

        if (parametersMenu != null && parametersMenuScript == null)
        {
            parametersMenuScript = parametersMenu.transform.Find("Parameters").GetComponent<ParametersMenuScript>();
        }
    }

    private void Start()
    {
        // ECRAN DE DEPART
        InitAffichage();
    }

    private void Update()
    {
        // VALIDATION MENU
        if (Input.GetButtonDown("Submit")){
            // DETECTION START (Ecran Titre)
            if (isStarted == false)
            {
                isStarted = true;
                scriptPressStart.Accelerer();
            }
        }

        // NAVIGATION MENU
        if (scriptPressStart.gameObject.activeInHierarchy == false && Input.GetButtonDown("Vertical"))
        {
            // JOUE SON
            JouerSon(Sons.Menu.Move);
        }

        if (!parametersMenuScript.onStart && parametersMenu.activeInHierarchy == true && Input.GetButtonDown("Horizontal"))
        {
            // JOUE SON
            JouerSon(Sons.Menu.Move);
        }
    }

    // METHODES BOUTONS

    public void LaunchGame()
    {
        SceneManager.LoadScene("InGame");
    }

    public void ButtonPlay()
    {
        // JOUE SON
        JouerSon(Sons.Menu.Select);

        // MAJ AFFICHAGE
        logo.SetActive(false);
        mainMenu.SetActive(false);
        parametersMenu.SetActive(true);
        parametersMenuScript.ArenaButton.Select();
    }

    public void EnterOptions()
    {
        // JOUE SON
        JouerSon(Sons.Menu.Select);

        // MAJ AFFICHAGE
        logo.SetActive(false);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        optionsMenu.transform.Find("VolumeSlider").GetComponent<Slider>().Select();
    }

    public void LeaveOptions()
    {
        // JOUE SON
        JouerSon(Sons.Menu.Select);

        // MAJ AFFICHAGE
        logo.SetActive(true);
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        mainMenu.transform.Find("PlayButton").GetComponent<Button>().Select();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    // METHODES GENERALES

    private void InitAffichage()
    {
        logo.SetActive(true);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        parametersMenu.SetActive(false);
        scriptPressStart.gameObject.SetActive(true);
        musicAudio.volume = 0.5f;
        sfxAudio.volume = 0.5f;
        JouerMusic(Sons.Musics.Title);
    }

    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void JouerSon(Sons.Menu SonAJouer)
    {
        string chemin = "Sounds/Menu/" + SonAJouer.ToString();
        sfxAudio.clip = Resources.Load(chemin, typeof(AudioClip)) as AudioClip;
        sfxAudio.Play();
    }

    public void JouerVoix(Sons.Voice VoixAJouer)
    {
        string chemin = "Sounds/Voice/" + VoixAJouer.ToString();
        sfxAudio.clip = Resources.Load(chemin, typeof(AudioClip)) as AudioClip;
        sfxAudio.Play();
    }

    public void JouerMusic(Sons.Musics MusicAJouer)
    {
        string chemin = "Musics/" + MusicAJouer.ToString();
        musicAudio.clip = Resources.Load(chemin, typeof(AudioClip)) as AudioClip;
        musicAudio.Play();
    }
}
