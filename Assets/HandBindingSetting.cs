using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HandBindingSetting : MonoBehaviour
{
    [Header("Component Setting")]
    [SerializeField] private Rigidbody rigidbody;

    [SerializeField] private Transform bindTarget;

    [Header("Value Setting")]
    [SerializeField] private float followSpeed;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        if (bindTarget == null)
        {
            Debug.LogError("None Bind Target!!");
        }
    }

    private void Update()
    {
        if(!bindTarget)
            return;
        
        
        rigidbody.velocity = (bindTarget.transform.position - transform.position) * followSpeed;
        rigidbody.rotation = bindTarget.transform.rotation;
    }
}
