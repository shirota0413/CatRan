using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour {

    void LoadScene() {
        SceneManager.LoadScene("1-1");
    }
    // Start is called before the first frame update
    void Start() {
        Invoke("LoadScene",3.0f);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
