using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    //talvez retirar rounds
    public GameObject player1;
    public GameObject player2;
    private int player1Wins=0;
    private int player2Wins=0;
    private int roundNumber=1;
    public GameObject endGameButton;
    //private GameObject roundWinnerPlayer;

    public void NewRound(){
        roundWinner();
        if(hasGameFinished()){
            endGame();
            return;
        }
        //roundNumber++;

    }

    public void endGame(){
        //roundWinner();
        endGameButton.GetComponent<EndGame>().OnClick();
    }

    public void roundWinner(){
        int player1Points = player1.GetComponent<GamePoints>().gamePoints;
        int player2Points = player2.GetComponent<GamePoints>().gamePoints;
        if(player1Points>player2Points){
            player1Wins++;
        }else if(player1Points<player2Points){
            player2Wins++;
        }else{
            player1Wins++;
            player2Wins++;
        }
    }

    public GameObject gameWinner(){
        GameObject finalWinner;
        if(player1Wins>player2Wins){
            finalWinner= player1;
        }else if(player1Wins<player2Wins){
            finalWinner= player2;
        } else{
            finalWinner= null;
        }
        return finalWinner;
    }

    public bool hasGameFinished(){
        if(player1Wins== 2 || player2Wins==2){
            return true;
        } else{
            return false;
        }
    }

    public void cleanPoints(){
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Tabletop");
        foreach(GameObject obj in allObjects) {
            obj.GetComponent<SlotScore>().score =0;
        }
        player1.GetComponent<GamePoints>().RestartPoints();
        player2.GetComponent<GamePoints>().RestartPoints();
    }
   
}
