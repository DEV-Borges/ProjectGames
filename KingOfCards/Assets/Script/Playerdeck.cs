using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerdeck : MonoBehaviour
{
    public static Playerdeck instance;

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    public GameObject cardToHand;
    public GameObject[] Clones;
    public GameObject hand;

    public List<Card> container = new List<Card>();
    
    public static int deckSize;
    public int x;
    public List<Card> deck = new List<Card>();
    public static List<Card> staticDeck = new List<Card>();

    

    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        deckSize = 40;

        for (int i = 0; i < 40 ; i++) {
            x = Random.Range(1,4);
            deck[i] = CardDatabase.cardList[x];
        
        }
        StartCoroutine(StartGame());

    }

    // Update is called once per frame
    void Update()
    {
        staticDeck = deck;

        if  (deckSize < 30) {
            cardInDeck1.SetActive(false);
        }if (deckSize < 20) {
            cardInDeck2.SetActive(false);
        }if (deckSize < 5) {
            cardInDeck3.SetActive(false);
        }if (deckSize < 1) {
            cardInDeck4.SetActive(false);
        }
        if (TurnSystem.startTurn == true) {
            StartCoroutine(Draw(1));
            TurnSystem.startTurn = false;
        }

    }

    IEnumerator StartGame() {
        for (int i = 0; i <= 4; i++) {
            yield return new WaitForSeconds(1f);

            //audioSource.PlayOneShot(SpriteDrawMode, 1f);
            Instantiate(cardToHand, transform.position,transform.rotation);
        }
    }

    public void Shuffle() {
        
        for (int i = 0; i < deckSize; i++) {

            container[0] = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];

        }
    }

    IEnumerator Draw(int x) {
        for (int i = 0; i < x; i++) {
            yield return new WaitForSeconds(1);
            Instantiate(cardToHand, transform.position, transform.rotation);
        }
    }

}
