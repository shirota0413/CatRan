using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KuriboController : MonoBehaviour　{
    Animator animator;
    GameObject player;
    string playerTag = "Player";
    string groundTag = "ground";
    float speed = -0.006f;
    private SpriteRenderer sr = null;
    bool apper = false;
    int key = 1;
    int point = 0;
    CoinScript count;


    public void Delete()　{
      Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)　{
      if(collision.gameObject.name == playerTag)　{
        if(transform.position.y+0.3f < this.player.transform.position.y)　{
          this.speed = 0;
          this.animator.SetTrigger("DaiTrigger");
          this.player.GetComponent<Rigidbody2D>().AddForce(transform.up*5.0f,ForceMode2D.Impulse);
        }　else　{
          count.SetPoint(this.point);
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
      }
      else if (collision.gameObject.tag != groundTag && collision.gameObject.transform.position.y > this.transform.position.y - 0.2f)　{
        key = key * -1;
      }
    }
    // Start is called before the first frame update
    void Start()　{
      this.animator = GetComponent<Animator>();
      this.player = GameObject.Find("Player");
      this.sr = GetComponent<SpriteRenderer>();
      count = new CoinScript();
      this.point = count.getPoint();
    }

    // Update is called once per frame
    void Update()　{
      if (Mathf.Approximately(Time.timeScale, 1f)) {
        //画面に映った時に処理する
        if(sr.isVisible || apper == true)　{
          apper = true;
          //キャラを反転させる．
          if(key != 0)　{
            transform.localScale = new Vector3(key,1,1);
          }
          transform.Translate(this.speed * this.key,0,0);
          this.animator.speed = 0.3f;
        }
        if (transform.position.y < -9) {
          Delete();
        }
      }
    }
}
