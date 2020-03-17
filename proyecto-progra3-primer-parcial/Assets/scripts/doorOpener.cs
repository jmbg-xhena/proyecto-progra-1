using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpener : MonoBehaviour
{
    public GameObject door;
    private bool open = false;
    public float openSpeed = 0.2F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            if (door.transform.position.y < 11.5)
            {
                door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y + openSpeed, door.transform.position.z);
            }
        }
        else
        {
            if (door.transform.position.y > -0.39)
            {
                door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y - openSpeed, door.transform.position.z);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player")){
            open = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            open = false;
        }
    }
}
