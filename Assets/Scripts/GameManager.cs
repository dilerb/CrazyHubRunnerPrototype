using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RunnerGame
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField] private GameObject[] levelPrefabs;
        [SerializeField] private GameObject losePanel;
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject loseLevelText;
        [SerializeField] private GameObject winLevelText;
        [SerializeField] private GameObject endParticles;
        [SerializeField] private GameObject inGamePanel;
        [SerializeField] private GameObject joyStickPanel;

        public bool gameOver;
        public int currentLevel;
        public GameObject player;
        private void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void Start()
        {
            currentLevel = GetLevel();
            SetLevel();
            StartGame();
        }
        private void SetLevel()
        {
            loseLevelText.GetComponent<Text>().text = "Level " + currentLevel.ToString();
            winLevelText.GetComponent<Text>().text = "Level " + currentLevel.ToString();
        }
        private int GetLevel()
        {
            return PlayerPrefs.GetInt("Level", 1);
        }
        public void NextLevel()
        {
            currentLevel++;
            PlayerPrefs.SetInt("Level", currentLevel);
            SceneManager.LoadScene(0);
        }
        public void RestartLevel()
        {
            SceneManager.LoadScene(0);
        }
        public void StartGame()
        {
            gameOver = false;
            //joyStickPanel.SetActive(true);
        }
        public void StopGame()
        {
            gameOver = true;
        }
        public void OpenLosePanel()
        {
            losePanel.SetActive(true);
            //joyStickPanel.SetActive(false);
        }
        public void OpenWinPanel()
        {
            endParticles.SetActive(true);
            winPanel.SetActive(true);
            joyStickPanel.SetActive(false);
        }
        private void OnApplicationPause(bool pauseStatus)
        {
            // do smt.
        }
    }
}

