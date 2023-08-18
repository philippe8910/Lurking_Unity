using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class OutlineAction : MonoBehaviour
{
    [SerializeField] private Outline outlineSetting;

    [SerializeField] private float time_f, time_Max = 1;

    [SerializeField] private bool isEnter;

    private void Start()
    {
        var _material = Resources.Load<Material>("Materials/OutlineObject");

        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<MeshRenderer>().material = _material;

        gameObject.AddComponent<Outline>();
        outlineSetting = GetComponent<Outline>();
        outlineSetting.OutlineMode = Outline.Mode.OutlineVisible;
        outlineSetting.OutlineWidth = 8;
    }

    private void Update()
    {
        if (isEnter)
        {
            time_f += Time.deltaTime;

            if (time_f > time_Max)
            {
                Debug.Log("Time out");
                
                StopAllCoroutines();
                StartCoroutine(FadeOut());
                
                time_f = 0;
                isEnter = false;

                IEnumerator FadeOut()
                {
                    if (outlineSetting.OutlineColor.a > 0)
                    {
                        var _color = outlineSetting.OutlineColor;
                        _color.a -= 0.01f;

                        outlineSetting.OutlineColor = _color;
                        yield return new WaitForSeconds(0.01f);
                        StartCoroutine(FadeOut());
                    }
                    else
                    {
                        yield return null;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wave")
        {
            outlineSetting.OutlineColor = Color.white;
            isEnter = true;
            time_f = 0;
        }
    }
}
