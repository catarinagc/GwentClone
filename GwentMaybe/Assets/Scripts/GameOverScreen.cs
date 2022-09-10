using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text winnerText;

    public void Setup(int playerWinner) {
        gameObject.SetActive(true);
        if(playerWinner==0){
             winnerText.text = "Draw";
        } else{
            winnerText.text = "Player " + playerWinner.ToString() + " wins";
        }
    
    }

    public void RestartGame(){
        SceneManager.LoadScene(0);
    }
}
