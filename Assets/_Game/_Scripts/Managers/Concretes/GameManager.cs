using CrowStudiosCase.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CrowStudiosCase
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
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
        
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
