using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorGenerator : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject elevatorPrefab;
    float span = 3.0f;
    float delta = 0;
    void Start() {

         
    }

    // Update is called once per frame
    void Update() {
        this.delta += Time.deltaTime;
        if (this.delta > this.span) {
            this.delta = 0;
            GameObject go = Instantiate(elevatorPrefab) as GameObject;
            go.transform.position = new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,0);
        }
    }
}
