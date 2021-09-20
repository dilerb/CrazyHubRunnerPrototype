using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace RunnerGame
{
    public class PingPongCup : MonoBehaviour
    {
        [SerializeField] private GameObject _pingpong;
        [SerializeField] private GameObject _player;
        void Start()
        {

        }

        private void OnMouseUp()
        {
            StartCoroutine("ThrowBall");
        }

        IEnumerator ThrowBall()
        {
            _player.GetComponent<Player>()._animator.Play("Throw");
            _pingpong.SetActive(true);
            Vector3 startPos = _pingpong.transform.position;
            yield return new WaitForSeconds(1f);
            yield return _pingpong.transform.DOJump(transform.position, 2f, 0, 1f).WaitForCompletion();
            _pingpong.transform.position = startPos;
        }
    }
}

