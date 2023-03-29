using TMPro;
using UnityEngine;

namespace CrowStudiosCase
{
    public class NotificationText : MonoBehaviour
    {
        public void DisplayNotificationText(bool isDoorsOpen, bool isBusStopped)
        {
            if (isDoorsOpen && isBusStopped)
            {
                gameObject.SetActive(false);
            }
                
            if (isDoorsOpen && !isBusStopped)
            {
                gameObject.SetActive(true);
                GetComponent<TextMeshProUGUI>().text = "LOWER YOUR SPEED LIMIT TO TAKE PASSENGERS!";
            }
            else if (isBusStopped && !isDoorsOpen)
            {
                gameObject.SetActive(true);
                GetComponent<TextMeshProUGUI>().text = "OPEN DOORS TO TAKE PASSENGERS!";
            }
            else if (!isBusStopped && !isDoorsOpen)
            {
                gameObject.SetActive(true);
                GetComponent<TextMeshProUGUI>().text = "OPEN DOORS AND LOWER YOUR SPEED LIMIT";
            }
        }
    }
}
