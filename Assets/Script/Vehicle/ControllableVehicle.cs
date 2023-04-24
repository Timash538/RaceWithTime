using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ControllableVehicle : MonoBehaviour
{

    [Header("Parameters")]
    [SerializeField] private float _maxSpeed = 25;
    [SerializeField] private float _engineForce = 3000;
    [SerializeField] private AnimationCurve _engineCurve = new AnimationCurve();
    [SerializeField] private float _brakeForce = 3000;

    [Header("Physics")]
    [SerializeField] private Transform _centerOfMass;


    [Header("Wheels (FL, FR, RL, RR)")]
    [SerializeField] private WheelCollider[] _wheels;
    [SerializeField] private DriveFormula _driveFormula = DriveFormula.Rear;

    [Header("Wheels")]
    [SerializeField] private float _steeringAngle = 45;
    [SerializeField] private float _steeringSpeed = 1;

    [Header("Gameplay")]
    [SerializeField] private float _adrenalineCapacity = 45;
    [SerializeField] private float _adrenalineÑonsumptionSpeed = 1;
    [SerializeField] private float _adrenalineReplenishmentSpeed = 1;

    private VehicleControls _vehicleControls = new VehicleControls();
    private Transform _transform;
    private Rigidbody _rigidbody;
    private float _steeringAngleMinimal;
    private Transform[] _wheelsVisual;
    private float _steeringValue;
    private Vector3 _forward;

    public VehicleControls Controls => _vehicleControls;
    public float Speed => _rigidbody.velocity.magnitude;
    public Vector3 Position => _transform.position;
    public Vector3 Forward => _forward;

    internal Rigidbody GetRigidbody()
    {
        return _rigidbody;
    }

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();

        _rigidbody.centerOfMass = _centerOfMass.localPosition;

        ConfigureWheelsHierachy();
        CalculateSimplePseudoAckermannAngles(_steeringAngle, ref _steeringAngleMinimal);
    }

    private void ConfigureWheelsHierachy()
    {
        _wheelsVisual = new Transform[4];
        for (int i = 0; i < _wheels.Length; i++)
        {
            Transform newParent = (new GameObject()).transform;
            newParent.position = _wheels[i].transform.parent.position;
            newParent.SetParent(_transform);
            _wheelsVisual[i] = _wheels[i].transform.parent;
            _wheelsVisual[i].SetParent(newParent);
            _wheels[i].transform.parent = _transform;
        }
    }

    private void CalculateSimplePseudoAckermannAngles(float steeringAngleMaximal, ref float steeringAngleMinimal)
    {
        float carBase = (_wheels[0].transform.position - _wheels[2].transform.position).magnitude;
        var right = _transform.right;
        Vector3 rotationCenter = _wheels[2].transform.position - right * carBase / Mathf.Sin(steeringAngleMaximal * Mathf.Deg2Rad);
        Vector3 leftWheelVector = _wheels[1].transform.position - rotationCenter;
        steeringAngleMinimal = Vector3.Angle(right, leftWheelVector.normalized);
    }

    private void FixedUpdate()
    {
        var sign = Mathf.Sign(Controls.Steering);
        //   _steeringValue = Mathf.Clamp(_steeringValue + _steeringSpeed * Time.fixedDeltaTime * sign, sign > 0.1f ? -1 : Controls.Steering, sign < -0.1f ? 1 : Controls.Steering);
        _steeringValue = Mathf.Lerp(_steeringValue, Controls.Steering, Time.fixedDeltaTime * _steeringSpeed);
        for (int i = 0; i < _wheels.Length; i++)
        {
            if (((1 << i) & (int)DriveFormula.Front) != 0)
            {
                ApplySteering(i, _steeringValue);
            }
        }
    }

    private void Update()
    {
        _forward = _transform.forward;
        Controls.InjectSpeed(CalculateProjectedSpeed(_forward));

        for (int i = 0; i < _wheels.Length; i++)
        {
            _wheels[i].brakeTorque = 0;

            if (((1 << i) & (int)_driveFormula) != 0)
            {
                ApplyForce(_wheels[i]);
            }

            if (((1 << i) & (int)DriveFormula.Rear) != 0)
            {
                ApplyBrake(_wheels[i]);
            }

            UpdateVisual(i);
        }
    }

    private void UpdateVisual(int i)
    {
        WheelHit hit;

        if (_wheels[i].GetGroundHit(out hit))
        {
            _wheelsVisual[i].localPosition = new Vector3(0, -((_wheels[i].transform.position - hit.point).magnitude - _wheels[i].radius), 0);
        }
        else
        {

            _wheelsVisual[i].localPosition = new Vector3(0, -_wheels[i].suspensionDistance, 0);
        }

        _wheelsVisual[i].Rotate(Vector3.right * _wheels[i].rpm * 6f * Time.deltaTime);

    }

    private void ApplyBrake(WheelCollider wheelCollider)
    {
        wheelCollider.brakeTorque = Controls.Brake * _brakeForce;
    }

    private float CalculateProjectedSpeed(Vector3 forward)
    {
        return Vector3.Project(_rigidbody.velocity, forward).magnitude * Mathf.Sign(Vector3.Dot(_rigidbody.velocity, forward));
    }

    private void ApplySteering(int number, float steeringValue)
    {
        float angle = (((steeringValue > 0) ^ (number == 0)) ? _steeringAngleMinimal : _steeringAngle) * steeringValue;

        _wheelsVisual[number].parent.localEulerAngles = Vector3.up * angle;
        _wheels[number].steerAngle = angle;
    }

    private void ApplyForce(WheelCollider wheelCollider)
    {
        wheelCollider.motorTorque = Controls.Acceleration * _engineCurve.Evaluate(Controls.Speed / _maxSpeed) * _engineForce;
    }

    public enum DriveFormula
    {
        Front = 1 << 0 | 1 << 1,
        Rear = 1 << 2 | 1 << 3,
        Both = 1 << 0 | 1 << 1 | 1 << 2 | 1 << 3,
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        if (_centerOfMass != null)
            Gizmos.DrawWireCube(_centerOfMass.position, Vector3.one * 0.1f);
    }

    public class VehicleControls
    {
        public float Acceleration = 0;
        public float Brake = 1;
        public float Steering = 0;
        public bool UseAdrenaline = false;

        public float Speed { get; private set; }

        public void InjectSpeed(float speed)
        {
            Speed = speed;
        }
    }
}
