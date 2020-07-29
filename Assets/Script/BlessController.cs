using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlessController : MonoBehaviour {
    GameObject kupa;
    float key =　1.0f;
    float speed = - 0.01f;
    int point = 0;
    CoinScript count;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Player") {
            count.SetPoint(this.point);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void Start() {
        this.kupa = GameObject.Find("kupa");
        this.key = this.kupa.transform.localScale.x;
        count = new CoinScript();
        this.point = count.getPoint();
        print(this.key);
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(this.speed * this.key ,0,0);
        transform.localScale = new Vector3(key,1,1);
        if (transform.position.x < 88) {
            Destroy(gameObject);
        }
    }
}
