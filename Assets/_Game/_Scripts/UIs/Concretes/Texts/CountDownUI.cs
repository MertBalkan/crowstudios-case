using System;
using System.Collections;
using CrowStudiosCase.Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CrowStudiosCase.UIs
{
    public class CountDownUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private float duration;
        [SerializeField] private Image clockImage;

        private BusController _busController;

        private float _minute;
        private float _seconds;
        private float _currentTime;
        
        public bool IsTimerFinished => (_minute == 0 && _seconds == 0);

        private void Awake()
        {
            _busController = FindObjectOfType<BusController>();
        }

        void Start()
        {
            _currentTime = duration;
            
            _minute = Mathf.FloorToInt(_currentTime / 60);
            _seconds = Mathf.FloorToInt(_currentTime % 60);
            
            timeText.text = $"{_minute:00}:{_seconds:00}";
            
            StartCoroutine(CountdownTime());
        }
        
        private IEnumerator CountdownTime()
        {
            while (_currentTime >= 0)
            {
                clockImage.fillAmount = Mathf.InverseLerp(0, duration, _currentTime);
                _minute = Mathf.FloorToInt(_currentTime / 60);
                _seconds = Mathf.FloorToInt(_currentTime % 60);
                
                timeText.text = $"{_minute:00}:{_seconds:00}";
                yield return new WaitForSeconds(1f);
                
                _currentTime--;
                clockImage.fillAmount = _currentTime;
            }
            
            yield return null;
        }

        public void AddTime(float timeAmount)
        {
            _currentTime += timeAmount;
        }

        public void DecreaseTime(float timeAmount)
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