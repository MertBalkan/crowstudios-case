using System;
using CrowStudiosCase.Utils;
using TMPro;
using UnityEngine;

namespace CrowStudiosCase
{
    public class NotificationText : MonoBehaviour
    {
        private TextMeshProUGUI _notificationText;

        private void Awake()
        {
            _notificationText = GetComponent<TextMeshProUGUI>();
        }

        public void DisplayNotificationText(bool isDoorsOpen, bool isBusStopped)
        {
            if (isDoorsOpen && isBusStopped)
                DisableText();
                
            if (isDoorsOpen && !isBusStopped)
            {
                EnableText();
                UpdateText(NotificationConsts.LowerYourSpeedNotif);
            }
            else if (isBusStopped && !isDoorsOpen)
            {
                EnableText();
                UpdateText(NotificationConsts.OpenDoorsNotif);
            }
            else if (!isBusStopped && !isDoorsOpen)
            {
                EnableText();
                UpdateText(NotificationConsts.OpenDoorsAndLowerYourSpeedNotif);
            }
        }
        
        public void DisableText() => gameObject.SetActive(false);
        public void EnableText() => gameObject.SetActive(true);
        private void UpdateText(string newText) => _notificationText.text = newText;
    }
}