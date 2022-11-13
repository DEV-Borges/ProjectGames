using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    [SerializeField]
    private Touch t;

    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        /*Precso saber quando o usuario vai estar tocando no item.*/

        if(Input.touchCount > 0 && Input.GetTouch(1).position == (Vector2)this.transform.position) {

                    Destroy(this.gameObject);
                
        }

    }
}
