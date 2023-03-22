using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AudioFX
{
   private AudioSource _source;
   private Vehicle _car;
   public AudioClip Engine;
   public AudioClip Brake;
   public AudioClip Road;
   public AudioClip OffRoad;

   public void Initialize(Vehicle car, AudioSource source)
   {
      _source = source;
      _car = car;
      LoadFX();
   }

   private void LoadFX()
   {
      Engine = Resources.Load<AudioClip>("Audio/FX/" + _car.vehicleName + "/Engine");
      Brake = Resources.Load<AudioClip>("Audio/FX/" + _car.vehicleName + "/Brake");
      Road = Resources.Load<AudioClip>("Audio/FX/" + _car.vehicleName + "/Road");
      OffRoad = Resources.Load<AudioClip>("Audio/FX/" + _car.vehicleName + "/OffRoad");
      _source.clip = Engine;
      _source.loop = true;
   }

   public void PlayEngine(bool isAccelerating)
   {
      _source.pitch = isAccelerating ? 1.1f : 1;
   }

   public void PlayBrake(bool isBraking)
   {
      _source.pitch = isBraking ? 0.9f : 1;
   }

}
