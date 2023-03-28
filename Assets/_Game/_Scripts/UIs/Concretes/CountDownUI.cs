using System.Collections;
using TMPro;
using UnityEngine;

namespace CrowStudiosCase.UIs
{
    public class CountDownUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private float duration;

        private float _minute;
        private float _seconds;
        private float _currentTime;
        
        public bool IsTimerFinished => (_minute == 0 && _seconds == 0);

        void Start()
        {
            _currentTime = duration;
            
            _minute = Mathf.FloorToInt(_currentTime / 60);
            _seconds = Mathf.FloorToInt(_currentTime % 60);
            
            timeText.text = string.Format("{0:00}:{1:00}", _minute, _seconds);
            
            StartCoroutine(CountdownTime());
        }

        private IEnumerator CountdownTime()
        {
            while (_currentTime >= 0)
            {
                _minute = Mathf.FloorToInt(_currentTime / 60);
                _seconds = Mathf.FloorToInt(_currentTime % 60);
                
                timeText.text = "Time Left: " + string.Format("{0:00}:{1:00}", _minute, _seconds);
                yield return new WaitForSeconds(1f);
                
                _currentTime--;
            }
            yield return null;
        }

        public void AddTime(float timeAmount)
        {
            _currentTime += timeAmount;
        }

        public void RemoveTime(float timeAmount)
        {
            if(timeAmount == 0) return;

            if (timeAmount > _currentTime)
            {
                _currentTime = 0;
                return;
            }
            
            _currentTime -= timeAmount;
        }
    }
}