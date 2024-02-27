using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPoint : MonoBehaviour
{
    [SerializeField] private Text valueText;
    [SerializeField] private Text typeText;
    [SerializeField] private Text specialText;
    private bool inPlay = true;

    // Start is called before the first frame update
    void Start()
    {
        CardScript cs = gameObject.GetComponent<CardScript>();
        valueText.text = cs.getValue().ToString();
        typeText.text = cs.getType().ToString();

        if(cs.getIsSpecial())
            specialText.text = cs.getSpecialType().ToString();
        else
            specialText.enabled = false;
    }

    public void changeInPlay(bool inPlay)
    {
        this.inPlay = inPlay;

        draggable d = gameObject.GetComponent<draggable>();
        if(!inPlay)
        {
            d.enabled = false;
            if(this.transform.parent.gameObject.tag == "Hand" )
            {
                valueText.enabled = false;
                typeText.enabled = false;
                specialText.enabled = false;
            }
        }
        else
        {
            d.enabled = true;
            if(this.transform.parent.gameObject.tag == "Hand" )
            {
                valueText.enabled = true;
                typeText.enabled = true;
                if(this.GetComponent<CardScript>().getIsSpecial())
                    specialText.enabled = true;
            }
        }
    }
}
