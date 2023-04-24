using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractController : MonoBehaviour
{
    public abstract void Initialize(ControllableVehicle vehicle);
}
