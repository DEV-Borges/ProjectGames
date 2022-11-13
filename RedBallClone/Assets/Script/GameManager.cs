using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;
    public int vida;
    public Image[] imgCoracao;
    public int Moedas;

    public Transform nasc;
    public GameObject redB;
    public CinemachineVirtualCamera cam;

    void Awake() {
        if (inst == null) {
            inst = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(inst);
        }
    }
    void Start()
    {
        vida = 3;
        Moedas = 4;
    }

    
    void Update()
    {
        if (vida <= 0) {
            GameObject newRed = Instantiate(redB,nasc.position, Quaternion.identity);
            for (int i = 0; i < imgCoracao.Length; i++) {
                imgCoracao[i].enabled = true;
            }
            cam.m_Follow = newRed.transform;
            vida = 3;
        }
    }
}
