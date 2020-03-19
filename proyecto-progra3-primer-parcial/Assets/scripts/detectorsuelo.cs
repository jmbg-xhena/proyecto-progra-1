using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectorsuelo : MonoBehaviour
{
    public personaje pers;
    private void OnTriggerEnter(Collider other)
    {
        pers.EnSuelo = true;//avisamos que está en el suelo
        pers.Saltos = pers.NSaltos;//resetear saltos
    }
}
