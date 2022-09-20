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

    public void onClick(){
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Card");
        foreach(GameObject obj in allObjects) {
            Destroy(obj);
        }
        GameScreen.GetComponent<GameScreen>().NewRound();

        GameObject roundWinner= GameScreen.GetComponent<GameScreen>().getRoundWinner();
        if(roundWinner==player1){
            player1.GetComponent<GamePoints>().startAnim();
        }else if(roundWinner==player2){
            player2.GetComponent<GamePoints>().startAnim();
        }else{
            player1.GetComponent<GamePoints>().startAnim();
            player2.GetComponent<GamePoints>().startAnim();
        }

        GameScreen.GetComponent<GameScreen>().cleanPoints();


    }
}
