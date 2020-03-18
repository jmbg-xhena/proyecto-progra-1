using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma : MonoBehaviour
{
    private float PoccInicnial;
    private bool regresa = true;

    public float speed=0.1f;
    // Start is called before the first frame update
    void Start()
    {
        PoccInicnial = transform.position.z;   
    }

    // Update is called once per frame
    void Update()
    {
        if (!regresa)
        {
            if (transform.position.z < PoccInicnial + 17.5)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
            }
        }
        else {
            if (transform.position.z > PoccInicnial)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player")) {
            regresa = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            regresa = true;
        }
    }
}
