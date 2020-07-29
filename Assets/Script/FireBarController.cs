using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireBarController : MonoBehaviour{
    int point = 0;
    CoinScript count;


    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("hoge");
        if (collision.gameObject.name == "Player") {
            count.SetPoint(this.point);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Start() {
        count = new CoinScript();
        this.point = count.getPoint();
    }
}
