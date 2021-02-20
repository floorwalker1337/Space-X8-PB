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
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion
    
    public float score = 0;

    // Callbacks
    public delegate void OnScoreChanged();
    public OnScoreChanged onScoreChangedCallback;

    void Start() {
        if (onScoreChangedCallback != null) {onScoreChangedCallback.Invoke();}
    }
    void Update() {

    }

    public void IncreaseScore(int points) {
        score += points;
        if (onScoreChangedCallback != null) {onScoreChangedCallback.Invoke();}
    }
}
