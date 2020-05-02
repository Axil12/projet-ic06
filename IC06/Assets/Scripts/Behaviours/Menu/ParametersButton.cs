using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ParametersButton : MonoBehaviour, ISelectHandler
{
    public enum TypeButton
    {
        Arena = 0,
        Time,
        Power,
        Respawn,
        PV,
        Start,
        ArenaLeft,
        ArenaRight,
        TimeLeft,
        TimeRight,
        PowerLeft,
        PowerRight,
        RespawnLeft,
        RespawnRight,
        PVLeft,
        PVRight,
    }
    public TypeButton typeBouton;

    void Start()
    {

    }

    public void OnSelect(BaseEventData eventData)
    {
        if (typeBouton == TypeButton.ArenaLeft || typeBouton == TypeButton.ArenaRight)
        {
            StartCoroutine(AnimationFleche());
        }

        MenuScript.instance.parametersMenuScript.BoutonSelectionne = typeBouton;
    }

    private IEnumerator AnimationFleche()
    {
        Image fleche = this.transform.Find("Image").GetComponent<Image>();

        float delta = 0f;
        fleche.color = Color.cyan;
        while (delta <= 1)
        {
            // INCREMENTATION DELTA
            delta += Time.deltaTime * 5;

            yield return new WaitForEndOfFrame();                   // On attend avant la prochaine itération (pour voir l'effet au fur et à mesure)
        }

        fleche.color = Color.black;
        yield return null;
    }

    public IEnumerator ChangerSelection()
    {
        // On détermine le Transform (Bouton) vers lequel diriger la selection
        Transform Destination = this.transform;
        Transform Selection = null;

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
}
