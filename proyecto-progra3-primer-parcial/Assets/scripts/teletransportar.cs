using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teletransportar : MonoBehaviour
{
    public GameObject destinyPad;
    public bool teleported=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player")) {
            if (!destinyPad.transform.GetComponent<teletransportar>().teleported)
            {
                collision.transform.position = new Vector3(destinyPad.transform.position.x, destinyPad.transform.position.y+1, destinyPad.transform.position.z);
                teleported = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            destinyPad.transform.GetComponent<teletransportar>().teleported = false;
        }
    }
}