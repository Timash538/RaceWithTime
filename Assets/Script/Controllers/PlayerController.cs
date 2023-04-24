using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AbstractController
{
    [SerializeField] private ControllableVehicle _controllableVehicle;
    private int _keymap;

    public override void Initialize(ControllableVehicle vehicle)
    {
        _controllableVehicle = vehicle;
    }

    public void SetKeymap(int keymap)
    {
        _keymap = keymap;
    }

    private void Update()
    {
        _controllableVehicle.Controls.Acceleration = Input.GetAxis($"Vertical{_keymap}");
        _controllableVehicle.Controls.Steering = Input.GetAxis($"Horizontal{_keymap}");
        _controllableVehicle.Controls.Brake = Input.GetButton($"Brake{_keymap}") ? 1 : 0;
    }
}
