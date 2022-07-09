using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventReceiver : MonoBehaviour, IPointerClickHandler
   
{
    public GameObject obj;
    public void Awake()
    {
        obj = GameObject.Find("Plane");
    }
  /*  public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("DEBUG - Begin Drag");
        obj.GetComponent<Map>().NodeHandlerOnBeginDrag(this.gameObject);
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("DEBUG - OnDrag");
        obj.GetComponent<Map>().NodeHandlerOnDrag(this.gameObject);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("DEBUG - End Drag");
        obj.GetComponent<Map>().NodeHandlerOnEndDrag(this.gameObject);
    }*/
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("DEBUG - Click");
        obj.GetComponent<Map>().SelectedBuildingRemoveTracker(this.gameObject.name);
        obj.GetComponent<Map>().NodeHandlerOnClick(this.gameObject);
    }

}
