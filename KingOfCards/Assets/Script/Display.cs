using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Display : MonoBehaviour
{
    public List<Card> DisplayCard = new List<Card>();
    public int displayId;

    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;
    public Sprite spriteImage;

    public Text nameText;
    public Text costText;
    public Text powerText;
    public Text descriptionText;
    public Image artImage;

    public bool cardBack;
    public static bool staticCardBack;

    public GameObject hand;
    public int numberOfCardsIndeck;


    // Start is called before the first frame update
    void Start() {

        numberOfCardsIndeck = Playerdeck.deckSize;
        //colocando a list cardList de cardDatabase dentro de DisplayCard.
        DisplayCard[0] = CardDatabase.cardList[displayId];
        

    }

        
    // Update is called once per frame
    void Update()
    {
        //Pegando o valor da lista de cada item e colocando dentro das respectivas variaveis.
        id = DisplayCard[0].id;
        cardName = DisplayCard[0].cardName;
        cost = DisplayCard[0].cost;
        power = DisplayCard[0].power;
        cardDescription = DisplayCard[0].cardDescription;
        spriteImage = DisplayCard[0].spriteImage;

        //Adicionando os valores nas UI.
        nameText.text = "" + cardName;
        costText.text = "" + cost;
        powerText.text = "" + power;
        descriptionText.text = "" + cardDescription;
        artImage.sprite = spriteImage;

        //pegando o gameObject com a tag Hand e atribuindo na variavel hand. Logo depois verificando se a posição do gameObject é igual a posição de hand e colocando false em cardBack.
        hand = GameObject.Find("Hand");
        if (this.transform.parent == hand.transform.parent) {
            cardBack = false;
        }

        staticCardBack = cardBack;

        //Caso o gameObject estiver com a tag "Clone" será executado essa condição.
        if (this.tag == "Clone") {

            DisplayCard[0] = Playerdeck.staticDeck[numberOfCardsIndeck - 1];
            numberOfCardsIndeck -= 1;
            Playerdeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";
        }

    }
}
