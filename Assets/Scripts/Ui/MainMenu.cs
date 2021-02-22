using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Fader fields
    public Fader fader;
    public void Update() {

    }

    public void OnStartClick() {
        //Fade
        //gameObject.SetActive(false);
        StartCoroutine(fader.SceneFade(Fader.FadeDirection.In));
    }

    public void OnExitClick() {
        Application.Quit();
    }


}
