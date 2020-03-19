using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour
{
    public Rigidbody rigi;
    public float velocidad;
    public float salto;
    public float correr;
    public bool EnSuelo = false;
    public float velRotación;
    public int NSaltos;
    public int Saltos;
    public AudioSource Salta;
    public AudioSource bgm;

    public Camera cam;

    void Start()
    {
        cam = gameObject.GetComponentInChildren<Camera>();
        rigi = GetComponent<Rigidbody>();
        Saltos = NSaltos;
        correr = 1;
    }

    void Update()
    {
        //regresar al inicio del cuarto si el jugador cae al vacío
        if (transform.position.y < -10 || Input.GetKeyDown(KeyCode.U)) {
            rigi.MovePosition(new Vector3(-5, -5, 90));
            rigi.MoveRotation(Quaternion.Euler(Vector3.zero));
        }

        //controlador del jugador

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 vel = rigi.velocity;
        Vector3 mov = new Vector3(h, 0f, v);
        mov = transform.TransformDirection(mov) * velocidad * correr;
        vel = new Vector3(mov.x, vel.y, mov.z);

        if (EnSuelo && Input.GetButtonDown("Jump"))
        {
            Salta.Play();
            Saltos -= 1;
            vel.y = salto;
            if (Saltos <= 0)
            {
                EnSuelo = false;
            }
        }

        if (Saltos>=NSaltos && Input.GetKey(KeyCode.LeftShift))
        {
            correr = 2;
        }
        else {
            correr = 1;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * velRotación * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            Quaternion rotactual = rigi.rotation;
            Quaternion rotacionasumar = Quaternion.Euler(Vector3.up * velRotación * Time.deltaTime);
            rotactual *= rotacionasumar;
            rigi.MoveRotation(rotactual);
        }

        rigi.velocity = vel;
    }

    //detener l musica cuando se entra al ultimo cuarto
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("stopMusic")) {
            bgm.Stop();
        }
    }
}
