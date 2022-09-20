using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    private int player1Wins=0;
    private int player2Wins=0;
    private GameObject roundWinnerPlayer;
    [SerializeField] private GameObject endGameButton;

    public void NewRound(){
        roundWinner();
        if(hasGameFinished()){
            endGame();
        }
    }

    public void endGame(){
        endGameButton.GetComponent<EndGame>().OnClick();
    }

    public void roundWinner(){
        int player1Points = player1.GetComponent<GamePoints>().gamePoints;
        int player2Points = player2.GetComponent<GamePoints>().gamePoints;
        int compare = player1Points.CompareTo(player2Points);
        if(compare==1){
            player1Wins++;
            roundWinnerPlayer=player1;
        }else if(compare==-1){
            player2Wins++;
            roundWinnerPlayer=player2;
        }else{
            player1Wins++;
            player2Wins++;
            roundWinnerPlayer=null;
        }
    }

    public GameObject gameWinner(){
        GameObject finalWinner;
        int compare=player1Wins.CompareTo(player2Wins);
        if(compare==1){
            finalWinner= player1;
        }else if(compare==-1){
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
   
    public GameObject getRoundWinner(){
        return roundWinnerPlayer;
    }

    public int getPlayerWins(GameObject player){
        if(player == player1){
            return player1Wins;
        }else{
            return player2Wins;
        }
    }
}
