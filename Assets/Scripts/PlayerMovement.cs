using Lean.Touch;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] internal float _forwardSpeed = 5f;
        [SerializeField] internal float _swipeLerpSpeed = 5f;
        [SerializeField] private float _strafeSpeed = 5f;
        [SerializeField] private float _clampPositionX = 5f;

        private bool _drive = true;
        private float _swipeSpeed = 0f;
        private float _nextSpeed = 0f;
        internal bool _reverseControl = false;

        void Start()
        {
            LeanTouch.OnFingerDown += LeanTouch_OnFingerDown;
            LeanTouch.OnFingerUpdate += LeanTouch_OnFingerUpdate;
            LeanTouch.OnFingerUp += LeanTouch_OnFingerUp;
        }

        void FixedUpdate()
        {
            if (GameManager.Instance.gameOver)
                return;

            MoveForward();
            //Rotate();

            //if (!_drive)
            //    return;

            Swipe();
            ClampPosition();
        }

        private void MoveForward()
        {
            transform.Translate(Vector3.forward * _forwardSpeed * Time.deltaTime);
        }

        private void Swipe()
        {
            _swipeSpeed = Mathf.Lerp(_swipeSpeed, _nextSpeed, _swipeLerpSpeed * Time.deltaTime);

            if (_reverseControl)
            {
                transform.Translate(Vector3.left * _swipeSpeed * _strafeSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.right * _swipeSpeed * _strafeSpeed * Time.deltaTime);
            }
        }

        private void ClampPosition()
        {
            float x = Mathf.Clamp(transform.position.x, -_clampPositionX, _clampPositionX);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
        private void LeanTouch_OnFingerUp(LeanFinger obj)
        {
            _nextSpeed = 0f;
            _drive = false;
        }
        private void LeanTouch_OnFingerDown(LeanFinger obj)
        {
            _drive = true;
        }
        private void LeanTouch_OnFingerUpdate(LeanFinger obj)
        {
            _nextSpeed = obj.ScaledDelta.normalized.x;
        }
    }
}

