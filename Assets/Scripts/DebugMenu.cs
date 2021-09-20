using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace RunnerGame
{
    public class DebugMenu : MonoBehaviour
    {
        [SerializeField] private Camera _cam;
        [SerializeField] private GameObject _player;
        [Space]
        [SerializeField] private GameObject _debugMenuPanel;

        private PlayerMovement _playerMovement;
        private CameraFollow _cameraFollow;

        void Start()
        {
            _cameraFollow = _cam.GetComponent<CameraFollow>();
            _playerMovement = _player.GetComponent<PlayerMovement>();
        }

        public void OpenCloseDebugMenu()
        {
            if (_debugMenuPanel.activeInHierarchy)
            {
                _debugMenuPanel.SetActive(false);
            }
            else
            {
                _debugMenuPanel.SetActive(true);
            }
        }

        public void IncForwardSpeed()
        {
            _playerMovement._forwardSpeed += 1f;
        }
        public void DecForwardSpeed()
        {
            _playerMovement._forwardSpeed -= 1f;
        }
        public void IncSwipeSpeed()
        {
            _playerMovement._swipeLerpSpeed += 1f;
        }
        public void DecSwipeSpeed()
        {
            _playerMovement._swipeLerpSpeed -= 1f;
        }
        public void LeftTurnCamera()
        {
            _cam.transform.Rotate(Vector3.down);
        }
        public void RightTurnCamera()
        {
            _cam.transform.Rotate(Vector3.up);
        }
        public void UpTurnCamera()
        {
            _cam.transform.Rotate(Vector3.left);
        }
        public void DownTurnCamera()
        {
            _cam.transform.Rotate(Vector3.right);
        }

        public void LeftMoveCamera()
        {
            _cam.transform.position += Vector3.left;
            _cameraFollow.ChangeOffset(_cam.transform.position);
        }
        public void RightMoveCamera()
        {
            _cam.transform.position += Vector3.right;
            _cameraFollow.ChangeOffset(_cam.transform.position);
        }
        public void UpMoveCamera()
        {
            _cam.transform.position += Vector3.up;
            _cameraFollow.ChangeOffset(_cam.transform.position);
        }
        public void DownMoveCamera()
        {
            _cam.transform.position += Vector3.down;
            _cameraFollow.ChangeOffset(_cam.transform.position);
        }
    }
}

