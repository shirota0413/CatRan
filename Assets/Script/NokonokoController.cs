using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class NokonokoController : MonoBehaviour {
  Animator animator;
  GameObject player;
  float speed = -0.006f;
  int key = 1;
  SpriteRenderer sr = null;
  string playerTag = "Player";
  string groundTag = "ground";
  string kuriboTag = "kuribo";
  string mode = "nomal";
  bool appear　= false;
  bool  span = false;
  int point = 0;
  CoinScript count;
  // Start is called before the first frame update

  void OnCollisionEnter2D(Collision2D collision) {
  //playerとの衝突判定
  if(collision.gameObject.name.Equals(playerTag) && this.span == false) {
    this.span = true;
    //動かない甲羅状態()かノコノコもしくは動いている甲羅状態かで判定を分けている
    if (mode == "kora" ) {
      if(transform.position.x < this.player.transform.position.x) {
        this.key = -1;
      } else {
        this.key = 1;
      }
      this.speed = 0.03f; 
      mode = "killer";
    } else{
      //上から踏まれているかで処理を変えている．
      if(transform.position.y+0.3f < this.player.transform.position.y) {
        mode = "kora";
        this.speed = 0;
        this.animator.SetTrigger("koraTrigger");
        this.player.GetComponent<Rigidbody2D>().AddForce(transform.up*5.0f,ForceMode2D.Impulse);
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        collider.offset = new Vector2(0.0f,0.0f);
        collider.radius = 0.25f;
      } else  {
        count.SetPoint(this.point);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }
    }
  } else if (mode == "killer" && collision.gameObject.tag.Equals(kuriboTag)) {
    Destroy(collision.gameObject);
  }
  
  else if (collision.gameObject.tag != groundTag && collision.gameObject.tag != playerTag ) {
    key = key * -1;
  }
}

  void Start() {
    this.animator = GetComponent<Animator>();
    this.sr = GetComponent<SpriteRenderer>();
    this.player = GameObject.Find("Player");
    count = new CoinScript();
    this.point = count.getPoint();
  }

  // Update is called once per frame
  void Update() {
    //1回のUpdate分は無敵にできる
    if (this.span == true) {
      this.span = false;
    }
    //画面に映った時に処理をする
    if(sr.isVisible || appear == true) {
      appear = true;
      //キャラ反転
      if(key != 0) {
        transform.localScale = new Vector3(key,1,1);
      }
      transform.Translate(this.speed * this.key,0,0);
      this.animator.speed = 0.3f;
    }
    if (transform.position.y < -9) {
      Destroy(gameObject);
    }
  }
}

