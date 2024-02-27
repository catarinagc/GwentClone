using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    private int player1Wins=0;
    private int player2Wins=0;
    private GameObject roundWinnerPlayer;
    [SerializeField] private GameObject endGameButton;
    private GameObject curPlayer;
    [SerializeField] private GameObject cardButton;
    [SerializeField] private GameObject confirmScreen;
    [SerializeField] private Text confirmText;
    void Start()
    {
        DrawCards();
        InitializeGame();
    }

    public void InitializeGame()
    {
        int rInt = Random.Range(0, 2);

        if (rInt == 0)
            curPlayer = player1;
        else
            curPlayer = player2;
        
        prepareConfirmScreen();
    }

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
        int player1Points = player1.GetComponent<Player>().getCurPoints();
        int player2Points = player2.GetComponent<Player>().getCurPoints();
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

    public void DrawCards()
    {
        cardButton.GetComponent<DrawCards>().OnClick();
        player2.GetComponent<Player>().BlockCards(false);
        player1.GetComponent<Player>().BlockCards(false);
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
        player1.GetComponent<Player>().RestartPoints();
        player2.GetComponent<Player>().RestartPoints();
    }
   
    public GameObject getRoundWinner(){
        return roundWinnerPlayer;
    }

    public int getPlayerWins(GameObject player){
        if(player == player1)
            return player1Wins;
        else
            return player2Wins;
    }

    public void ChangeCurPlayer()
    {
        curPlayer.GetComponent<Player>().BlockCards(false);

        if(curPlayer == player1)
            curPlayer = player2;
        else
            curPlayer = player1;
    
        if(!hasGameFinished()){
            prepareConfirmScreen();
        }
    }

    public GameObject getCurPlayer()
    {
        return curPlayer;
    }

    private void prepareConfirmScreen()
    {
        confirmScreen.SetActive(true);
        confirmText.text = "Ready " + curPlayer.GetComponent<Player>().getName() + "?";
    }
}
