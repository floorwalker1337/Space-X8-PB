using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public TextMeshProUGUI scoreField;
    // Start is called before the first frame update
    void Start() {
        GameManager.instance.onScoreChangedCallback = UpdateScoreUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreUI() {
        scoreField.text = GameManager.instance.score.ToString();
    }
}
