using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject cards1;
    public GameObject cards2;
    public GameObject playerArea1;
    public GameObject playerArea2;
    public enum Slot{ RANGE, CLOSE, SIEGE, INVENTORY };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnClick(){
        for (int i=0; i<5; i++){
            GameObject playerCard1 = Instantiate(cards1);
            GameObject playerCard2 = Instantiate(cards2);

            playerCard1.GetComponent<draggable>().points = Random.Range(1,11);
            playerCard2.GetComponent<draggable>().points = Random.Range(1,11);

            playerCard1.GetComponent<draggable>().randomType();
            playerCard2.GetComponent<draggable>().randomType();

            playerCard1.transform.SetParent(playerArea1.transform);
            playerCard2.transform.SetParent(playerArea2.transform);

            playerCard1.GetComponent<draggable>().UpdateSize();
            playerCard2.GetComponent<draggable>().UpdateSize();
        }
    }
}
