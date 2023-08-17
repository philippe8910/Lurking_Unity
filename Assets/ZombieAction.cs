using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ZombieAction : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer[] meshRenderers;
    
    [SerializeField] private Animator animator;

    [SerializeField] private bool isTrigger = false;
    
    [SerializeField] [Range(1,1)] private float time_f, time_Max = 1;

    public float animationNormalizedTime = 0;
    void Start()
    {
        TryGetComponent(out animator);
    }

    private void Update()
    {
        if (isTrigger)
        {
            time_f += Time.deltaTime;

            if (time_f > time_Max)
            {
                time_f = 0;
                isTrigger = false;

                foreach (var meshRenderer in meshRenderers)
                {
                    Debug.Log("Fade");
                    StartCoroutine(FadeOut(meshRenderer.material));
                }
            }
        }
    }

    [ContextMenu("NextAnimationClip")]
    public void NextAnimationClip()
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wave"))
        {
            isTrigger = true;
            time_f = 0;
            
            NextAnimationClip();
            
            //todo
            transform.DOMoveZ(transform.position.z - 2f , 0);

            foreach (var meshRenderer in meshRenderers)
            {
                meshRenderer.material.SetColor("_OutlineColor" , Color.white);
            }
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



