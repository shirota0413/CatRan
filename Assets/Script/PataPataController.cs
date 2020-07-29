using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PataPataController : MonoBehaviour　{
    Animator animator;
    GameObject player;
    CircleCollider2D  coll;
    Rigidbody2D rigid2D;
    private SpriteRenderer sr = null;
    float speed = -0.006f;
    int key = 1;
    bool appear　= false;
    float span = 2.0f;
    float delta = 0.0f;
    //bool flyMode = true;
    bool isCollision = false;
    string mode = "fly";
    string playerTag = "Player";
    string groundTag = "ground";
    string kuriboTag = "kuribo";
    int point = 0;
    CoinScript count;

    void FlyMove() {
        if(sr.isVisible || appear == true) {
            this.appear = true;
            this.delta += Time.deltaTime;
            if (this.delta > this.span) {
                this.delta = 0;
                this.key = this.key * -1;
            }
            //キャラ反転
            // if(key != 0) {
            //     transform.localScale = new Vector3(key,1,1);
            // }
            transform.Translate(0,this.speed * this.key,0);
            this.animator.speed = 0.3f;
        }
    }

    void WalkMove() {
        if(key != 0) {
            transform.localScale = new Vector3(key,1,1);
        }
      transform.Translate(this.speed * this.key,0,0);
      this.animator.speed = 0.3f;
    }

    void FlyCollision(Collision2D collision) {
        if (collision.gameObject.name.Equals(playerTag) && this.isCollision == false && transform.position.y+0.3f < this.player.transform.position.y) {
            this.isCollision = true;
            this.player.GetComponent<Rigidbody2D>().AddForce(transform.up*5.0f,ForceMode2D.Impulse);
            this.animator.SetTrigger("NomalTrigger");
            this.rigid2D.bodyType = RigidbodyType2D.Dynamic;
            this.mode = "nomal";
        } else if (collision.gameObject.name.Equals(playerTag)) {
            count.SetPoint(this.point);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void WalkCollision(Collision2D collision) {
        if(collision.gameObject.name.Equals(playerTag) && this.isCollision == false) {
            this.isCollision = true;
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
                    this.animator.SetTrigger("KoraTrigger");
                    this.player.GetComponent<Rigidbody2D>().AddForce(transform.up*5.0f,ForceMode2D.Impulse);
                    this.coll = GetComponent<CircleCollider2D>();
                    this.coll.offset = new Vector2(0.0f,0.0f);
                    this.coll.radius = 0.25f;
                } else  {
                    count.SetPoint(this.point);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        } else if (mode == "killer" && collision.gameObject.tag.Equals(kuriboTag)) {
            Destroy(collision.gameObject);
        } else if (collision.gameObject.tag != groundTag && collision.gameObject.tag != playerTag ) {
            key = key * -1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        //playerとの衝突判定
        if (mode == "fly") {
            FlyCollision(collision);
        } else {
            WalkCollision(collision);
        }
    }





    // Start is called before the first frame update
    void Start()　{
        this.animator = GetComponent<Animator>();
        this.player = GameObject.Find("Player");
        this.sr = GetComponent<SpriteRenderer>();
        this.rigid2D = GetComponent<Rigidbody2D>();
        count = new CoinScript();
        this.point = count.getPoint();
    }

    // Update is called once per frame
    void Update()　{
        isCollision = false;
        if (mode == "fly") {
            FlyMove();
        } else {
            WalkMove();
        }

        if (transform.position.y < -9) {
            Destroy(gameObject);
        }
        
    }
}
