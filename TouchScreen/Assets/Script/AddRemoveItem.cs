using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class AddRemoveItem : MonoBehaviour
{
    //lista de sprites, add a variavel sprites todos os sprites que incluirmos no jogo..
    //public List<Sprite> sprites = new List<Sprite>();
    // Update is called once per frame
    public TextMeshPro crownUi, hotdogUi, sharkUi, takuhatsuUi;
    public int v1=4, v2=4, v3=4, v4=4;
    void Start() {
        #region Pegando ao text e dando valor a elas.

        crownUi = GameObject.Find("crown").GetComponent<TextMeshPro>();
        hotdogUi = GameObject.Find("hotdog").GetComponent<TextMeshPro>();
        sharkUi = GameObject.Find("shark").GetComponent<TextMeshPro>();
        takuhatsuUi = GameObject.Find("takuhatsu").GetComponent<TextMeshPro>();

        crownUi.text = v1.ToString();
        hotdogUi.text = v2.ToString();
        sharkUi.text = v3.ToString();
        takuhatsuUi.text = v4.ToString();

        #endregion
    }
    void Update()
    {
        #region Condição para ser removido o item quando tocado.
        if (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began) {
           
            //Linha de codigo de exclusão do item.
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            //Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
            //essa condição ira acontecer quando um raio entrar e atingir o objeto.
            if (Physics.Raycast(ray , out hit)) {
                if (hit.transform.tag == "crown") {
                    GameObject temp = hit.transform.gameObject;
                    Destroy(temp);
                    DecreaseCrown(1);
                    
                }else if (hit.transform.tag == "hotdog") {
                    GameObject temp = hit.transform.gameObject;
                    Destroy(temp);
                    DecreaseHotDog(1);

                }else if (hit.transform.tag =="shark") {
                    GameObject temp = hit.transform.gameObject;
                    Destroy(temp);
                    DecreaseShark(1);

                }else if (hit.transform.tag == "takuhatsu") {
                    GameObject temp = hit.transform.gameObject;
                    Destroy(temp);
                    DecreaseTakuhatsu(1);

                }
            } /*else {

                Touch mytouch = Input.GetTouch(0);
                AddItem(mytouch);

            }*/
        }
        #endregion

        if (v1 == 0 && v2 == 0 && v3 == 0 && v4 == 0) {
            SceneManager.LoadScene(2);
        }
    }
    /*private void AddItem(Touch TouchPos) {

        Vector3 objPos = Camera.main.ScreenToViewportPoint(TouchPos.position);
        objPos.z = 0;

        objeto.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count)];
        Instantiate(objeto, objPos, Quaternion.identity);
    }*/

    #region metodos de diminuir os itens encontrados.
    void DecreaseCrown(int x) {
        v1 -= x;
        crownUi.text = v1.ToString();
    }
    void DecreaseHotDog(int x) {
        v2 -= x;
        hotdogUi.text = v2.ToString();
    }
    void DecreaseShark(int x) {
        v3 -= x;
        sharkUi.text = v3.ToString();
    }
    void DecreaseTakuhatsu(int x) {
        v4 -= x;
        takuhatsuUi.text = v4.ToString();
    }
    #endregion

}
