using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public CardScript.Slot typeOfItem = CardScript.Slot.RANGE;
    public int pointsTotal=0;
    
    public void OnDrop(PointerEventData eventData){
        Debug.Log ("OnDrop to" + gameObject.name);

        draggable d = eventData.pointerDrag.GetComponent<draggable>();
        CardScript cs = eventData.pointerDrag.GetComponent<CardScript>();
        if(d != null && typeOfItem == cs.getType() && d.transform.parent == this.transform.parent){
            if(typeOfItem == cs.getType() || typeOfItem== CardScript.Slot.INVENTORY){
                d.parentToReturn= this.transform;
            }    
        }
    }

    public void updatePoints(){
        bool hasDouble = false;
        int brotherCount = 0;
        pointsTotal=0;
        for(int i =0; i< this.transform.childCount; i++){
            if(this.transform.GetChild(i).tag == "Card"){
                GameObject child = this.transform.GetChild(i).gameObject;
                CardScript childScript = child.GetComponent<CardScript>();
                if(childScript.getIsSpecial())
                {
                    if(childScript.getSpecialType() == CardScript.SpecialCard.BROTHER)
                        brotherCount++;
                    else if(childScript.getSpecialType() == CardScript.SpecialCard.DOUBLE)
                        hasDouble = true;
                }
                pointsTotal+= childScript.getValue();
            }
        }
        if(hasDouble)
            pointsTotal *= 2;
        if(brotherCount > 1)
            pointsTotal += brotherCount-1;
    }
}
