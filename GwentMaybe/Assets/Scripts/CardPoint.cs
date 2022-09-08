using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPoint : MonoBehaviour
{
    int value=0;
    //String type=null;
    public Text valueText;
    public Text typeText;
    // Start is called before the first frame update
    void Start()
    {
        valueText.text= value.ToString();
       // typeText.text= type;
    }

    // Update is called once per frame
    void Update()
    {
        draggable d = gameObject.GetComponent<draggable>();
        valueText.text = d.points.ToString();

        typeText.text = d.typeOfItem.ToString();
    }
}
