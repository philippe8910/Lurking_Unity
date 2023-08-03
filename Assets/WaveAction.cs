using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WaveAction : MonoBehaviour
{
    [Range(0.5f , 10)] [SerializeField] private float waveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(new Vector3(15, 15, 15), waveSpeed).SetEase(Ease.Linear);
    }
}
