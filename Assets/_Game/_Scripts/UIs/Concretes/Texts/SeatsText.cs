using TMPro;
using UnityEngine;

namespace CrowStudiosCase.UIs
{
    public class SeatsText : MonoBehaviour
    {
        public void UpdateSeatText(int newSeatCount, int capacity) => GetComponent<TextMeshProUGUI>().text = "Seats: " + newSeatCount + "/" + capacity;
        public void DisableText() => gameObject.SetActive(false);
        public void EnableText() => gameObject.SetActive(true);
    }
}
