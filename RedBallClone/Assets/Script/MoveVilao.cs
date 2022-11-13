using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVilao : MonoBehaviour
{
    public float periodoRotacao; //tempo de rotação.
    public float compLateral = 1; //comprimento lateral do inimigo.
    public bool estaRotacionando = false; // verifica se o objeto esta girando/rotacionando.
    public float direcaoX = 0;//Pegando a direção do objeto.

    public Vector3 inicioPos;// posição inicial da posição do personagem.
    public float tempoRotacao;//Lapso de tempo durante a rotação
    public float raio;//Raio de tragetoria do centro de gravidade.
    public Quaternion fRotacao;
    public Quaternion tRotacao;

    public float x;


    // Start is called before the first frame update
    void Start()
    {
        raio = compLateral * Mathf.Sqrt(2f) / 2f;//calculando o raio.
        x = 1;
    }

    // Update is called once per frame
    void Update()
    {
        #region 
        /*x = 0;//eixo
        y = 0;//eixo

        x = Input.GetAxisRaw("Horizontal");
        if (x == 0) {
            y = Input.GetAxisRaw("Vertical");
        }*/
        #endregion

        //Caso o inimigo esteja não rotacionando.
        if (( x != 0) && !estaRotacionando) {
            direcaoX = x;
            inicioPos = transform.position;
            fRotacao = transform.rotation;//Recendendo o primeiro valor da rotação.
            transform.Rotate(0,0, direcaoX * 90, Space.World);//Alterando a rotação inicial.
            tRotacao = transform.rotation;//guardando a rotação alterada.
            transform.rotation = fRotacao;//dando o valor inicial da rotação.
            tempoRotacao = 0;
            estaRotacionando = true;
        }

    }

    void FixedUpdate() {

        if (estaRotacionando) {

            tempoRotacao += Time.fixedDeltaTime;
            float fatorRatio = Mathf.Lerp(0,1,tempoRotacao / periodoRotacao);

            float theta = Mathf.Lerp(0,Mathf.PI / 2, fatorRatio);
            float distX = -direcaoX * raio * (Mathf.Cos(45f * Mathf.Deg2Rad) - Mathf.Cos(45f * Mathf.Deg2Rad + theta));
            float distY = raio * (Mathf.Sin(45f * Mathf.Deg2Rad + theta) - Mathf.Sign(45f * Mathf.Deg2Rad));

            transform.position = new Vector3 (inicioPos.x + distX, inicioPos.y + distY, 0);
            transform.rotation = Quaternion.Lerp(fRotacao,tRotacao, fatorRatio);

            if (fatorRatio == 1 ) {

                estaRotacionando = false;
                direcaoX = 0;
                tempoRotacao = 0;
            }


        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            x *= -1;
        }    
    }

}
