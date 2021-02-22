using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Gradient bulletGrad= new Gradient();
    private float gradCounter = 0.0f;
    public float rotSpeed = 1.0f;
    public float speed = 1.0f;
    public int framesPerBulletSpawn = 10;
    public int frameCounter = 0;
    public string currentShape = "x";
    public bool isMoving = false;
    public float borderRange = 0.1f;
    public Vector3 direction = Vector3.up;
    public float yMax = 2.6f;
    public float xMax = 5.2f;

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

    void Start() {
        GradientColorKey[] colorKey = new GradientColorKey[6];

        colorKey[0].color = new Color(255/255f, 0f, 0f, 1.0f);
        colorKey[0].time = 0.0f;

        colorKey[1].color = new Color(254/255f, 127/255f, 0f, 1.0f);
        colorKey[1].time = 0.2f;

        colorKey[2].color = new Color(223/255f, 224/255f, 7/255f, 1.0f);
        colorKey[2].time = 0.4f;

        colorKey[3].color = new Color(7/255f, 152/255f, 36/255f, 1.0f);
        colorKey[3].time = 0.6f;

        colorKey[4].color = new Color(7/255f, 20/255f, 158/255f, 1.0f);
        colorKey[4].time = 0.8f;

        colorKey[5].color = new Color(165/255f, 6/255f, 178/255f, 1.0f);
        colorKey[5].time = 1.0f;
        
        GradientAlphaKey[] alphaKey;
        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 1.0f;

        bulletGrad.SetKeys(colorKey, alphaKey);
    }

    // Update is called once per frame
    void Update() {
        frameCounter += 1;

        if (Input.GetKeyDown("x")) {
            ChangeShape("X");
        }
        if (Input.GetKeyDown("b")) {
            ChangeShape("B");
        }
        if (Input.GetKeyDown("p")) {
            isMoving = isMoving ? false : true;
        }
        if (Input.GetKeyDown("8")) {
            direction = Vector3.Cross(direction, Vector3.forward);
        }
        if (Input.GetKey("space")) {
            rotSpeed = -Mathf.Abs(rotSpeed);
        }
        else {
            rotSpeed = Mathf.Abs(rotSpeed);
        }

        if (frameCounter % framesPerBulletSpawn == 0) {
            Shoot();
        }
        // Movement
        if (Mathf.Abs(transform.position.y) > yMax ) {
            direction *= -1;
        }
        if (Mathf.Abs(transform.position.x) > xMax ) {
            direction *= -1;
        }
        transform.Rotate(0,0,rotSpeed);
        if (isMoving) TranslatePlayer();
        gradCounter = gradCounter > 1.0f ? 0 : gradCounter + 0.001f; 
        this.Color = bulletGrad.Evaluate(gradCounter);
    }

    public void Shoot() {
        Transform vt = this.transform.Find("Upper");
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.GetComponent<BulletController>().Color = bulletGrad.Evaluate(gradCounter);
        bullet.transform.position = vt.transform.position;
        Vector2 dir = vt.position - this.transform.Find("Upper_O").position;
        dir.Normalize();
        bullet.GetComponent<BulletController>().SetDireciton(dir);

        vt = this.transform.Find("Middle");
        GameObject bullet2 = Instantiate(bulletPrefab);
        bullet2.GetComponent<BulletController>().Color = bulletGrad.Evaluate(gradCounter);
        bullet2.transform.position = vt.transform.position;
        Vector2 dir2 = vt.position - this.transform.Find("Middle_O").position;
        dir2.Normalize();
        bullet2.GetComponent<BulletController>().SetDireciton(dir2);
    }

    public void ChangeShape(string newShape) {
        GameObject[] objs = this.gameObject.scene.GetRootGameObjects();
        foreach (GameObject o in objs) {
            if (o.name == newShape) {
                o.SetActive(true);
                o.transform.position = this.transform.position;
                o.transform.rotation = this.transform.rotation;
            }
        }
        this.gameObject.SetActive(false);
    }

    public void TranslatePlayer() {
        transform.position += direction * speed * Time.deltaTime;
    }

}
