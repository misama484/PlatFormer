using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//importamos libreria de audio
using UnityEngine.Audio;

public class FruitsCollected : MonoBehaviour
{
    //declaramos un GO para el audio
    public AudioSource sound;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //con este if, evitamos que los enemigos recolecten frutas
        {


            //Como la fruta "vivira" un poco mas, desactivamos el collider para que no
            //se pueda recoger de nuevo
            GetComponent<Collider2D>().enabled = false;

            //accedemos al SR de la fruta ylo desactivamos para que no se vea, pero se
            //mantenga la animacion
            GetComponent<SpriteRenderer>().enabled = false;

            //accedemos al GO de la animacion(a traves de la fruta, ya que la anim
            //es el primer hijo) y lo activamos
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            //una vez ejecutada la animacion, destruimos el GO, pasando un tiempo de demora
            //para que se vea la animacion
            Destroy(gameObject, 0.5f);

            //restamos 1 a la cantidad de frutas que quedan
            SceneController.fruitsRemaining--;

            //Buscamos el GO de la escena y ejecutamos el metodo que chekea las frutas
            GameObject.Find("ControlCenter").GetComponent<SceneController>().checkFruitsRemaining();

            //reproducimos el sonido al recoger la fruta
            sound.Play();

            //Sumamos 10 a la variable score de controlCenter
            GameObject.Find("ControlCenter").GetComponent<SceneController>().score += 10;
        }
    }
}
