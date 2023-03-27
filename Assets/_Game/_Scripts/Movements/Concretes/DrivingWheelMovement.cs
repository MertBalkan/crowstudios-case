using CrowStudiosCase.Controllers;
using CrowStudiosCase.Inputs;
using UnityEngine;

namespace CrowStudiosCase.Movements
{
    public class DrivingWheelMovement : IWheelMovement
    {
        private readonly IEntityController _entity;
        private readonly IInputService _input;
        
        private readonly Transform _drivingWheel;
        private Vector3 _wheelFirstRot;
        private Quaternion _wheelNormalRot;
        
        private bool _isCarRotating = false;
        
        private readonly float _rotateSmoothAmount;
        private float _rotateAmount = 2;
        
        public DrivingWheelMovement(IEntityController entity, IInputService input, Transform drivingWheel,float rotateSmoothAmount)
        {
            _entity = entity;
            _input = input;
            _rotateSmoothAmount = rotateSmoothAmount;
            _drivingWheel = drivingWheel;
        }
        
        public void StartWheel()
        {
            _wheelFirstRot = Vector3.zero;
        }

        public void UpdateWheel()
        {
            _rotateAmount = _entity.TurnAngle * Time.deltaTime;
            WheelPropController();
        }
        
        private void WheelPropController()
        {
            if (_input.TurnKeyHold != 0) _isCarRotating = true;

            if (_input.TurnKeyHold > 0  && _isCarRotating) RotateWheel(_rotateAmount * -1);
            if (_input.TurnKeyHold < 0  && _isCarRotating) RotateWheel(_rotateAmount);

            if (_input.TurnKeyHold == 0)
            {
                _isCarRotating = false;
                _wheelFirstRot = new Vector3(-105, 0, 90); // hard code for initial vector amount.
                _wheelNormalRot = Quaternion.Euler(_wheelFirstRot);
                _drivingWheel.transform.localRotation = Quaternion.Slerp(_drivingWheel.transform.localRotation, _wheelNormalRot, _rotateSmoothAmount);
            }
        }
        
        private void RotateWheel(float rotateWheelAmount) => _drivingWheel.transform.Rotate(new Vector3(0, 0, rotateWheelAmount * -1));
    }
}