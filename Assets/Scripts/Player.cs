using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class Player : MonoBehaviour
    {
        [SerializeField] Animator _animator;

        private PlayerMovement _playerMovement;
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
                c.gameObject.SetActive(false);

                _playerMovement._reverseControl = false;
                ChangeAnimationRun();
            }
            else if (c.CompareTag("Saw"))
            {
                //..
            }
        }

        private void ChangeAnimationDrunkWalk()
        {
            _animator.Play("DrunkWalk");
        }
        private void ChangeAnimationRun()
        {
            _animator.Play("Run");
        }
    }
}

