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

    public float FailMeterContribution {
        get => this.failMeterContribution;
        set => this.failMeterContribution = value;
    }

    void Update() {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        GameManager.instance.IncreaseMeter(this.FailMeterContribution * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Bullet"){
            hits += 1;
            GameManager.instance.IncreaseScore(pointValue);
            Destroy(other.gameObject);
            GameManager.instance.IncreaseMeter(-this.FailMeterContribution * 7.5f * Time.deltaTime);

            if (hits == hitPoints) {
                Debug.Log("gay");
                Destroy(this.gameObject);
            }

            this.transform.localScale = new Vector3(.5f, Mathf.Lerp(5, 1, (float)hits / hitPoints), 1);
        }
        else {
            speed = speed * -1.0f;
        }
    }

}
