using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SonicObject : MonoBehaviour
{
    [SerializeField] private GameObject sonicObject;

    [SerializeField] private Rigidbody rigidbody;
    void Start()
    {
        if (sonicObject == null) 
        {
            try
            {
                sonicObject = Resources.Load<GameObject>("Prefab/Wave");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var wave = Instantiate(sonicObject, transform.position, sonicObject.transform.rotation);
        
        Destroy(wave , 5);
    }
}
