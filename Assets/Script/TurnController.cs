using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour {
    Rigidbody2D rigid2D;
    float key  = -0.01f;
    float span = 2.0F;
    float turnForce = 100.0f;
    float delta = 0;
    // Start is called before the first frame update
    void Start() {
        this.rigid2D = GetComponent<Rigidbody2D>();
        if (gameObject.tag == "down") {
            this.key = this.key * -1;
        }
    }

    // Update is called once per frame
    void Update() {
        this.delta += Time.deltaTime;
        if (this.delta > this.span) {
            this.delta = 0;
            this.key = this.key * -1;
        }
        this.rigid2D.velocity = new Vector3(this.turnForce * this.key, 0, 0);
    }
}
