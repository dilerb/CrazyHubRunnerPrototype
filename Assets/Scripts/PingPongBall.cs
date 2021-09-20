using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class PingPongBall : MonoBehaviour
    {
        [SerializeField] GameObject _player;

        private Player _playerScript;
        private void Start()
        {
            _playerScript = _player.GetComponent<Player>();
        }

        private void OnTriggerEnter(Collider c)
        {
            if (c.CompareTag("PingPongCup"))
            {
                _playerScript._correctHit++;
                c.transform.GetChild(0).gameObject.SetActive(true);
                c.GetComponent<BoxCollider>().enabled = false;

                if (_playerScript._correctHit > 2)
                {
                    //_player.transform.Rotate(new Vector3(180f, 0, 0));
                    _player.GetComponent<Player>()._animator.Play("Victory");
                    GameManager.Instance.gameOver = true;
                    GameManager.Instance.OpenWinPanel();
                }
            }
        }
    }
}
