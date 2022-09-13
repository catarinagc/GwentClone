using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startScreen;
    public GameObject gameScreen;
    public void OnClick(){
        startScreen.SetActive(false);
        gameScreen.SetActive(true);
       // SceneManager.LoadScene(0);
    }
}
