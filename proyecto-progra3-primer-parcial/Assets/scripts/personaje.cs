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
    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponentInChildren<Camera>();
        rigi = GetComponent<Rigidbody>();
        Saltos = NSaltos;
        correr = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10 || Input.GetKeyDown(KeyCode.U)) {
            rigi.MovePosition(new Vector3(-5, -5, 90));
            rigi.MoveRotation(Quaternion.Euler(Vector3.zero));
        }


        float h = Input.GetAxis("Horizontal");//[-1.0f,1.0f]
        float v = Input.GetAxis("Vertical");//[-1.0f,1.0f]

        Vector3 vel = rigi.velocity;
        Vector3 mov = new Vector3(h, 0f, v);
        mov = transform.TransformDirection(mov) * velocidad * correr;
        vel = new Vector3(mov.x, vel.y, mov.z);
        //vel.x = h * velocidad;
        //vel.z = v * velocidad;

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
            rotactual *= rotacionasumar;//mult de quaterniones es una suma
            rigi.MoveRotation(rotactual);
        }

        rigi.velocity = vel;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("stopMusic")) {
            bgm.Stop();
        }
    }
}
