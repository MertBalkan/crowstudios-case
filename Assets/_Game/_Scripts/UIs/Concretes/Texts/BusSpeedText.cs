using TMPro;
using UnityEngine;

namespace CrowStudiosCase.UIs
{
    public class BusSpeedText : MonoBehaviour
    {
        public void UpdateBusSpeedText(float speedAmount)
        {
            GetComponent<TextMeshProUGUI>().text = "Speed: " + speedAmount + " km/h ";
        }
    }
}