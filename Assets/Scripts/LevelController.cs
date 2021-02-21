using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private Gradient failGrad = new Gradient();
    public Color Color 
    {
        get {
            SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();
            return spriteRenderer.color;
        }
        set
        {
            SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();
            spriteRenderer.color = value;
        }
    }

    void OnEnable() {
        GameManager.OnMeterChanged += RespondToFailMeter;
        GradientColorKey[] colorKey = new GradientColorKey[2];

        //colorKey[0].color = new Color(174/255f, 255/255f, 253/255f, 255/255f);
        colorKey[0].color = new Color(0f, 0f, 0f, 255/255f);
        colorKey[0].time = 0.0f;

        colorKey[1].color = new Color(84/255f, 0f, 0f, 255/255f);
        colorKey[1].time = 1.0f;

        //colorKey[2].color = new Color(198/255f, 32/255f, 32/255f, 255/255f);
        //colorKey[2].time = 1.0f;
        
        GradientAlphaKey[] alphaKey;
        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 1.0f;

        failGrad.SetKeys(colorKey, alphaKey);
    }

    void Update() {
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Bullet"){
            Destroy(other.gameObject);
        }
    }

    void RespondToFailMeter (float meter) {
        this.Color = failGrad.Evaluate(meter);
    }
}
