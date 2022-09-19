using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndRoundButton : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject GameScreen;
   // public GameObject cards;
    public GameObject Player1Point1;
    public GameObject Player1Point2;

    public GameObject Player2Point1;
    public GameObject Player2Point2;

    public void onClick(){
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Card");
        foreach(GameObject obj in allObjects) {
            Destroy(obj);
        }
        GameScreen.GetComponent<GameScreen>().NewRound();

        GameObject roundWinner=  GameScreen.GetComponent<GameScreen>().getRoundWinner();
        if(roundWinner==player1){
            int points=  GameScreen.GetComponent<GameScreen>().player1Wins;
            if(points == 1){
                Player1Point1.GetComponent<TriggerAnimation>().OnTriggerStart();
             }
        }else if(roundWinner==player2){
            int points=  GameScreen.GetComponent<GameScreen>().player2Wins;
            if(points == 1){
                Player2Point1.GetComponent<TriggerAnimation>().OnTriggerStart();
             }
        }else{
            int points1=  GameScreen.GetComponent<GameScreen>().player1Wins;
            int points2=  GameScreen.GetComponent<GameScreen>().player2Wins;
            if(points1 == 1){
                Player1Point1.GetComponent<TriggerAnimation>().OnTriggerStart();
            }
            if(points2 == 1){
                Player2Point1.GetComponent<TriggerAnimation>().OnTriggerStart();
            }
            if(points1 == 2){
                Player1Point2.GetComponent<TriggerAnimation>().OnTriggerStart();
             }
             if(points2 == 2){
                Player2Point2.GetComponent<TriggerAnimation>().OnTriggerStart();
             }
        }

        GameScreen.GetComponent<GameScreen>().cleanPoints();


    }
}
