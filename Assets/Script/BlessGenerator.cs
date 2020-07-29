using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessGenerator : MonoBehaviour {
    GameObject kupa;
    public GameObject BlessPrefab;
    bool isBless = false;
    float key = 0;
    float posx = -1.5f;
    // Start is called before the first frame update
    public void isBlessSet(bool hoge) {
        this.isBless = hoge;
    }
    void Start() {
        this.kupa = GameObject.Find("kupa");
    }

    // Update is called once per frame
    public void Bless() {
        if (isBless == false) {
            this.key = this.kupa.transform.localScale.x;
            GameObject go = Instantiate(BlessPrefab) as GameObject;
            go.transform.position = new Vector3(this.kupa.transform.position.x + this.posx *this.key,this.gameObject.transform.position.y + 0.5f,0);
            this.isBless = true;
        }
    }
}
