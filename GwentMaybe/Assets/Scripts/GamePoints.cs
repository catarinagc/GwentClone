using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//inutil TODO: delete
public class GamePoints : MonoBehaviour
{
    public int gamePoints =0;
    public int playerNumber=0;
    public string playerName;
    private bool nameChosen = false;
    [SerializeField] private Text gamePointsText;
    [SerializeField] private GameObject GameScreen;
    [SerializeField] private GameObject animation1;
    [SerializeField] private GameObject animation2;
    
    // Start is called before the first frame update
    void Start()
    {
        if(!nameChosen){
            playerName= "Player"+ playerNumber.ToString();
        }
        gamePointsText.text= gamePoints.ToString();
    }

    // Update is called once per frame
/*     void Update()
    {
        gamePoints=0;
        for(int i=0; i<this.transform.childCount;i++){
            GameObject child = this.transform.GetChild(i).gameObject;
            if(child.tag==("Tabletop")){
                SlotScore childScore = child.GetComponent<SlotScore>();
                gamePoints+= childScore.score;
            }
        }
        //gamePointsText.text= playerName + ": " +gamePoints.ToString();
    } */

    public void ReadNameInput(string name){
        playerName=name;
        nameChosen=true;
    }

    public void RestartPoints(){
        for(int i=0; i<this.transform.childCount;i++){
            GameObject child = this.transform.GetChild(i).gameObject;
            if(child.name == "Tabletop" || child.name == "Tabletop (1)" || child.name == "Tabletop (2)"){
                SlotScore childScore = child.GetComponent<SlotScore>();
                childScore.RestartPoints();
                gamePoints+= childScore.score;
            }
        }
    }

    public void startAnim(){
        int points=GameScreen.GetComponent<GameScreen>().getPlayerWins(this.gameObject);
        if(points==1){
            animation1.GetComponent<TriggerAnimation>().OnTriggerStart();
        } else{
            animation2.GetComponent<TriggerAnimation>().OnTriggerStart();
        }
    }
}
