using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ParametersMenuScript : MonoBehaviour
{
    // REFERENCES
    public Button ArenaButton;
    public Button TimeButton;
    public Button PowerButton;
    public Button RespawnButton;
    public Button PVButton;
    public Button StartButton;

    public TextMeshProUGUI ArenaName;
    public Image ArenaImage;

    public Transform Time1Button;
    public Transform Time2Button;
    public Transform Time3Button;

    public Transform PowerLowButton;
    public Transform PowerMedButton;
    public Transform PowerHighButton;

    public Transform Respawn1Button;
    public Transform Respawn2Button;
    public Transform Respawn3Button;

    public Transform PV1Button;
    public Transform PV2Button;
    public Transform PV3Button;

    public Transform TimeSelect;
    public Transform PowerSelect;
    public Transform RespawnSelect;
    public Transform PVSelect;

    public Transform BackgroundSelect;

    // PROPRIETES

    public bool onStart = false;

    private ParametersButton.TypeButton boutonSelectionne;

    public ParametersButton.TypeButton BoutonSelectionne
    {
        get { return boutonSelectionne; }
        set { 
            // MAJ VALEUR
            boutonSelectionne = value;

            // MAJ SELECTION
            onStart = false;
            switch (boutonSelectionne)
            {
                case ParametersButton.TypeButton.Arena:
                    BackgroundSelect.gameObject.SetActive(true);
                    StartCoroutine(ChangerBackgroundSelection());
                    break;
                case ParametersButton.TypeButton.Time:
                    BackgroundSelect.gameObject.SetActive(true);
                    StartCoroutine(ChangerBackgroundSelection());
                    break;
                case ParametersButton.TypeButton.Power:
                    BackgroundSelect.gameObject.SetActive(true);
                    StartCoroutine(ChangerBackgroundSelection());
                    break;
                case ParametersButton.TypeButton.Respawn:
                    BackgroundSelect.gameObject.SetActive(true);
                    StartCoroutine(ChangerBackgroundSelection());
                    break;
                case ParametersButton.TypeButton.PV:
                    BackgroundSelect.gameObject.SetActive(true);
                    StartCoroutine(ChangerBackgroundSelection());
                    break;
                case ParametersButton.TypeButton.Start:
                    BackgroundSelect.gameObject.SetActive(false);
                    onStart = true;
                    break;
                case ParametersButton.TypeButton.ArenaLeft:
                    ArenaButton.Select();
                    AreneGauche();
                    break;
                case ParametersButton.TypeButton.ArenaRight:
                    ArenaButton.Select();
                    AreneDroite();
                    break;
                case ParametersButton.TypeButton.TimeLeft:
                    switch (GameParameters.Time)
                    {
                        case GameParameters.TimeMode.minute1:
                            StartCoroutine(ChangerSelection(TimeSelect, Time3Button));
                            GameParameters.Time = GameParameters.TimeMode.minute3;
                            break;
                        case GameParameters.TimeMode.minute2:
                            StartCoroutine(ChangerSelection(TimeSelect, Time1Button));
                            GameParameters.Time = GameParameters.TimeMode.minute1;
                            break;
                        case GameParameters.TimeMode.minute3:
                            StartCoroutine(ChangerSelection(TimeSelect, Time2Button));
                            GameParameters.Time = GameParameters.TimeMode.minute2;
                            break;
                        default:
                            break;
                    }
                    break;
                case ParametersButton.TypeButton.TimeRight:
                    switch (GameParameters.Time)
                    {
                        case GameParameters.TimeMode.minute1:
                            StartCoroutine(ChangerSelection(TimeSelect, Time2Button));
                            GameParameters.Time = GameParameters.TimeMode.minute2;
                            break;
                        case GameParameters.TimeMode.minute2:
                            StartCoroutine(ChangerSelection(TimeSelect, Time3Button));
                            GameParameters.Time = GameParameters.TimeMode.minute3;
                            break;
                        case GameParameters.TimeMode.minute3:
                            StartCoroutine(ChangerSelection(TimeSelect, Time1Button));
                            GameParameters.Time = GameParameters.TimeMode.minute1;
                            break;
                        default:
                            break;
                    }
                    break;
                case ParametersButton.TypeButton.PowerLeft:
                    switch (GameParameters.PowerUpsFrequency)
                    {
                        case GameParameters.PowerUpsMode.Aucun:
                            break;
                        case GameParameters.PowerUpsMode.Peu:
                            StartCoroutine(ChangerSelection(PowerSelect, PowerHighButton));
                            GameParameters.PowerUpsFrequency = GameParameters.PowerUpsMode.Beaucoup;
                            break;
                        case GameParameters.PowerUpsMode.Normal:
                            StartCoroutine(ChangerSelection(PowerSelect, PowerLowButton));
                            GameParameters.PowerUpsFrequency = GameParameters.PowerUpsMode.Peu;
                            break;
                        case GameParameters.PowerUpsMode.Beaucoup:
                            StartCoroutine(ChangerSelection(PowerSelect, PowerMedButton));
                            GameParameters.PowerUpsFrequency = GameParameters.PowerUpsMode.Normal;
                            break;
                        default:
                            break;
                    }
                    break;
                case ParametersButton.TypeButton.PowerRight:
                    switch (GameParameters.PowerUpsFrequency)
                    {
                        case GameParameters.PowerUpsMode.Aucun:
                            break;
                        case GameParameters.PowerUpsMode.Peu:
                            StartCoroutine(ChangerSelection(PowerSelect, PowerMedButton));
                            GameParameters.PowerUpsFrequency = GameParameters.PowerUpsMode.Normal;
                            break;
                        case GameParameters.PowerUpsMode.Normal:
                            StartCoroutine(ChangerSelection(PowerSelect, PowerHighButton));
                            GameParameters.PowerUpsFrequency = GameParameters.PowerUpsMode.Beaucoup;
                            break;
                        case GameParameters.PowerUpsMode.Beaucoup:
                            StartCoroutine(ChangerSelection(PowerSelect, PowerLowButton));
                            GameParameters.PowerUpsFrequency = GameParameters.PowerUpsMode.Peu;
                            break;
                        default:
                            break;
                    }
                    break;
                case ParametersButton.TypeButton.RespawnLeft:
                    switch (GameParameters.RespawnTime)
                    {
                        case GameParameters.RespawnTimeMode.sec1:
                            StartCoroutine(ChangerSelection(RespawnSelect, Respawn3Button));
                            GameParameters.RespawnTime = GameParameters.RespawnTimeMode.sec3;
                            break;
                        case GameParameters.RespawnTimeMode.sec2:
                            StartCoroutine(ChangerSelection(RespawnSelect, Respawn1Button));
                            GameParameters.RespawnTime = GameParameters.RespawnTimeMode.sec1;
                            break;
                        case GameParameters.RespawnTimeMode.sec3:
                            StartCoroutine(ChangerSelection(RespawnSelect, Respawn2Button));
                            GameParameters.RespawnTime = GameParameters.RespawnTimeMode.sec2;
                            break;
                        default:
                            break;
                    }
                    break;
                case ParametersButton.TypeButton.RespawnRight:
                    switch (GameParameters.RespawnTime)
                    {
                        case GameParameters.RespawnTimeMode.sec1:
                            StartCoroutine(ChangerSelection(RespawnSelect, Respawn2Button));
                            GameParameters.RespawnTime = GameParameters.RespawnTimeMode.sec2;
                            break;
                        case GameParameters.RespawnTimeMode.sec2:
                            StartCoroutine(ChangerSelection(RespawnSelect, Respawn3Button));
                            GameParameters.RespawnTime = GameParameters.RespawnTimeMode.sec3;
                            break;
                        case GameParameters.RespawnTimeMode.sec3:
                            StartCoroutine(ChangerSelection(RespawnSelect, Respawn1Button));
                            GameParameters.RespawnTime = GameParameters.RespawnTimeMode.sec1;
                            break;
                        default:
                            break;
                    }
                    break;
                case ParametersButton.TypeButton.PVLeft:
                    switch (GameParameters.PVMode)
                    {
                        case GameParameters.PlayersPVMode.percent50:
                            StartCoroutine(ChangerSelection(PVSelect, PV3Button));
                            GameParameters.PVMode = GameParameters.PlayersPVMode.percent200;
                            break;
                        case GameParameters.PlayersPVMode.percent100:
                            StartCoroutine(ChangerSelection(PVSelect, PV1Button));
                            GameParameters.PVMode = GameParameters.PlayersPVMode.percent50;
                            break;
                        case GameParameters.PlayersPVMode.percent200:
                            StartCoroutine(ChangerSelection(PVSelect, PV2Button));
                            GameParameters.PVMode = GameParameters.PlayersPVMode.percent100;
                            break;
                        default:
                            break;
                    }
                    break;
                case ParametersButton.TypeButton.PVRight:
                    switch (GameParameters.PVMode)
                    {
                        case GameParameters.PlayersPVMode.percent50:
                            StartCoroutine(ChangerSelection(PVSelect, PV2Button));
                            GameParameters.PVMode = GameParameters.PlayersPVMode.percent100;
                            break;
                        case GameParameters.PlayersPVMode.percent100:
                            StartCoroutine(ChangerSelection(PVSelect, PV3Button));
                            GameParameters.PVMode = GameParameters.PlayersPVMode.percent200;
                            break;
                        case GameParameters.PlayersPVMode.percent200:
                            StartCoroutine(ChangerSelection(PVSelect, PV1Button));
                            GameParameters.PVMode = GameParameters.PlayersPVMode.percent50;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
    }

    // METHODES
    void Awake()
    {
        // RECUP REFERENCES NON SETUP

        // ARENA
        Transform Arena = this.transform.Find("Arena");
        if (ArenaButton == null)
        {
            ArenaButton = Arena.Find("ArenaButton").GetComponent<Button>();
        }
        if (ArenaName == null)
        {
            ArenaName = Arena.Find("ArenaName").GetComponent<TextMeshProUGUI>();
        }
        if (ArenaImage == null)
        {
            ArenaImage = Arena.Find("ArenaPreview").Find("ArenaImage").GetComponent<Image>();
        }

        // TIME
        Transform Time = this.transform.Find("Time");
        if (TimeButton == null)
        {
            TimeButton = Time.Find("TimeButton").GetComponent<Button>();
        }
        if (TimeSelect == null)
        {
            TimeSelect = Time.Find("TimeSelect");
        }
        if (Time1Button == null)
        {
            Time1Button = Time.Find("Button1min");
        }
        if (Time2Button == null)
        {
            Time2Button = Time.Find("Button3min");
        }
        if (Time3Button == null)
        {
            Time3Button = Time.Find("Button5min");
        }

        // POWER-UPS
        Transform Power = this.transform.Find("PowerUps");
        if (PowerButton == null)
        {
            PowerButton = Power.Find("PowerButton").GetComponent<Button>();
        }
        if (PowerSelect == null)
        {
            PowerSelect = Power.Find("PowerSelect");
        }
        if (PowerLowButton == null)
        {
            PowerLowButton = Power.Find("ButtonLow");
        }
        if (PowerMedButton == null)
        {
            PowerMedButton = Power.Find("ButtonMed");
        }
        if (PowerHighButton == null)
        {
            PowerHighButton = Power.Find("ButtonHigh");
        }

        // RESPAWN
        Transform Respawn = this.transform.Find("Respawn");
        if (RespawnButton == null)
        {
            RespawnButton = Respawn.Find("RespawnButton").GetComponent<Button>();
        }
        if (RespawnSelect == null)
        {
            RespawnSelect = Respawn.Find("RespawnSelect");
        }
        if (Respawn1Button == null)
        {
            Respawn1Button = Respawn.Find("Button2sec");
        }
        if (Respawn2Button == null)
        {
            Respawn2Button = Respawn.Find("Button4sec");
        }
        if (Respawn3Button == null)
        {
            Respawn3Button = Respawn.Find("Button6sec");
        }

        // PV
        Transform PV = this.transform.Find("PV");
        if (PVButton == null)
        {
            PVButton = PV.Find("PVButton").GetComponent<Button>();
        }
        if (PVSelect == null)
        {
            PVSelect = PV.Find("PVSelect");
        }
        if (PV1Button == null)
        {
            PV1Button = PV.Find("Button50%");
        }
        if (PV2Button == null)
        {
            PV2Button = PV.Find("Button100%");
        }
        if (PV3Button == null)
        {
            PV3Button = PV.Find("Button200%");
        }

        // AUTRES
        if (BackgroundSelect == null)
        {
            BackgroundSelect = this.transform.Find("BackgroundSelect");
        }
        if (StartButton == null)
        {
            StartButton = this.transform.Find("StartButton").GetComponent<Button>();
        }

        // CONFIG INITIALE
        ConfigInitiale();
    }

    private void ConfigInitiale()
    {
        // ARENE
        ArenaName.text = GameParameters.SelectedArena.ToString();
        string chemin = "Images/ArenasPreview/" + GameParameters.SelectedArena.ToString();
        ArenaImage.sprite = Resources.Load(chemin, typeof(Sprite)) as Sprite;
    }

    public void AreneGauche()
    {
        if (GameParameters.SelectedArena == GameParameters.TypeArena.Bomby)
        {
            GameParameters.SelectedArena = GameParameters.TypeArena.Zalam;
        }
        else
        {
            GameParameters.SelectedArena--;
        }

        // CHANGEMENT NOM
        ArenaName.text = GameParameters.SelectedArena.ToString();

        // CHANGEMENT IMAGE
        string chemin = "Images/ArenasPreview/" + GameParameters.SelectedArena.ToString();
        ArenaImage.sprite = Resources.Load(chemin, typeof(Sprite)) as Sprite;

    }

    public void AreneDroite()
    {
        if (GameParameters.SelectedArena == GameParameters.TypeArena.Zalam)
        {
            GameParameters.SelectedArena = GameParameters.TypeArena.Bomby;
        }
        else
        {
            GameParameters.SelectedArena++;
        }

        // CHANGEMENT NOM
        ArenaName.text = GameParameters.SelectedArena.ToString();

        // CHANGEMENT IMAGE
        string chemin = "Images/ArenasPreview/" + GameParameters.SelectedArena.ToString();
        ArenaImage.sprite = Resources.Load(chemin, typeof(Sprite)) as Sprite;
    }

    // COROUTINES
    public IEnumerator ChangerSelection(Transform Selection, Transform Destination)
    {
        float delta = 0f;
        while (delta <= 1)
        {
            // 1 - INCREMENTATION DELTA
            delta += Time.deltaTime * 3;

            // 2 - MISE A JOUR EMPLACEMENT
            Selection.position = Vector3.Lerp(Selection.position, Destination.position, delta);

            yield return new WaitForEndOfFrame();                   // On attend avant la prochaine itération (pour voir l'effet au fur et à mesure)
        }

        Selection.position = Destination.position; // Positionnement final

        yield return null;                                          // On arrête l'animation
    }

    public IEnumerator ChangerBackgroundSelection()
    {
        // On détermine le Transform (Bouton) vers lequel diriger la selection
        Transform Destination = null;
        switch (boutonSelectionne)
        {
            case ParametersButton.TypeButton.Arena:
                Destination = ArenaButton.transform;
                break;
            case ParametersButton.TypeButton.Time:
                Destination = TimeButton.transform;
                break;
            case ParametersButton.TypeButton.Power:
                Destination = PowerButton.transform;
                break;
            case ParametersButton.TypeButton.Respawn:
                Destination = RespawnButton.transform;
                break;
            case ParametersButton.TypeButton.PV:
                Destination = PVButton.transform;
                break;
            default:
                break;
        }

        float delta = 0f;
        while (delta <= 1)
        {
            // 1 - INCREMENTATION DELTA
            delta += Time.deltaTime * 3;

            // 2 - MISE A JOUR EMPLACEMENT
            Vector3 pos = Vector3.Lerp(BackgroundSelect.position, Destination.position, delta);
            BackgroundSelect.position = new Vector3(BackgroundSelect.position.x, pos.y, BackgroundSelect.position.z);

            yield return new WaitForEndOfFrame();                   // On attend avant la prochaine itération (pour voir l'effet au fur et à mesure)
        }

        BackgroundSelect.position = new Vector3(BackgroundSelect.position.x, Destination.position.y, BackgroundSelect.position.z); // Positionnement final

        yield return null;                                          // On arrête l'animation
    }
}
