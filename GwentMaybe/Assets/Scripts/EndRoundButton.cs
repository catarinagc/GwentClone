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
    private bool firstPlayer = true;

    public void onClick(){
        if(firstPlayer){
            GameScreen.GetComponent<GameScreen>().ChangeCurPlayer();
            firstPlayer = false;
            return;
        }
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Card");
        foreach(GameObject obj in allObjects) {
            Destroy(obj);
        }
        GameScreen.GetComponent<GameScreen>().NewRound();

        GameObject roundWinner= GameScreen.GetComponent<GameScreen>().getRoundWinner();
        if(roundWinner==player1){
            player1.GetComponent<Player>().startAnim();
        }else if(roundWinner==player2){
            player2.GetComponent<Player>().startAnim();
        }else{
            player1.GetComponent<Player>().startAnim();
            player2.GetComponent<Player>().startAnim();
        }

        GameScreen.GetComponent<GameScreen>().cleanPoints();

        firstPlayer = true;
        GameScreen.GetComponent<GameScreen>().DrawCards();
        GameScreen.GetComponent<GameScreen>().ChangeCurPlayer();
    }
}
