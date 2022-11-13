using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroiDano : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject morte;

    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("Vilao")) {

            foreach (ContactPoint2D hitpos in collision.contacts) {

                if (hitpos.normal.y > 0 && hitpos.normal.y >= Mathf.Abs(hitpos.normal.x)) {

                    rb.AddForce(Vector2.up * 4, ForceMode2D.Impulse);
                    Destroy(collision.gameObject);
                    Instantiate(morte,collision.transform.position, Quaternion.identity);

                } else {
                    rb.AddForce(new Vector2(hitpos.normal.x * 4, hitpos.normal.y *4), ForceMode2D.Impulse);
                    if (GameManager.inst.vida > 0) {
                        GameManager.inst.vida--;
                        GameManager.inst.imgCoracao[GameManager.inst.vida].enabled = false;
                    }
                    if (GameManager.inst.vida <= 0) {
                        Destroy(gameObject);
                    }
                    
                }
            }
        }   
    }
}
