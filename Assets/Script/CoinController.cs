using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
    string playerTag = "Player";
    bool isAdd = true;
    GameObject director;
    CoinScript count;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.name == playerTag && isAdd == true) {
            this.isAdd = false;
            count.AddCoin();
            Destroy(this.gameObject);
            print("Coint get");
        }
    }

    // Start is called before the first frame update
    void Start() {
        count = new CoinScript();
    }

    // Update is called once per frame
    void Update() {


    }
}
