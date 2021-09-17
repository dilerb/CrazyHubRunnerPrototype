using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class DebugMenu : MonoBehaviour
    {
        [SerializeField] private Camera _cam;
        [SerializeField] private GameObject _player;
        [Space]
        [SerializeField] private GameObject _debugMenuPanel;

        private PlayerMovement _playerMovement;

        void Start()
        {
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
    }
}

