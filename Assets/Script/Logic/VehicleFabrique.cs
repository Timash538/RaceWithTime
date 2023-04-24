using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleFabrique : MonoBehaviour
{
    [SerializeField] private ControllableVehicle[] _vehiclePrefabs;
    [SerializeField] private PlayerCamera _cameraPrefab;
    [SerializeField] private PlayerController _playerControllerPrefab;
    [SerializeField] private AbstractController _botControllerPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private int _totalPlayers;
    private int _splitScreenIndex;
    public void Initialize(int totalPlayers)
    {
        _totalPlayers = totalPlayers;
        _splitScreenIndex = 0;
    }

    public ControllableVehicle MakePlayer(int car, int place, out AbstractController controller)
    {
        var vehicle = Instantiate(_vehiclePrefabs[car], _spawnPoints[place].position, _spawnPoints[place].rotation);
        controller = Instantiate(_playerControllerPrefab, vehicle.transform);
        controller.Initialize(vehicle);
        (controller as PlayerController).SetKeymap(_splitScreenIndex);
        var camera = Instantiate(_cameraPrefab, _spawnPoints[place].position, _spawnPoints[place].rotation);
        camera.Initialize(vehicle, _totalPlayers, _splitScreenIndex);
        _splitScreenIndex++;
        return vehicle;
    }

    public ControllableVehicle MakeBot(int car, int place, out AbstractController controller)
    {
        var vehicle = Instantiate(_vehiclePrefabs[car], _spawnPoints[place].position, _spawnPoints[place].rotation);
        controller = Instantiate(_botControllerPrefab, vehicle.transform);
        controller.Initialize(vehicle);
        return vehicle;
    }
}
