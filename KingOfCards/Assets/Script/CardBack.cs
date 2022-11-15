using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBack : MonoBehaviour
{
    //Codigo usado para colocar a carta virada para baixo.
    public GameObject cardBack;
    // Update is called once per frame
    void Update()
    {
        if (Display.staticCardBack == true) {
            cardBack.SetActive(true);
        } else {
            cardBack.SetActive(false);
        }
    }
}
