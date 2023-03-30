using CrowStudiosCase.Managers;
using TMPro;
using UnityEngine;

namespace CrowStudiosCase.UIs
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI gameOverScore;
        private void Start()
        {
            DeactivatePanel();
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameOver += ActivatePanel;
            GameManager.Instance.OnGameOver += ShowEndScore;
        }

        private void ActivatePanel()
        {
            gameObject.SetActive(true);
        }

        private void ShowEndScore()
        {
            gameOverScore.text = "Score: " + ScoreManager.Instance.Score;
        }
        
        private void DeactivatePanel()
        {
            gameObject.SetActive(false);
        }
    }
}