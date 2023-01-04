using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChangeDirection : MonoBehaviour
{
    //Scrip que se encarga de cambiar de direccion el enemigo cuando el collider detecta un obstaculo
    public GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Fruit"))  //con este if, evitamos que el enemigo "tope" con las frutas
        {
            //cuando el collider detecta un obstaculo, cambiamos la direccion del enemigo
            enemy.GetComponent<EnemyMoveForward>().speed = -enemy.GetComponent<EnemyMoveForward>().speed;
            //accedemos al SR y volteamos el sprite
            enemy.GetComponent<SpriteRenderer>().flipX = !enemy.GetComponent<SpriteRenderer>().flipX;

            //si choca con el player, accedemos a playerRespawn y llamamos a la funcion PlayerDamaged
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerRespawn>().PlayerDamaged();
            }
        }

    }
}
