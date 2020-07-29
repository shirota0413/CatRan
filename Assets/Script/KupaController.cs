using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KupaController : MonoBehaviour {
    Animator animator;
    GameObject player;
    GameObject blessGenerator;
    private SpriteRenderer sr = null;
    CoinScript count;
    Rigidbody2D rigid2D;
    BlessGenerator script;
    float speed = -0.005f;
    int key = 1;
    float span = 1.0f;
    float delta = 0.0f; 
    bool isJump = false;
    float jumpForce = 5.0f;
    int pattern = 0;
    int point = 0;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Player") {
            count.SetPoint(this.point);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void move1() {
        transform.Translate(this.speed * -1,0,0);
        jump();
    }

    void move2() {
        transform.Translate(this.speed * 1,0,0);
    }

    void move3() {
        transform.Translate(this.speed * -1,0,0);
    }

    void move4() {
        transform.Translate(this.speed * 1,0,0);
        jump();
        this.script.Bless();
    }

    void jump() {
        if (isJump == false) {
            this.rigid2D.AddForce(transform.up*this.jumpForce,ForceMode2D.Impulse);
            this.isJump = true;
        }
    }

    void move() {
        this.delta += Time.deltaTime;

        if (this.delta > this.span) {
            this.isJump = false;
            System.Random r = new System.Random();
            this.delta = 0;
            this.pattern = r.Next(0, 4);
            this.script.isBlessSet(false);
        }

        switch(this.pattern) {
            case 0:
                move1();
                break;
            case 1:
                move2();
                break;
            case 2:
                move3();
                break;
            case 3:
                move4();
                break;
            default:
                Debug.Log("失敗");
                break;
        }        
    }

    // Start is called before the first frame update
    void Start() {
        this.animator = GetComponent<Animator>();
        this.player = GameObject.Find("Player");
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.sr = GetComponent<SpriteRenderer>();
        this.blessGenerator = GameObject.Find("BlessGenerator");
        this.script = blessGenerator.GetComponent<BlessGenerator>();
        count = new CoinScript();
        this.point = count.getPoint();
    }

    // Update is called once per frame
    void Update() {
        if(sr.isVisible)　{
            if (95.0f < this.gameObject.transform.position.x && this.gameObject.transform.position.x < 104.4) {
                move();
            } else if (this.gameObject.transform.position.x <= 95.0f) {
                transform.Translate(this.speed * this.key * -1,0,0);
            } else {
                transform.Translate(this.speed * this.key,0,0);
            }

            
            if(this.gameObject.transform.position.x  + 1 < this.player.transform.position.x )　{
                key = -1;
            } else {
                key = 1;
            }
            transform.localScale = new Vector3(key,1,1);
            this.animator.speed = 0.3f;
        }

        if (gameObject.transform.position.y < -8.0) {
            Destroy(gameObject);
        }
    }
}
