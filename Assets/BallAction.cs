using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAction : MonoBehaviour
{
    [SerializeField] private GameObject wave;

    private void OnCollisionEnter(Collision collision)
    {
        var g = Instantiate(wave, transform.position, wave.transform.rotation);
        
        Destroy(g , 5);
    }

}
