using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle : MonoBehaviour //абстрактный класс транспорта
{
    public bool isPlayer;
    public string vehicleName; 
    public Adrenaline Adrenaline; 
    public Engine Engine;
    public Hull Hull;
    public Wheels Wheels;
    public  AudioFX AudioFX;
    private AudioSource _audioSource;
    
    public void Initialize(Initializer initializer)
    { 
        GetComponents(); 
        Adrenaline.Initialize(initializer,this); 
        Engine.Initialize(initializer,this); 
        Hull.Initialize(initializer,this);
        Wheels.Initialize(initializer,this);
        AudioFX.Initialize(this,_audioSource);
    }

    private void GetComponents()
    {
        _audioSource = GetComponent<AudioSource>();
    }

}
