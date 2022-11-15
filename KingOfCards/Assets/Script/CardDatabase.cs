using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDatabase : MonoBehaviour
{
    //esse codigo deve estar dentro de um gameObject vazio.
    public static List<Card> cardList = new List<Card>();

     void Awake() {

        cardList.Add(new Card(0, "None",0,0,"None",Resources.Load<Sprite>("spartan") ));
        cardList.Add(new Card(1, "Human",2,1, "Human", Resources.Load<Sprite>("tophat") ));
        cardList.Add(new Card(2, "Elf",3,3, "Elf", Resources.Load<Sprite>("viking") ));
        cardList.Add(new Card(3, "Dwarf",4,4, "Dwarf", Resources.Load<Sprite>("ww1German") ));
        cardList.Add(new Card(4, "Troll",0,0, "Troll", Resources.Load<Sprite>("spartan") ));

     }
}
