using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform parentToReturn = null;
    public int points;
    public enum Slot{ RANGE, CLOSE, SIEGE, INVENTORY };
    public Slot typeOfItem = Slot.INVENTORY;

    public void OnBeginDrag(PointerEventData eventData) {
        parentToReturn = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
   }

    public void OnDrag(PointerEventData eventData) {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData){
        this.transform.SetParent(parentToReturn);

        GetComponent<CanvasGroup>().blocksRaycasts = true;
        //UpdateSize();
        this.transform.parent.gameObject.GetComponent<DropZone>().updatePoints();
    }

    public void randomType(){
        typeOfItem= (Slot)Random.Range(0,3);
    }

    public void UpdateSize(){
       this.transform.localScale = new Vector3(this.transform.localScale.y*0.7f,0.7f,1);
    }
}
