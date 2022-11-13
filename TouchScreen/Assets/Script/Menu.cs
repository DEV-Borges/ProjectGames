using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    [SerializeField]
    private Button btn;

    void Start()
    {
        btn = GameObject.Find("Start").GetComponent<Button>();
        btn.onClick.AddListener(ClickLvl);
    }

    public void ClickLvl()
    {
        SceneManager.LoadScene(1);
    }
}
