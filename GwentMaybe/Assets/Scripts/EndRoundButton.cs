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
    public GameObject cards;

    public void onClick(){
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Card");
        foreach(GameObject obj in allObjects) {
            Destroy(obj);
        }
        GameScreen.GetComponent<GameScreen>().NewRound();
        GameScreen.GetComponent<GameScreen>().cleanPoints();
    }
}
