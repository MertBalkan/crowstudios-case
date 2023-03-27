using System.Collections.Generic;
using UnityEngine;

namespace CrowStudiosCase
{
    public class WheelColliderMovement : IWheelMovement
    {
        private readonly IInputService _input;
        private readonly IEntityController _entity;
        private readonly List<WheelCollider> _wheels;
        private readonly Transform[] _frontWheelsTransforms;
        
        private Transform _currentFrontLeft;
        private Transform _currentFrontRight;

        private float _currentBreakForce;
        private float _currentTurnAngle;
        private float _currentAcceleration;

        public WheelColliderMovement(IEntityController entity, IInputService input, List<WheelCollider> wheels, Transform[] frontWheelsTransforms)
        {
            _input = input;
            _entity = entity;

            _wheels = wheels;
            
            _frontWheelsTransforms = frontWheelsTransforms;
        }

        public void StartWheels()
        {
            _currentFrontLeft = _frontWheelsTransforms[0].transform;
            _currentFrontRight = _frontWheelsTransforms[1].transform;
        }

        public void UpdateWheels()
        {
            UpdateBreakForce();
            SetBreakForce();
            SetMotorTorque();
            TurnCar();
            SetFrontWheelRotations(0.3f);
        }

        public void SetMotorTorque()
        {
            _currentAcceleration = _entity.Acceleration * _input.MoveKeyHold;
            
            // i < 2 => frontLeft, frontRight
            for (var i = 0; i < 2; i++) _wheels[i].motorTorque = _currentAcceleration;
        }


        public void TurnCar()
        {
            _currentTurnAngle = _entity.TurnAngle * _input.TurnKeyHold;
            
            // i < 2 => frontLeft, frontRight
            for (var i = 0; i < 2; i++) _wheels[i].steerAngle = _currentTurnAngle;
        }

        /// <summary>
        /// Activate this method only if you want to turn front wheels visually.
        /// </summary>
        private void SetFrontWheelRotations(float visualWheelTurnSpeed)
        {
            if (_input.TurnKeyHold < 0)
            {
                _frontWheelsTransforms[0].transform.localRotation = Quaternion.Lerp(_currentFrontLeft.localRotation, Quaternion.Euler(0, Mathf.Lerp(-90, -150, Time.time * 0.1f), 0), Time.time * visualWheelTurnSpeed);
                _frontWheelsTransforms[1].transform.localRotation = Quaternion.Lerp(_currentFrontRight.localRotation, Quaternion.Euler(0, Mathf.Lerp(-90, -150, Time.time * 0.1f), 0), Time.time * visualWheelTurnSpeed);
            }
            else if (_input.TurnKeyHold > 0)
            {
                _frontWheelsTransforms[0].transform.localRotation = Quaternion.Lerp(_currentFrontLeft.localRotation, Quaternion.Euler(new Vector3(0, Mathf.Lerp(-90, -50, Time.time * 0.1f), 0)), Time.time * visualWheelTurnSpeed);
                _frontWheelsTransforms[1].transform.localRotation = Quaternion.Lerp(_currentFrontRight.localRotation, Quaternion.Euler(new Vector3(0, Mathf.Lerp(-90, -50, Time.time * 0.1f), 0)), Time.time * visualWheelTurnSpeed);
                
            }
            else
                for (var i = 0; i < 2; i++)
                    _frontWheelsTransforms[i].transform.localRotation = Quaternion.Euler(0, -90, 0);
        }

        public void SetBreakForce() => _wheels.ForEach(w => w.brakeTorque = _currentBreakForce);
        private void UpdateBreakForce() => _currentBreakForce = _input.BreakKeyHold ? _currentBreakForce = _entity.BreakingForce : _currentBreakForce = 0;
    }
}