using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ZombieAction : MonoBehaviour
{
    [Header("Component Setting")]
    [SerializeField] private SkinnedMeshRenderer[] meshRenderers;
    
    [SerializeField] private Animator animator;

    [Header("Value Setting")]
    [SerializeField] private float animationNormalizedTime = 0;
    
    [SerializeField] private float outlineCountDownTime = 1;
    
    void Start()
    {
        TryGetComponent(out animator);
    }

    [ContextMenu("NextAnimationClip")]
    private void NextAnimationClip()
    {
        Debug.Log("NextAnimationClip");
        animator.Play("Zombie Walk" , 0 , animationNormalizedTime);

        animationNormalizedTime += 0.3f;
        
        if (animationNormalizedTime >= 1)
        {
            var nextTime = animationNormalizedTime - 1;

            animationNormalizedTime = nextTime;
        }
    }

    private void NextPositionStep()
    {
        transform.DOMoveZ(transform.position.z - 2.5f , 0);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wave"))
        {
            NextAnimationClip();
            NextPositionStep();

            StopCoroutine(StartCountingOutlineDisable()); 
            StartCoroutine(StartCountingOutlineDisable());
            
            foreach (var meshRenderer in meshRenderers)
            {
                meshRenderer.material.SetColor("_OutlineColor" , Color.white);
            }
        }
    }

    IEnumerator StartCountingOutlineDisable()
    {
        yield return new WaitForSeconds(outlineCountDownTime);

        foreach (var meshRenderer in meshRenderers)
        {
            StartCoroutine(FadeOut(meshRenderer.material));
        }
    }

    IEnumerator FadeOut(Material material)
    {
        var color = material.GetColor("_OutlineColor");
        
        if (color.a > 0)
        {
            var _color = color;
            _color.a -= 0.01f;

            material.SetColor("_OutlineColor" , _color);
            yield return new WaitForSeconds(0.01f);
            StartCoroutine(FadeOut(material));
        }
        else
        {
            yield return null;
        }
    }
}



