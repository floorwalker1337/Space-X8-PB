using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Fader fields
    public RawImage fadeOutUIImage;
    public float fadeSpeed;
    public enum FadeDirection {
        In, // Alpha = 1
        Out // Aplha = 0
    }

    public void Update() {

    }

    public void OnStartClick() {
        //Fade
        //gameObject.SetActive(false);
        StartCoroutine(Fade(FadeDirection.In));
    }

    public void OnExitClick() {
        Application.Quit();
    }

    private IEnumerator Fade(FadeDirection fadeDirection) {
        float alpha = (fadeDirection == FadeDirection.Out)? 1 : 0;
        float fadeEndValue = (fadeDirection == FadeDirection.Out)? 0 : 1;
        if (fadeDirection == FadeDirection.Out) {
            while (alpha >= fadeEndValue) {
                SetColorImage(ref alpha, fadeDirection); 
                yield return null;
            }
            fadeOutUIImage.enabled = false;
        }
        else {
            fadeOutUIImage.enabled = true;
            while (alpha <= fadeEndValue) {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
        }
        SceneLoader.Load("SampleScene");
    }

    private void SetColorImage(ref float alpha, FadeDirection fadeDirection) {
        fadeOutUIImage.color = new Color (fadeOutUIImage.color.r,fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
        alpha += Time.deltaTime * (fadeSpeed) * ((fadeDirection == FadeDirection.Out)? -1 : 1) ;
    }
}
