using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePoints : MonoBehaviour
{
    int gamePoints =0;
    public Text gamePointsText;
    
    // Start is called before the first frame update
    void Start()
    {
        gamePointsText.text= gamePoints.ToString();
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
        gamePointsText.text= gamePoints.ToString();
    }
}
