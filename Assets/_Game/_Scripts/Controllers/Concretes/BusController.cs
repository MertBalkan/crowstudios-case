using CrowStudiosCase.Components;

namespace CrowStudiosCase.Controllers
{
    public sealed class BusController : BaseCarController
    {
        private CameraSwitchComponent _cameraSwitchComponent;
        
        protected override void Awake()
        {
            base.Awake();
            _cameraSwitchComponent = GetComponent<CameraSwitchComponent>();
        }

        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            base.Update();
            
            _cameraSwitchComponent.SwitchCamera();
        }
    }
}