using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma : MonoBehaviour
{
    private float PoccInicnial;
    private bool regresa = true;
    private GameObject player;

    public float speed=0.1f;
  
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PoccInicnial = transform.position.z;   
    }

    void Update()
    {
        //mueve la platafroma dependiendo si el jugador está en ella
        if (!regresa)
        {
            //hacia adelante
            if (transform.position.z < PoccInicnial + 17.5)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
            }
        }
        else {
            //haca atrás
            if (transform.position.z > PoccInicnial)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
            }
        }
    }

    //avanzar
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(player.tag)) {
            regresa = false;
            player.transform.parent = this.transform;//hace al jugador hijo de la platafroma para que el se mueva con ella
        }
    }

    //regresar
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag(player.tag))
        {
            regresa = true;
            this.transform.DetachChildren();//devincula al jugador y la plataforma cuando sale de ella
        }
    }
}
