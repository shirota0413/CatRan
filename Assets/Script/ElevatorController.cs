using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour {
    float speed = -0.01f;
    // Start is called before the first frame update
    void Start() {
        switch (gameObject.tag) {
            case "up":
                speed = speed * -1;
                break;
            case "down":
                speed = speed * 1;
                break;
            default:
                print("失敗");
                break;
        }
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(0,speed,0);
        if (transform.position.y < -6.0 || transform.position.y > 6.0) {
            Destroy(gameObject);
        }
    }
}
