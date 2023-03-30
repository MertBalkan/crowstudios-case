using CrowStudiosCase.Controllers;
using TMPro;
using UnityEngine;

namespace CrowStudiosCase.UIs
{
    public class PassengerCountText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI passengerText;
        [SerializeField] private TextMeshProUGUI addedTimeText;

        public void UpdatePassengerCountText(int passengerCount, float addedTimeCount)
        {
            passengerText.text = "Passengers: " + passengerCount;
            addedTimeText.text = "+" + addedTimeCount;
        }

        public void DisableText(BusStopController busStopController)
        {
            passengerText.gameObject.SetActive(false);
            addedTimeText.gameObject.SetActive(false);
        }
        public void EnableText() => gameObject.SetActive(true);
    }
}