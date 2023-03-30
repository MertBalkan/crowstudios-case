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

        public void DisplayBusStopNotificationText(bool isDoorsOpen, bool isBusStopped)
        {
            if (isDoorsOpen && isBusStopped)
                DisableText();
                
            if (isDoorsOpen && !isBusStopped)
            {
                EnableText();
                UpdateText(NotificationConstants.LowerYourSpeedNotif);
            }
            else if (isBusStopped && !isDoorsOpen)
            {
                EnableText();
                UpdateText(NotificationConstants.OpenDoorsNotif);
            }
            else if (!isBusStopped && !isDoorsOpen)
            {
                EnableText();
                UpdateText(NotificationConstants.OpenDoorsAndLowerYourSpeedNotif);
            }
        }

        public void DisplayBusFullNotification()
        {
            EnableText();
            UpdateText(NotificationConstants.BusFullNotif);
        }

        public void DisplayPassengerDropPointNotification()
        {
            EnableText();
            UpdateText(NotificationConstants.SlowDownAndOpenDoorNotif);
        }
        
        public void DisableText() => gameObject.SetActive(false);
        public void EnableText() => gameObject.SetActive(true);
        private void UpdateText(string newText) => _notificationText.text = newText;
    }
}