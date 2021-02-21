using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
    void OnEnable() {
        GameManager.OnMeterChanged += RespondToFailMeter;
    }

    void RespondToFailMeter(float meter) {
        Debug.Log("HERE");
        if (meter > .6f && meter < .75f) {
            this.transform.position = new Vector3(Random.Range(-.05f, .05f), 0f, -10f);
        }
        else if (meter > .75f && meter < .9f) {
            this.transform.position = new Vector3(Random.Range(-.1f, .1f), 0f, -10f);
        }
        else if (meter > .9f) {
            this.transform.position = new Vector3(Random.Range(-.2f, .2f), 0f, -10f);
        }
    }
}
