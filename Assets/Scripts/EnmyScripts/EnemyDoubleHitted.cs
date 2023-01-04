using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoubleHitted : MonoBehaviour
{
    //Script que controla cuando el player salta sobre el enemigo, este muere, aplicando una fueza hacia arriba
    //simulando un salto antes de morir
    public GameObject enemy;
    private int hittCounter = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
       
        //cuando el player entra en contacto con el collider, genereamos la fuerza y restamos 1 del contador
        //cuando llegue a 0, eliminamos el GO
        if (collision.transform.CompareTag("Player"))
        {
            hittCounter = hittCounter - 1;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.up * 3;
            if (hittCounter == 0)
            {
                collision.GetComponent<Rigidbody2D>().velocity = Vector2.up * 3;
                Destroy(enemy);
            }
            
        }
    }
}