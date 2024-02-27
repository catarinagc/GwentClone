using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject endScreen;
    public GameObject player1;
    public GameObject player2;
    public GameObject Screen;

    public void OnClick(){
        if(Screen.GetComponent<GameScreen>().hasGameFinished()){
            GameObject winner = Screen.GetComponent<GameScreen>().gameWinner();
             endScreen.GetComponent<GameOverScreen>().Setup(winner);
             return;
        }
        endScreen.GetComponent<GameOverScreen>().Setup(null);       
    }
}
