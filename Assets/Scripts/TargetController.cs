using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public int pointValue = 1;
    public float speed = 1.0f;
    public float failMeterContribution;

    public float FailMeterContribution
    { get => this.failMeterContribution;
      set => this.failMeterContribution = value;
    }

    void Update() {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        GameManager.instance.IncreaseMeter(this.FailMeterContribution * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Bullet"){
            GameManager.instance.IncreaseScore(pointValue);
            Destroy(other.gameObject);
            GameManager.instance.IncreaseMeter(-this.FailMeterContribution * 7.5f * Time.deltaTime);
        }
        else {
            speed = speed * -1.0f;
        }
    }

}
