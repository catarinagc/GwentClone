using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject gameScreen;

    private void OnClick(){
        startScreen.SetActive(false);
        gameScreen.SetActive(true);
        gameObject.GetComponent<StopMusic>().changeMusic();
    }

}
