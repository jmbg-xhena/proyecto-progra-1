using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teletransportar : MonoBehaviour
{
    public GameObject destinyPad;//plataforma hermana
    public bool teleported=false;//le dice a la otra plataforma si caba de enviar al jugador

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player")) {
            //deja que el juagador se teletransporte siempre y cuando no halla sido teletransportado por la otra platafroma
            if (!destinyPad.transform.GetComponent<teletransportar>().teleported)
            {
                collision.transform.position = new Vector3(destinyPad.transform.position.x, destinyPad.transform.position.y+1, destinyPad.transform.position.z);
                teleported = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //le dice a la plataforma que el jugador puede teletransportarse
        if (collision.transform.CompareTag("Player"))
        {
            destinyPad.transform.GetComponent<teletransportar>().teleported = false;
        }
    }
}