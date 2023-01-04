using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    public GameObject end;

    public void Start()
    {
        end.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //cuando el player entra en contacto con el collider,habilitamos la animacion y cambiamos de nivel
        if (collision.transform.CompareTag("Player"))
        {
            collision.GetComponent<Animator>().enabled = true;
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
   

}
