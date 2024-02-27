using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    [SerializeField] private GameObject cards1;
    [SerializeField] private GameObject cards2;
    [SerializeField] private GameObject playerArea1;
    [SerializeField] private GameObject playerArea2;

    // Update is called once per frame
    public void OnClick(){
        for (int i=0; i<5; i++){
            GameObject playerCard1 = Instantiate(cards1);
            GameObject playerCard2 = Instantiate(cards2);

            playerCard1.transform.SetParent(playerArea1.transform);
            playerCard2.transform.SetParent(playerArea2.transform);
        }
    }
}
