using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float rotSpeed = 1.0f;
    public float speed = 1.0f;
    public int framesPerBulletSpawn = 10;
    public int frameCounter = 0;
    public string currentShape = "x";

    // Update is called once per frame
    void Update() {
        frameCounter += 1;

        if (Input.GetKeyDown("x")) {

        }
        if (Input.GetKeyDown("b")) {

        }
        if (Input.GetKeyDown("p")) {

        }
        if (Input.GetKeyDown("8")) {

        }
        if (Input.GetKeyDown("space")) {
            rotSpeed = -1*rotSpeed;
        }

        if (frameCounter % framesPerBulletSpawn == 0) {
            Shoot();
        }
        transform.Rotate(0,0,rotSpeed);
    }

    public void Shoot() {
        Component[] vertexTransforms;
        vertexTransforms = GetComponentsInChildren<Transform>();
        foreach (Transform vt in vertexTransforms) {
            if (vt.position == transform.position) { continue; }
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = vt.position;
            Vector2 dir = vt.position;
            dir.Normalize();
            bullet.GetComponent<BulletController>().SetDireciton(dir);
            }
    }

}
