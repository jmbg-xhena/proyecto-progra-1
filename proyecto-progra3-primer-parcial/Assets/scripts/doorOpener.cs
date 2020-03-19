using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpener : MonoBehaviour
{
    public GameObject door;
    private bool open = false;
    public float openSpeed = 0.2F;

    void Update()
    {
        //mueve la puerta hasta el máximo o el minimo dependiendo de si el jugador está o no en el trigger
        if (open)
        {
            if (door.transform.position.y < 11.5)
            {
                door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y + openSpeed, door.transform.position.z);
            }
        }
        else
        {
            if (door.transform.position.y > -0.39)
            {
                door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y - openSpeed, door.transform.position.z);
            }
        }

    }

    //abrir
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player")){
            open = true;
        }
    }

    //cerrar
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            open = false;
        }
    }
}
