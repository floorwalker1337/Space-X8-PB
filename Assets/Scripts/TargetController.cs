using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public int pointValue = 1;
    public int hits = 0;
    public int hitPoints = 100;
    public float speed = 1.0f;
    public float failMeterContribution;
    public float failMeterHitSubtractionFactor;
    public Vector3 direction;

    public delegate void PublishDieEvent ();
    public static event PublishDieEvent OnDeath;

    public float FailMeterContribution {
        get => this.failMeterContribution;
        set => this.failMeterContribution = value;
    }

    void Update() {
        transform.Translate(direction * speed * Time.deltaTime);
        if (Time.time > 5) {
            GameManager.instance.IncreaseMeter(this.FailMeterContribution * Time.deltaTime);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Bullet"){
            hits += 1;
            GameManager.instance.IncreaseScore(pointValue);
            Destroy(other.gameObject);
            GameManager.instance.IncreaseMeter(-this.FailMeterContribution * failMeterHitSubtractionFactor * Time.deltaTime);

            if (hits == hitPoints) {
                PublishDeath();
                Destroy(this.gameObject);
            }

            this.transform.localScale = new Vector3(.5f, Mathf.Lerp(5, .6f, (float)hits / hitPoints), 1);
        }
        else {
            speed = speed * -1.0f;
        }
    }

    public void PublishDeath() {
        if (OnDeath != null) {
            OnDeath();
        }
    }

}
