using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private new string name;
    private int wins;
    private int curPoints;
    [SerializeField] private bool isPlayerOne;
    [SerializeField] private Text infoText;
    private bool nameChosen = false;
    private List<GameObject> fields;
    [SerializeField] private GameObject animation1;
    [SerializeField] private GameObject animation2;

// dont know if good to keep
    [SerializeField] private GameObject GameScreen;
    // Start is called before the first frame update
    void Start()
    {
        if(!nameChosen)
        {
            if(isPlayerOne)
                this.name = "Player1";
            else
                this.name = "Player2";      
        }
        
        this.wins = 0;
        this.curPoints = 0;
        fields = new List<GameObject>();

        AddPlayingField();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePoints();
        infoText.text = this.name + ": " + curPoints.ToString();
    }

    private void UpdatePoints()
    {
        curPoints = 0;
        for (int i = 0; i < fields.Count; i++)
        {
            if(fields[i].tag == ("Tabletop"))
            {
                SlotScore playingField = fields[i].GetComponent<SlotScore>();
                curPoints+= playingField.score;
            }
        }
    }

    public void RestartPoints()
    {
        for (int i = 0; i < fields.Count; i++)
        {
            if(fields[i].tag == ("Tabletop"))
            {
                SlotScore playingField = fields[i].GetComponent<SlotScore>();
                playingField.RestartPoints();
            }
        }
    }

//    neste momento o text field acede este método diretamente, TODO: procurar melhor forma
//    precisa do bool pois este metodo e chamado antes do start
    public void AddName(string name)
    {
        nameChosen = true;
        this.name = name;
    }

    // privado e fazer por tags??
    public void AddPlayingField()
    {
        for(int i=0; i<this.transform.childCount;i++){
            GameObject child = this.transform.GetChild(i).gameObject;
            if(child.tag==("Tabletop") || child.tag == ("Hand")){
                fields.Add(child);
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

    public void BlockCards(bool isPlaying)
    {
        for (int i = 0; i < fields.Count; i++)
        {
            GameObject field = fields[i];
            for ( int j = 0; j< field.transform.childCount; j++)
            {
                GameObject child = field.transform.GetChild(j).gameObject;
                if( child.tag == ("Card")){
                    child.GetComponent<CardPoint>().changeInPlay(isPlaying);
                }
            }
        }
    }

// TODO: ver se inutil
    public string getName()
    {
        return this.name;
    }

    public int getWins()
    {
        return this.wins;
    }

    public int getCurPoints()
    {
        return this.curPoints;
    }
}
