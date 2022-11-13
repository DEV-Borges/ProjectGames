using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MoveTouch : MonoBehaviour {
    public Transform alvo;
    private float xMax, xMin, yMax, yMin;
    [SerializeField]
    private Tilemap tileM;
    private Vector3 minTile, maxTile;


    void Start() {
        //retorno dos limites tilemaps.
        minTile = tileM.CellToWorld(tileM.cellBounds.min);
        maxTile = tileM.CellToWorld(tileM.cellBounds.max);

        limites(minTile, maxTile);
    }

    //chamado depois que todas as ~fuções são executada.
    void Update() {

        //Verificando se esta tendo algum toque na tela, caso tenha um toque na tela o input.touchCount será maior que zero.
        if (Input.touchCount > 0) {
            //
            // Variavel responsavel por receber o toque na tela.
            //
            Touch t = Input.GetTouch(0);
            //
            //Movimentação do personagem/camera.
            //
            if (t.phase == TouchPhase.Moved) {
                transform.position -= (Vector3)t.deltaPosition * 6 / 600;
                limites(minTile, maxTile);
            }

        }
        #region MovimentoPeloTouch
        /*//Verificando se esta tendo algum toque na tela, caso tenha um toque na tela o input.touchCount será maior que zero.
            if (Input.touchCount > 0) {
                // Variavel responsavel por receber o toque na tela.
                Touch t = Input.GetTouch(0);
                //Movimentação do personagem/camera.
                if (t.phase == TouchPhase.Moved) {
                    transform.position += (Vector3) t.deltaPosition/400;
            }*/
        #endregion
    }

    void LateUpdate() {
        transform.position = new Vector3(Mathf.Clamp(alvo.position.x,xMin,xMax), Mathf.Clamp(alvo.position.y,yMin,yMax), -10);
    }

    void limites(Vector3 minTile, Vector3 maxTile) {

        Camera cam = Camera.main;
        float altura = 2f * cam.orthographicSize;
        float largura = altura * cam.aspect;

        xMin = minTile.x + largura / 2;
        xMax = maxTile.x - largura / 2;
        yMin = minTile.y + altura / 2;
        yMax = maxTile.y - altura / 2;


    }

    public void ClickZoomIncrease() {

        Camera cam = Camera.main;

        if (cam.orthographicSize > 10) {

            cam.orthographicSize -= 10;
        }
    }

    public void ClickZoomdDecrease() {

        Camera cam = Camera.main;

        if (cam.orthographicSize < 50) {

            cam.orthographicSize += 10;
        }
    }

}
