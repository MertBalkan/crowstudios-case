using CrowStudiosCase.Controllers;
using TMPro;
using UnityEngine;

namespace CrowStudiosCase.UIs
{
    public class PassengerCountText : MonoBehaviour
    {
        public void UpdatePassengerCountText(int passengerCount) => GetComponent<TextMeshProUGUI>().text = "Passengers: " + passengerCount;
        public void DisableText(BusStopController busStopController) => gameObject.SetActive(false);
        public void EnableText() => gameObject.SetActive(true);
    }
}