using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownController : MonoBehaviour {
    float speed  = -0.01f;
    float span = 1.75f;
    float delta = 0;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        this.delta += Time.deltaTime;
        if (this.delta > this.span) {
            this.delta = 0;
            this.speed = this.speed * -1;
        }
        transform.Translate(0,this.speed,0);
    }
}
