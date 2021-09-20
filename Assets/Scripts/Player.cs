using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace RunnerGame
{
    public class Player : MonoBehaviour
    {
        [SerializeField] internal Animator _animator;
        [SerializeField] private GameObject _pingpongBall;

        private PlayerMovement _playerMovement;
        internal int _correctHit = 0;
        void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void OnTriggerEnter(Collider c)
        {
            if (c.CompareTag("Beer"))
            {
                c.gameObject.SetActive(false);

                _playerMovement._reverseControl = true;
                ChangeAnimationDrunkWalk();
            }
            else if(c.CompareTag("Coffee"))
            {
                GameManager.Instance.IncreaseScore(1);

                c.gameObject.SetActive(false);

                _playerMovement._reverseControl = false;
                ChangeAnimationRun();
            }
            else if (c.CompareTag("LosePoint"))
            {
                _animator.Play("Falling");

                GameManager.Instance.StopGame();
                GameManager.Instance.OpenLosePanel();
            }
            else if (c.CompareTag("Finish"))
            {
                //_pingpongBall.AddComponent<Rigidbody>();
                //_pingpongBall.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                _animator.Play("Idle");

                GameManager.Instance.StopGame();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Saw"))
            {
                if (collision.collider.transform.position.x > 0)
                {
                    transform.LookAt(new Vector3(transform.position.x + 10, transform.position.y, transform.position.z));
                    transform.DOJump(new Vector3(transform.position.x + 10, transform.position.y, transform.position.z), 3f, 0, 1.5f);
                }
                else
                {
                    transform.LookAt(new Vector3(transform.position.x - 10, transform.position.y, transform.position.z));
                    transform.DOJump(new Vector3(transform.position.x - 10, transform.position.y, transform.position.z - 5), 3f, 0, 1.5f);
                }

                _animator.Play("Falling");

                GameManager.Instance.StopGame();
                GameManager.Instance.OpenLosePanel();
            }
        }

        private void ChangeAnimationDrunkWalk()
        {
            _animator.Play("DrunkWalk");
        }
        private void ChangeAnimationRun()
        {
            _animator.Play("Running");
        }
    }
}

