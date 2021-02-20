using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public int pointValue = 1;
    public float speed = 1.0f;

    void Update() {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Bullet"){
            GameManager.instance.IncreaseScore(pointValue);
            Destroy(other.gameObject);
        }
        else {
            speed = speed * -1.0f;
        }
    }

}
