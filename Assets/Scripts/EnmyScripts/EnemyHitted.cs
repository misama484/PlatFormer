using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitted : MonoBehaviour
{
    //Script que controla cuando el player salta sobre el enemigo, este muere, aplicando una fueza hacia arriba
    //simulando un salto antes de morir
    public GameObject enemy;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //cuando el player entra en contacto con el collider, genereamos la fuerza y eliminamos el GO
        //sumamos 50 al score
        if (collision.transform.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.up * 3;
            GameObject.Find("ControlCenter").GetComponent<SceneController>().score += 50;
            Destroy(enemy);
        }
    }
}
