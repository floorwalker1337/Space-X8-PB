using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    #region Singleton
    void Awake() {
        if (instance != null) {
            Debug.LogWarning("More than one instance of Game_Manager found!");
            return;
        }
        instance = this;
    }
    #endregion
    
    public float score = 0;
    public float meter = 0;

    // Callbacks
    public delegate void OnScoreChanged();
    public OnScoreChanged onScoreChangedCallback;

    public delegate void PublishMeterEvent (float meter);
    public static event PublishMeterEvent OnMeterChanged;

    public delegate void OnDefeatUIChange();
    public OnDefeatUIChange onDefeatUIChangeCallback;

    void Start() {
        if (onScoreChangedCallback != null) {onScoreChangedCallback.Invoke();}
    }
    void Update() {
        if (meter >= 1) {
            if (onDefeatUIChangeCallback != null) {onDefeatUIChangeCallback.Invoke();}
        }
    }

    public void IncreaseScore(int points) {
        score += points;
        if (onScoreChangedCallback != null) {onScoreChangedCallback.Invoke();}
    }

    public void IncreaseMeter(float points) {
        meter += points;
        meter = meter < 0 ? 0 : meter;
        meter = meter > 1 ? 1 : meter;
        PublishMeter(meter);
    }

    public void PublishMeter (float meter) {
        if (OnMeterChanged != null) {
            OnMeterChanged (meter);
        }
    }
}