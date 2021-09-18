using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TurningAnimation : MonoBehaviour
{
    [SerializeField] private float _rotateRate;
    void Start()
    {
        transform.DORotate(Vector3.up, _rotateRate).SetLoops(-1, LoopType.Incremental);
    }
}
