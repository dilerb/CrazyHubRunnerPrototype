using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private bool _smooth;
        [SerializeField] private float _smoothSpeed;
        [SerializeField] private Vector3 _followAxes;
        [SerializeField] private Transform _target;

        private Vector3 _offset;

        void Start()
        {
            _offset = transform.position - _target.position;
        }

        void Update()
        {
            if (GameManager.Instance.gameOver)
                return;

            if (_target)
            {
                Vector3 followPos = _target.position + _offset;
                followPos.x *= _followAxes.x;
                followPos.y *= _followAxes.y;
                followPos.z *= _followAxes.z;

                if (_smooth)
                {
                    transform.position = Vector3.Lerp(transform.position, followPos, _smoothSpeed * Time.deltaTime);
                }
                else
                {
                    transform.position = followPos;
                }
            }
        }
    }
}