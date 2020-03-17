using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsulas : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask mascara;
    public LayerMask mascara_reset;
    public Camera cam;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        cam.cullingMask = mascara;
    }
    private void OnCollisionExit(Collision collision)
    {
        cam.cullingMask = mascara_reset;
    }
}
