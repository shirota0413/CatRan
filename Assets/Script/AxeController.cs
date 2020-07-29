using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour {
    GameObject hasi;
    void OnTriggerEnter2D(Collider2D collider) {

        if (collider.gameObject.tag == "Player") {
            Destroy(this.hasi);
        }
    }
    // Start is called before the first frame update
    void Start() {
        this.hasi = GameObject.Find("hasi");
    }

    // Update is called once per frame
    void Update() {
        
    }
}
