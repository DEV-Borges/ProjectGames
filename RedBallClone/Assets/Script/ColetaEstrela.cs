using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColetaEstrela : MonoBehaviour
{
    public Image barraMoedas;
    [SerializeField]
    private GameObject coletaSom;

    void Start() {
        barraMoedas = GameObject.FindWithTag("BarraTag").GetComponent<Image>();
        barraMoedas.fillAmount = 0;
        
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Moedas")) {
            GameManager.inst.Moedas--;
            Destroy(collision.gameObject);
            barraMoedas.fillAmount += 0.25f;
            Instantiate(coletaSom,transform.position,Quaternion.identity);
        }
    }
}
