using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    public enum Scene {
        Main_Menu, 
        Controls_Screen,
        Main_Scene
    }

    #region Singleton
    void Awake() {
        if (instance != null) {
            Debug.LogWarning("More than one instance of SceneLoader found!");
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    public static void Load(string sceneName) {
        Debug.Log("Changing scene to " + sceneName + "...");
        SceneManager.LoadScene(sceneName);
    }
}