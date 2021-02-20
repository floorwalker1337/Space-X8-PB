using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector2 direction;
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetDireciton(Vector2 dir) {
        direction = dir;
    }

}
