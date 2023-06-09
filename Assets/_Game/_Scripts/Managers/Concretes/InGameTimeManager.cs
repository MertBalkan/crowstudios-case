using CrowStudiosCase.UIs;
using CrowStudiosCase.Utils;

namespace CrowStudiosCase.Managers
{
    public class InGameTimeManager : SingletonMonoBehaviour<InGameTimeManager>
    {
        private CountDownUI _countDownTimerUI;

        public CountDownUI CountDownUI => _countDownTimerUI;
        private void Awake()
        {
            SetupInstance();

            _countDownTimerUI = FindObjectOfType<CountDownUI>();
        }

        public void AddTimer(float amount)
        {
            _countDownTimerUI.AddTime(amount);
        }

        public void DecreaseTimer(float amount)
        {
            _countDownTimerUI.DecreaseTime(amount);
        }
    }
}
