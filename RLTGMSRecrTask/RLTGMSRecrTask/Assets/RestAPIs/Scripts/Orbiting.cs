using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiting : MonoBehaviour
{
    public GameObject orbitedObject;
    public float orbitingSpeed = 10f;

    private void Update()
    {        
        transform.RotateAround(orbitedObject.transform.position, Vector3.up, orbitingSpeed * Time.deltaTime);
    }
    

}
