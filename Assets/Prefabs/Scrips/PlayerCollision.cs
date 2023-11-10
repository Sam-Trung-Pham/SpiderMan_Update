using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public AudioSource sound_death;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Enemy"))
        {
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
            sound_death.Play();
        }
        if (other.transform.tag=="Enemy")
        {
            HeartManager.health--;
            if (HeartManager.health<=0)
            {
                PlayerManager.isGameOver = true;
                gameObject.SetActive(false);
                sound_death.Play(); 
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
    }
    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6,8);
        GetComponent<Animator>().SetLayerWeight(1,1);
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetLayerWeight(1,0);
        Physics2D.IgnoreLayerCollision(6,8, false);
    }
}
