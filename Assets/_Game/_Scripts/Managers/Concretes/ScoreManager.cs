using CrowStudiosCase.Utils;
using TMPro;
using UnityEngine;

namespace CrowStudiosCase.Managers
{
    public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        private int _score;
        
        private bool IsScoreZero => _score < 0;
        public int Score => _score;
        
        private void Awake()
        {
            SetupInstance();
        }

        private void Start()
        {
            UpdateScoreText();
        }

        private void Update()
        {
            UpdateScoreText();
        }

        public void UpdateScoreText()
        {
            scoreText.text = "Score: " + _score;
        }

        public void IncreaseScore(int scoreAmount)
        {
            _score += scoreAmount;
        }

        public void DecreaseScore(int scoreAmount)
        {
            _score -= scoreAmount;
            if (IsScoreZero) _score = 0;
        }
    }
}
