using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerr : MonoBehaviour　{
  Rigidbody2D rigid2D;
  Animator animator;
  float jumpForce = 10.0f;//ジャンプ力  
  float walkForce = 8.0f;//歩く力
  float maxWalkSpeed = 5.0f;//走る最大速度
  bool isJump = false;
  int point = 0;
  CoinScript count;
  



  void OnTriggerEnter2D(Collider2D collider) {
    if (collider.tag != "kuribo" && collider.tag != "nokonoko")
    isJump = false;
  }

  // Start is called before the first frame update
  void Start() {
    this.rigid2D = GetComponent<Rigidbody2D>();
    this.animator = GetComponent<Animator>();
    count = new CoinScript();
    this.point = count.getPoint();
  }

  // Update is called once per frame
  void Update() {

    //ジャンプ処理：isJumpがfalseの時ジャンプできるようにしている
    if(Input.GetKeyDown(KeyCode.Space) && this.isJump == false) {
      this.animator.SetTrigger("JumpTrigger");
      this.rigid2D.AddForce(transform.up*this.jumpForce,ForceMode2D.Impulse);
      this.isJump = true;
    }
    //左右移動
    int key = 0;
    if(Input.GetKey(KeyCode.RightArrow)) key = 1;
    if(Input.GetKey(KeyCode.LeftArrow)) key = -1;

    //プレイヤの速度
    float speedx = Mathf.Abs(this.rigid2D.velocity.x);

    //スピード制限
    if(speedx < this.maxWalkSpeed) {
      this.rigid2D.AddForce(transform.right*key*this.walkForce,ForceMode2D.Force);
    }

    //キャラ反転
    if(key != 0){
      transform.localScale = new Vector3(key,1,1);
    }
    //アニメーションの速度
    if(this.rigid2D.velocity.y == 0) {
      this.animator.speed = speedx /3.0f;
    } else {
      this.animator.speed = 1.0f;
    }

    if (transform.position.y < -9) {
      count.SetPoint(this.point);
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  }
}
