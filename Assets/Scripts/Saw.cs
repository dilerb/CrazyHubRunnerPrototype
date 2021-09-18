using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace RunnerGame
{
    public class Saw : MonoBehaviour
    {
        [SerializeField] private float _startPointX;
        [SerializeField] private float _endPointX;
        [SerializeField] private bool _movable;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private GameObject _sawOriginPoint;

        private bool directionRight;

        void Start()
        {
            directionRight = true;

            //if (_movable)
            //    StartCoroutine("SawAnimation");
        }

        void Update()
        {
            //_sawOriginPoint.transform.RotateAround(_sawOriginPoint.transform.position, Vector3.back, _rotateSpeed * Time.deltaTime);
            _sawOriginPoint.transform.Rotate(0, 0, -1 * _rotateSpeed * Time.deltaTime);

            if (GameManager.Instance.gameOver)
                return;

            if (!_movable)
                return;

            if (transform.localPosition.x > _endPointX)
            {
                transform.localPosition = new Vector3(transform.localPosition.x - (0.01f * _moveSpeed), transform.localPosition.y, transform.localPosition.z);
                directionRight = false;
            }
            else if (transform.localPosition.x < _startPointX)
            {
                transform.localPosition = new Vector3(transform.localPosition.x + (0.01f * _moveSpeed), transform.localPosition.y, transform.localPosition.z);
                directionRight = true;
            }
            else
            {
                if (directionRight)
                    transform.localPosition = new Vector3(transform.localPosition.x + (0.01f * _moveSpeed), transform.localPosition.y, transform.localPosition.z);
                else
                    transform.localPosition = new Vector3(transform.localPosition.x - (0.01f * _moveSpeed), transform.localPosition.y, transform.localPosition.z);
            }
        }

        IEnumerator SawAnimation()
        {
            Vector3[] path = { transform.position, new Vector3(_endPointX, transform.position.y, transform.position.z), new Vector3(_startPointX, transform.position.y, transform.position.z) };
            Vector3[] path2 = { new Vector3(_startPointX, transform.position.y, transform.position.z) };

            while (true)
            {
                //yield return transform.DOPath(path, _moveSpeed).SetEase(Ease.Linear)
                //    .WaitForCompletion();

                //yield return transform.DOPath(path2, _moveSpeed).SetEase(Ease.Linear)
                //    .WaitForCompletion();
            }
        }
    }
}