using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

[Serializable]
public class Controller // Обработка ввода
{
    public Keys Keys;
    [HideInInspector] public Vehicle car;
    private CarCamera _camera;
    
    public void Initialize(Initializer initializer, Vehicle player)
    {
        _camera = initializer.carCamera;
        car = player;
    }

    public void WaitForInput()
    {
        if (Input.GetKey(Keys.Accelerate)) 
            car.Engine.Accelerate();
        
        if(Input.GetKey(Keys.Brake))
            car.Engine.Brake();
        
        if(Input.GetKey(Keys.Boost))
            car.Engine.Boost();
        
        if (Input.GetKey(Keys.TurnLeft) || Input.GetKey(Keys.TurnRight))
            car.Wheels.Turn(Input.GetKey(Keys.TurnLeft) ? Keys.TurnLeft : Keys.TurnRight);

        if(Input.GetKey(Keys.Drift))
            car.Wheels.Drift();
        
        if(Input.GetKey(Keys.SlowTime))
            car.Adrenaline.SlowTime();
        
        if(Input.GetKey(Keys.CameraChange))
            _camera.ChangeCamera();

        if (Input.GetKey(Keys.ResetRace))
            SceneManager.LoadScene(0);

    }
}
