using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TurnSystem : MonoBehaviour
{
    public bool isYouTurn;
    public int yourTurn;
    public int IsOpponentTurn;
    public Text turntext;

    public int maxMana;
    public int currentmana;
    public Text manaText;

    public static bool startTurn;


    // Start is called before the first frame update
    void Start()
    {
        isYouTurn = true;
        yourTurn = 1;
        IsOpponentTurn = 0;

        maxMana = 100;
        currentmana = 100;

        startTurn = false;



    }

    // Update is called once per frame
    void Update()
    {
        if (isYouTurn == true) {

            turntext.text = "Your Turn";

        } else {
            turntext.text = "Opponent turn";
        }

        manaText.text = currentmana + "/" + maxMana;

        
    }

    public void EndYourTurn() {

        isYouTurn = false;
        IsOpponentTurn -= 1;
        currentmana -= 1;

    }

    public void EndOpponentTurn() {

        isYouTurn = true;
        yourTurn += 1;
        currentmana += 1;

        startTurn = true;
    }
}
