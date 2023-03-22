using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Engine
{
    [HideInInspector] public float speed;
    public float maxSpeed;
    public float brakeMultiplier;
    public float accelerationMultiplier;
    public float boostMultiplier;

		Rigidbody car;
    public void Initialize(Initializer initializer, Vehicle car)
    {
			this.car = car.rb;
    }

    public void Accelerate()
    {
        Debug.Log("go");
				
				car.AddForce(car.transform.forward* maxSpeed, ForceMode.Impulse);
    }
    
    public void Brake()
    {
        
    }

    public void Boost()
    {
        
    }
}
