using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Bullet"){
            Destroy(other.gameObject);
        }
    }
}
