using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
  GameObject player;
  float x = -0.45f;
  // Start is called before the first frame update
  void Start() {
    this.player = GameObject.Find("Player");
  }

  // Update is called once per frame
  void Update(){
    Vector3 playerPos = this.player.transform.position;
    if (playerPos.x > 0) {
      x = playerPos.x;
    } else {
      x = 0f;
    }
    transform.position = new Vector3(x,transform.position.y,transform.position.z);
  }
}
