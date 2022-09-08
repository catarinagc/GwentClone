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
        Debug.Log ("OnBeginDrag");

        parentToReturn = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
   }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log ("OnDrag");
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData){
        Debug.Log ("OnEndDrag");
        this.transform.SetParent(parentToReturn);

        GetComponent<CanvasGroup>().blocksRaycasts = true;

        this.transform.parent.gameObject.GetComponent<DropZone>().updatePoints();
    }

    public void randomType(){
        typeOfItem= (Slot)Random.Range(0,3);
    }
}
