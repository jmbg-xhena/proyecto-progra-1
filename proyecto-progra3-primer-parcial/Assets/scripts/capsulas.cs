using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsulas : MonoBehaviour
{
    public LayerMask mascara;
    public LayerMask mascara_reset;
    public Camera cam;

    //cambiar la mascaras visibles para la cámara principal cuando se para sobre uno de los pads
    private void OnCollisionEnter(Collision collision)
    {
        cam.cullingMask = mascara;
    }
    private void OnCollisionExit(Collision collision)
    {
        cam.cullingMask = mascara_reset;
    }
}
