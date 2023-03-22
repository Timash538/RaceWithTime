using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Engine
{
    private AudioFX _audioFX;
    public float maxSpeed;
    public float speed;
    public float accelerationMultiplier;
    public float brakeMultiplier;
    public float boostMultiplier;
    
   
    public void Initialize(Initializer initializer, Vehicle car)
    {
        _audioFX = car.AudioFX;
    }

    public void Accelerate(bool isAccelerating)
    {
        _audioFX.PlayEngine(isAccelerating);
    }
    
    public void Brake(bool isBraking)
    {
        _audioFX.PlayBrake(isBraking);
    }

    public void Boost(bool isBooting)
    {
        
    }
}
