using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject endScreen;
    public GameObject player1;
    public GameObject player2;

    public void OnClick(){
        
        int player1Points = player1.GetComponent<GamePoints>().gamePoints;
        int player2Points = player2.GetComponent<GamePoints>().gamePoints;

        if(player1Points > player2Points){
            endScreen.GetComponent<GameOverScreen>().Setup(1);
        } else if(player1Points < player2Points){
            endScreen.GetComponent<GameOverScreen>().Setup(2);
        } else{
            endScreen.GetComponent<GameOverScreen>().Setup(0);
        }
        
    }
}
