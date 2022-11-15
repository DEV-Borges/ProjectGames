using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MoveCards : MonoBehaviour
{
   

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {

        //    //Linha de codigo de exclusão do item.
        //    Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
        //    RaycastHit hit;
        //    //Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
        //    //essa condição ira acontecer quando um raio entrar e atingir o objeto.
        //    if (Physics.Raycast(ray, out hit)) {
        //        if (hit.transform.tag == "Player") {
        //            Instantiate(this.gameObject, inicio.transform.localPosition, Quaternion.identity);
        //            GameObject temp = hit.transform.gameObject;                       
        //            Destroy(temp);
        //        }

        //    }
        //}
        
    }
}
