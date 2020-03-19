using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    private Camera cam;

    public AudioSource dispara;
    public Light armaLight;
    public int IntencidadMax_luz;
    public float velocidadLuz;

    public Light colorLight;

    public LayerMask mascaraPersonalizada;
    public GameObject sueloTextura;

    public GameObject circulo;

    private bool disparado = false;

    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        //activa la luz del arma cada vez que se dispara
        if (disparado == true) {
            if (armaLight.intensity < IntencidadMax_luz)
            {
                armaLight.intensity += velocidadLuz;
            }
            else {
                disparado = false;
            }
        }
        else
        {
            if (armaLight.intensity > 0) {
                armaLight.intensity -= velocidadLuz;
            }
        }

        //disparo
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
                //cambia el color de la luz del segundo cuarto
                if (hit.transform.CompareTag("colorcube")) {
                    colorLight.color = hit.transform.GetComponent<Renderer>().material.color;
                }
                //empujar cubos en el curato cuarto
                if (hit.transform.CompareTag("pushcube"))
                {
                    hit.transform.GetComponent<Rigidbody>().velocity = hit.normal*-30;
                }
                //crear esferas en el sexto cuarto
                if (hit.transform.CompareTag("sueloCirculos"))
                {
                    Instantiate(circulo, new Vector3(hit.point.x, hit.point.y+0.5f, hit.point.z), Quaternion.Euler(0, 0, 0));
                }
                //cambiar de texturas el suelo del septimo cuarto
                if (hit.transform.CompareTag("esferasText"))
                {
                    sueloTextura.GetComponent<Renderer>().material.SetTexture("_MainTex", hit.transform.GetComponent<Renderer>().material.GetTexture("_MainTex"));
                    sueloTextura.GetComponent<Renderer>().material.SetTexture("_BumpMap", hit.transform.GetComponent<Renderer>().material.GetTexture("_BumpMap"));
                    sueloTextura.GetComponent<Renderer>().material.SetFloat("_BumpScale", 1f);
                    sueloTextura.GetComponent<Renderer>().material.mainTextureScale = new Vector2(2, 2);
                }

            }
        }
    }
}
