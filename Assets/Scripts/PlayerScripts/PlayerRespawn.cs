using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public Animator animator;
    public int health = 3;


    public void PlayerDamaged()
    {
        if (health > 0)
        {
            health--;
            animator.Play("hit");
        }
        else
        {
            animator.Play("hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
