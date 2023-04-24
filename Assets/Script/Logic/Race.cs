using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Race : MonoBehaviour
{
    [SerializeField] private int _totalPlayers;
    [SerializeField] private int _totalRacers;

    [SerializeField] private VehicleFabrique _vehicleFabrique;

    private void Awake()
    {
        _vehicleFabrique.Initialize(_totalPlayers);
        _vehicleFabrique.MakePlayer(0, 0, out AbstractController controller);
    }

}
