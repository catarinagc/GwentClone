using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject cards;
    public GameObject playerArea;
    public enum Slot{ RANGE, CLOSE, SIEGE, INVENTORY };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnClick(){
        for (int i=0; i<5; i++){
            GameObject playerCard = Instantiate(cards);
            playerCard.GetComponent<draggable>().points = Random.Range(1,11);
            playerCard.GetComponent<draggable>().randomType();
            playerCard.transform.SetParent(playerArea.transform);
        }
    }
}
