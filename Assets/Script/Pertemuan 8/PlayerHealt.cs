using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealt : MonoBehaviour
{

    //Logika heakth player
    //kalo plaer terkena tubrukan kena damage health =>hp berkurangprivate void s

    public Scrollbar sb;

    private void Start()
        {
            sb.size = 1;
        }   




    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
               sb.size -= 0.04f;
        }
  
    }

    private void Update()
    {
        if (sb.size == 0)
        {
            Debug.Log("You Died");
        }
    }

}
