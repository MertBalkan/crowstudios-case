using CrowStudiosCase.Inputs;
using CrowStudiosCase.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CrowStudiosCase.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        public System.Action OnGameOver;
        
        private void Awake()
        {
            SetupInstance();
        }
        
        public void LoadSelfScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        public void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        public void LoadSceneByIndex(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public bool IsGameScene()
        {
            return SceneManager.GetActiveScene().buildIndex == 1;
        }

        public void PressedPlayAgainButton()
        {
            ScoreManager.Instance.ResetScore();
            LoadSelfScene();
        }

        public void Update()
        {
            if(IsGameScene() && InGameTimeManager.Instance.CountDownUI.IsTimerFinished)
                OnGameOver?.Invoke();
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }

        public void ResetGame(IInputService input)
        {
            if (input.ResetGameKeyPressed)
                LoadSelfScene();
        }
    }
}