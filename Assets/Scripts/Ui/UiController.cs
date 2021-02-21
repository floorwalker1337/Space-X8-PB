using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public Text scoreField;
    public Text gameOverScore; 
    public GameObject defeatScreen;
    public Fader fader;
    // Start is called before the first frame update
    void Start() {
        GameManager.instance.onScoreChangedCallback = UpdateScoreUI;
        GameManager.instance.onDefeatUIChangeCallback = OnDefeat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreUI() {
        scoreField.text = GameManager.instance.score.ToString();
    }

    public void OnDefeat() {
        StartCoroutine(fader.DefeatFade(Fader.FadeDirection.In));
        SetFinalScore();
    }

    public void OnRetryClick() {
        StartCoroutine(fader.SceneFade(Fader.FadeDirection.In));
    }

    public void OnExitClick() {
        Application.Quit();
    }

    public void SetFinalScore() {
        string finalScore = "Score: " + GameManager.instance.score.ToString();
        gameOverScore.text = finalScore;
    }
}
