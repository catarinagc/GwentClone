using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePoints : MonoBehaviour
{
    public int gamePoints =0;
    public int playerNumber=0;
    public Text gamePointsText;
    public string playerName;
    private bool nameChosen = false;
  //  GameObject textInputField;
    // Start is called before the first frame update
    void Start()
    {
        gamePointsText.text= gamePoints.ToString();
       // playerName = textInputField.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        gamePoints=0;
        for(int i=0; i<this.transform.childCount;i++){
            GameObject child = this.transform.GetChild(i).gameObject;
            if(child.name == "Tabletop" || child.name == "Tabletop (1)" || child.name == "Tabletop (2)"){
                SlotScore childScore = child.GetComponent<SlotScore>();
                gamePoints+= childScore.score;
            }
        }
        if(!nameChosen){
            gamePointsText.text= "Player " + playerNumber.ToString() + ": " +gamePoints.ToString();
        }else{
            gamePointsText.text= playerName + ": " +gamePoints.ToString();
        }
        
    }

    public void ReadNameInput(string name){
        playerName=name;
        nameChosen=true;
    }
}
