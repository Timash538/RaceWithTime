using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle : MonoBehaviour //абстрактный класс транспорта
{
    public bool isPlayer;
    public Adrenaline Adrenaline; 
    public Engine Engine;
    public Hull Hull;
    public Wheels Wheels;

		public Rigidbody rb;
    
    public void Initialize(Initializer initializer)
    { 
        GetComponents(); 
        Adrenaline.Initialize(initializer,this); 
        Engine.Initialize(initializer,this); 
        Hull.Initialize(initializer,this);
        Wheels.Initialize(initializer,this);
    }

    private void GetComponents()
    {
        
    }

}
