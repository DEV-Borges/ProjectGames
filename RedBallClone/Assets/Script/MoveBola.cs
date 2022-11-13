using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class MoveBola : MonoBehaviour
{
    public Rigidbody2D rb;
    public float vel;
    public float forcaPulo;
    public bool noChao;
    public float raio;
    public LayerMask layer;
    public ConstantForce2D constantForce2;
    [SerializeField]
    private AudioSource Jump;

    private bool moveDir, moveEsq;

    [SerializeField]
    private EventTrigger eventTriggerPulo, eventTriggerDireita, eventTriggerEsquerda;
    [SerializeField]
    private EventTriggerType tipoPulo, tipoDireita, tipoEsquerda;
    [SerializeField]
    private EventTrigger.Entry entryPulo, entryDireitaD, entryDireitaU, entryEsquerdaD, entryEsquerdaU;
    [SerializeField]
    private Image btnPulo,btnDir,btnEsq;

    void Awake() {
        btnPulo = GameObject.FindWithTag("joyP").GetComponent<Image>();
        btnDir = GameObject.FindWithTag("joyD").GetComponent<Image>();
        btnEsq = GameObject.FindWithTag("joyE").GetComponent<Image>();

        eventTriggerPulo = btnPulo.GetComponent<EventTrigger>();
        eventTriggerDireita = btnDir.GetComponent<EventTrigger>();
        eventTriggerEsquerda = btnEsq.GetComponent<EventTrigger>();


    }

    // Start is called before the first frame update
    void Start()
    {
        AjustaJoyDown(tipoPulo,entryPulo);
        entryPulo.callback.AddListener((data) => {PuloJoy((PointerEventData)data); });

        AjustaJoyDown(tipoDireita, entryDireitaD);
        entryDireitaD.callback.AddListener((data) => { MoveDir((PointerEventData)data); });

        AjustaJoyUp(tipoDireita, entryDireitaU);
        entryDireitaU.callback.AddListener((data) => { MoveDirPara((PointerEventData)data); });

        AjustaJoyDown(tipoEsquerda, entryEsquerdaD);
        entryEsquerdaD.callback.AddListener((data) => { MoveEsq((PointerEventData)data); });

        AjustaJoyUp(tipoEsquerda, entryEsquerdaU);
        entryEsquerdaU.callback.AddListener((data) => { MoveEsqPara((PointerEventData)data); });

        GatilhosBtn(eventTriggerPulo, entryPulo);
        GatilhosBtn(eventTriggerDireita, entryDireitaD);
        GatilhosBtn(eventTriggerDireita, entryDireitaU);
        GatilhosBtn(eventTriggerEsquerda, entryEsquerdaD);
        GatilhosBtn(eventTriggerEsquerda, entryEsquerdaU);

    }

    void AjustaJoyDown(EventTriggerType tipo, EventTrigger.Entry entry) {

        tipo = EventTriggerType.PointerDown;
        entry.eventID = tipo;
    }

    void AjustaJoyUp(EventTriggerType tipo, EventTrigger.Entry entry) {

        tipo = EventTriggerType.PointerUp;
        entry.eventID = tipo;
    }

    void GatilhosBtn(EventTrigger eventTrigger, EventTrigger.Entry entry) {

        eventTrigger.triggers.Add(entry);
    }

    // Update is called once per frame
    void Update()
    {
        //Verificando se o objeto esta colidindo com o layer definido. Passando como parametro a posicao do objeto, raio e o layer definido..
        noChao = Physics2D.OverlapCircle(transform.position, raio, layer);//Trás true se colidir e false caso nao esteja colidino com o layer.


        //Caso a tecla space seja precionada e variavel noChao seja true, será aplicado uma forca de pulo no objeto.
        if (noChao && Input.GetKeyDown(KeyCode.Space)) {
            rb.velocity = new Vector2(rb.velocity.x,(rb.velocity.y + 1 ) * forcaPulo);
            if (!Jump.isPlaying) {
                Jump.Play();
            }
        }
    }
    //É executado em um intervalo em tempo fisico.
    void FixedUpdate() {

        if (rb != null) {
            AplicaForca(Input.GetAxis("Horizontal"));
        }
        if (moveDir) {
            AplicaForca(1);
        }if (moveEsq) {
            AplicaForca(-1);
        }
    }
    //Metodos.
    public void PuloJoy( PointerEventData data) {

        if (noChao) {
            rb.velocity = new Vector2(rb.velocity.x, (rb.velocity.y + 1) * forcaPulo);
            if (!Jump.isPlaying) {
                Jump.Play();
            }
        }
    }
    public void MoveDir(PointerEventData data) {
        moveDir = true;
    }
    public void MoveDirPara(PointerEventData data) {
        moveDir = false;
    }
    public void MoveEsq(PointerEventData data) {
        moveEsq = true;
    }
    public void MoveEsqPara(PointerEventData data) {
        moveEsq = false;
    }
    public void AplicaForca(float valor) {

        float yVel = rb.velocity.y;
        float xInput = valor;
        float xForca = xInput * vel * Time.deltaTime;


        if (xInput != 0) {
            Vector2 forca = new Vector2(xForca, 0);
            rb.AddForce(forca, ForceMode2D.Force);
        }
        
        if (noChao) {
            //Se estiver no chão sera executado essa condição.
            if (xInput > 0) {
                constantForce2.torque = -1;
            }else if (xInput < 0) {
                constantForce2.torque = 1;
            }else {
                constantForce2.torque = 0;
            }

        }else {
            //Se nao estiver no chão sera executado essa condição.
            if (xInput > 0) {
                constantForce2.torque = -8;
            } else if (xInput < 0) {
                constantForce2.torque = 8;
            } else {
                constantForce2.torque = 0;
            }

        }
    }
}
