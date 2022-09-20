using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Text winnerText;
    [SerializeField] private GameObject gameScreen;

    public void Setup(GameObject player) {
        gameObject.SetActive(true);
        if(player == null && !gameScreen.GetComponent<GameScreen>().hasGameFinished()){
            winnerText.text= "Game not finished";
            return;
        } else if(player == null){
            winnerText.text= "Draw!";
            return;
        }
        winnerText.text = player.GetComponent<GamePoints>().playerName + " wins!";    
    }

    public void RestartGame(){
        SceneManager.LoadScene(0);
    }
}
