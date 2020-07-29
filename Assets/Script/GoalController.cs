using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour　{
    // Start is called before the first frame update
    void Start()　{
        print(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()　{
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        
        if (collider.gameObject.name == "Player") {
            switch (SceneManager.GetActiveScene().name) {
                case "1-1":
                     SceneManager.LoadScene("1-2");
                    break;
                case "1-2":
                     SceneManager.LoadScene("1-3");
                    break;
                case "1-3":
                     SceneManager.LoadScene("1-4");
                    break;
                default:
                    print("失敗");
                    break;
            }
            
        }
    }
}
