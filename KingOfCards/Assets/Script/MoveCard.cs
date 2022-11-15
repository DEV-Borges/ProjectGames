using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform parentToReturnTo = null;
    public GameObject panel;

    public void OnBeginDrag(PointerEventData eventData) {
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData) {
        this.transform.position = eventData.position;   
    }
    public void OnEndDrag(PointerEventData eventData) {
        
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (this.transform.parent == panel.transform.parent) {

            this.transform.SetParent(panel.transform.parent);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
