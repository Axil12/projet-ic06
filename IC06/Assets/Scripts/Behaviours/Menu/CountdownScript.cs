using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    // REFERENCES Transform
    public Transform Transform1;
    public Transform Transform2;
    public Transform Transform3;
    public Transform TransformGo;

    // REFERENCES IMAGES
    public Image Image1;
    public Image Image2;
    public Image Image3;
    public Image ImageGo;


    // METHODES

    void Start()
    {
        // REFERENCES MANQUANTES
        if(Transform1 == null)
        {
            Transform1 = this.transform.Find("1");
        }
        if (Transform2 == null)
        {
            Transform2 = this.transform.Find("2");
        }
        if (Transform3 == null)
        {
            Transform3 = this.transform.Find("3");
        }
        if (TransformGo == null)
        {
            TransformGo = this.transform.Find("GO");
        }

        if (Image1 == null)
        {
            Image1 = Transform1.GetComponent<Image>();
        }
        if (Image2 == null)
        {
            Image2 = Transform2.GetComponent<Image>();
        }
        if (Image3 == null)
        {
            Image3 = Transform3.GetComponent<Image>();
        }
        if (ImageGo == null)
        {
            ImageGo = TransformGo.GetComponent<Image>();
        }

        // COUNTDOWN
        if (GameManagerScript.instance.CountdownEnabled)
        {
            StartCoroutine(Countdown());
        }
        else
        {
            GameManagerScript.instance.pausePossible = true;
            GameManagerScript.instance.pause = false;
        }
    }

    private IEnumerator Countdown()
    {
        // INIT
        float delta = 1;

        // 3
        Transform3.gameObject.SetActive(true);
        GameManagerScript.instance.JouerSonVoix(Sons.Voice.Trois);
        while (delta >= 0)
        {
            // INCREMENTATION
            delta -= 0.008f;

            // ANIMATION
            Color tempColor = Image3.color;
            tempColor.a = delta;
            Image3.color = tempColor;

            yield return new WaitForSecondsRealtime(0.001f);
        }
        Transform3.gameObject.SetActive(false);
        delta = 1;

        // 2
        Transform2.gameObject.SetActive(true);
        GameManagerScript.instance.JouerSonVoix(Sons.Voice.Deux);
        while (delta >= 0)
        {
            // INCREMENTATION
            delta -= 0.008f;

            // ANIMATION
            Color tempColor = Image2.color;
            tempColor.a = delta;
            Image2.color = tempColor;

            yield return new WaitForSecondsRealtime(0.001f);
        }
        Transform2.gameObject.SetActive(false);
        delta = 1;

        // 1
        Transform1.gameObject.SetActive(true);
        GameManagerScript.instance.JouerSonVoix(Sons.Voice.Un);
        while (delta >= 0)
        {
            // INCREMENTATION
            delta -= 0.008f;

            // ANIMATION
            Color tempColor = Image1.color;
            tempColor.a = delta;
            Image1.color = tempColor;

            yield return new WaitForSecondsRealtime(0.001f);
        }
        Transform1.gameObject.SetActive(false);
        delta = 1;

        // GO
        GameManagerScript.instance.pausePossible = true;
        GameManagerScript.instance.pause = false;
        TransformGo.gameObject.SetActive(true);
        GameManagerScript.instance.JouerSonVoix(Sons.Voice.Begin);
        while (delta >= 0)
        {
            // INCREMENTATION
            delta -= 0.008f;

            // ANIMATION
            Color tempColor = ImageGo.color;
            tempColor.a = delta;
            ImageGo.color = tempColor;

            yield return new WaitForSecondsRealtime(0.001f);
        }
        TransformGo.gameObject.SetActive(false);
        delta = 1;

        this.gameObject.SetActive(false);

        yield return null;
    }
}
