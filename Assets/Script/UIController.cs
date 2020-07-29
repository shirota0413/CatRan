using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    GameObject timerText;
    GameObject pointText;
    float time = 180.0f;
    int point = 0;
    CoinScript count;

    // public void AddCoin() {
    //     this.point  += 1;
    // }
    
    // Start is called before the first frame update
    void Start() {
        count = new CoinScript();
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
    }

    // Update is called once per frame
    void Update() {
        this.time -= Time.deltaTime;
        this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
        point = count.getPoint();
        if (this.point == 100) {
            point = 0;
        }
        this.pointText.GetComponent<Text>().text = this.point.ToString() + " coin";
    }
}
