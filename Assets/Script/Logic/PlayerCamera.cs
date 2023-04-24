using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform _transform, _rig, _rigArm;
    [SerializeField] private Camera _camera;


    [SerializeField] private ControllableVehicle _vehicle;
    [SerializeField] private Rigidbody _targetRigidbody;
    public void Initialize(ControllableVehicle vehicle, int totalPlayers, int playerNumber)
    {
        _vehicle = vehicle;
        _targetRigidbody = vehicle.GetRigidbody();

        SetPlayerView(playerNumber, totalPlayers);
    }

    private void LateUpdate()
    {
        _transform.position = Vector3.Lerp(_transform.position, _vehicle.Position, Time.deltaTime * 5f);
        _transform.rotation = Quaternion.Slerp(_transform.rotation, Quaternion.Euler(Vector3.up * SignedAngle(_vehicle.Forward)), Time.deltaTime * 5f);

    }

    private float SignedAngle(Vector3 vehicleForward)
    {
        vehicleForward = Vector3.ProjectOnPlane(vehicleForward, Vector3.up).normalized;
        float angle = Vector3.Angle(vehicleForward, Vector3.forward) * Mathf.Sign(Vector3.Dot(vehicleForward, Vector3.right));
        return angle;
    }

    #region OLD_CODE
    void SetPlayerView(int playerNumber, int numberOfPlayers)
    {
        int pNumber = playerNumber + 1;
        if (numberOfPlayers == 4)
            switch (pNumber)
            {
                case 1:
                    SetRect(-0.5f, 0.5f);
                    break;
                case 2:
                    SetRect(0.5f, 0.5f);
                    break;
                case 3:
                    SetRect(-0.5f, -0.5f);
                    break;
                case 4:
                    SetRect(0.5f, -0.5f);
                    break;
            }
        if (numberOfPlayers == 3)
            switch (pNumber)
            {
                case 1:
                    SetRect(0.0f, 0.5f);
                    break;
                case 2:
                    SetRect(-0.5f, -0.5f);
                    break;
                case 3:
                    SetRect(0.5f, -0.5f);
                    break;
            }
        if (numberOfPlayers == 2)
            switch (pNumber)
            {
                case 1:
                    SetRect(0.0f, 0.5f);
                    break;
                case 2:
                    SetRect(0.0f, -0.5f);
                    break;
            }
    }

    void SetRect(float marginX, float marginY) => _camera.rect = new Rect(marginX, marginY, 2000.0f, 2000.0f);
    #endregion
}
