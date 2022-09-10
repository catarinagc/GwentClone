using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public draggable.Slot typeOfItem = draggable.Slot.RANGE;
    public int pointsTotal=0;
    
    public void OnDrop(PointerEventData eventData){
        Debug.Log ("OnDrop to" + gameObject.name);

        draggable d = eventData.pointerDrag.GetComponent<draggable>();
        if(d != null && typeOfItem == d.typeOfItem && d.transform.parent == this.transform.parent){
            if(typeOfItem == d.typeOfItem || typeOfItem== draggable.Slot.INVENTORY){
                d.parentToReturn= this.transform;
            }    
        }   
    }

    public void updatePoints(){
        pointsTotal=0;
        for(int i =1; i< this.transform.childCount; i++){
            GameObject child = this.transform.GetChild(i).gameObject;
            draggable childDrag = child.GetComponent<draggable>();
            pointsTotal+= childDrag.points;
        }
    }
}
