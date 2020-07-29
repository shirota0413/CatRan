using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemBoxController : MonoBehaviour {
  //publicじゃないとスクリプトにgameObjectを追加できない
  public GameObject content;
  public Sprite  openSprite;
  GameObject director;
  GameObject player;
  Vector2 movePoint;
  bool isOpen = false;
  bool isActive = true;
  bool isAdd = true;
  float rollSpeed = 3.0f;
  SpriteRenderer sr;
  BoxCollider2D[] colliders;
  BoxCollider2D playerCollider;
  CoinScript count;

  void GetCoin() {
    if ( isAdd == true) {
      isAdd = false;
      count.AddCoin();
      //this.director.GetComponent<UIController1_2>().AddCoin();
      Destroy(this.content);
      print("coutn");
    }

  }

  //アイテムボックスが叩かれた判定
  private void OnCollisionEnter2D(Collision2D col) {
    if(colliders[1].IsTouching(playerCollider) && col.gameObject.CompareTag("Player") && isOpen ==false) {
      content.gameObject.SetActive(true);
      isOpen = true;
      StartCoroutine(WaitSwitchOff());
    }
  }

  private IEnumerator WaitSwitchOff() {
    yield return new WaitForSeconds(1.0f);
    isActive = false;
  }
  // Start is called before the first frame update
  void Start() {


    count = new CoinScript();
    this.player = GameObject.FindWithTag("Player");
    this.playerCollider = player.GetComponent<BoxCollider2D>();
    this.sr =  GetComponent<SpriteRenderer>();
    this.colliders = GetComponentsInChildren<BoxCollider2D>();

    //飛び出るアイテムのコピーをしている
    content = Instantiate(content);
    content.transform.position = transform.position;
    content.transform.SetParent(gameObject.transform);
    content.gameObject.SetActive(false);

    //アイテムの飛び出す目標地点を定めている
    movePoint = (Vector2)transform.position + new Vector2(0.0f,1.2f);

    this.director = GameObject.Find("UIController");
  }

  // Update is called once per frame
  void Update() {
    if (content != null) {
      if(isOpen && isActive) {
      //目標地点までの動きを設定している
      content.transform.position = Vector2.Lerp(content.transform.position,movePoint,0.35f);
      Invoke("GetCoin",0.2f);
      content.transform.Rotate(0,rollSpeed,0);
      this.sr.sprite = openSprite;
      }
      
    }
  }


}
