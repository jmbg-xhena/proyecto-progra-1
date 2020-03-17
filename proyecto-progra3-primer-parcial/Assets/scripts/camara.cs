﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    private Camera cam;
    public AudioSource dispara;

    public Light armaLight;
    public int IntencidadMax_luz;
    public Light colorLight;
    public LayerMask mascaraPersonalizada;
    public GameObject circulo;

    private bool disparado = false;
    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (disparado == true) {
            if (armaLight.intensity < IntencidadMax_luz)
            {
                armaLight.intensity += 0.15f;
            }
            else {
                disparado = false;
            }
        }
        else
        {
            if (armaLight.intensity > 0) {
                armaLight.intensity -= 0.15f;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            disparado = true;
            dispara.Play();
            RaycastHit hit;//almacenar información del impacto del rayo
            Ray rayo = cam.ScreenPointToRay(Input.mousePosition);//crea rallo en la posición del mouse
            //if (Physics.Raycast(rayo, out hit, mascaraPersonalizada))
            //if (Physics.Raycast(rayo, out hit, mascara))
            if (Physics.Raycast(rayo, out hit,mascaraPersonalizada))
            {
                Debug.DrawLine(rayo.origin, hit.point, Color.green, 1f);
                if (hit.transform.CompareTag("colorcube")) {
                    colorLight.color = hit.transform.GetComponent<Renderer>().material.color;
                }
                if (hit.transform.CompareTag("pushcube"))
                {
                    hit.transform.GetComponent<Rigidbody>().velocity = hit.normal*-10;
                }
                if (hit.transform.CompareTag("sueloCirculos"))
                {
                    print("touch");
                    Instantiate(circulo,hit.transform);
                }

            }
            else
            {
                Debug.DrawLine(rayo.origin, rayo.direction * 100, Color.red, 1f);
            }
        }
    }
}
