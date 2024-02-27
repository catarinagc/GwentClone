using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public enum Slot{ RANGE, CLOSE, SIEGE, INVENTORY };
    public enum SpecialCard{ DOUBLE, BROTHER};
    [SerializeField] private bool isSpecial = false;
    [SerializeField] private int value;
    [SerializeField] private Slot type;
    [SerializeField] private SpecialCard specialType;
    // Start is called before the first frame update
    void Start()
    {
        int specialCard = Random.Range(0,10);
        if(specialCard == 0)
        {
            isSpecial = true;
            specialType = (SpecialCard)Random.Range(0, 2);
        }
        type = (Slot)Random.Range(0, Slot.GetNames(typeof(Slot)).Length -1);
        value = Random.Range(1,11);
    }
    
    public int getValue()
    {
        return value;
    }

    public Slot getType()
    {
        return type;
    }

    public bool getIsSpecial()
    {
        return isSpecial;
    }

    public SpecialCard getSpecialType()
    {
        return specialType;
    }

}
