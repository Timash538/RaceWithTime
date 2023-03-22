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
        car.Engine.Accelerate(Input.GetKey(Keys.Accelerate));
        car.Engine.Brake(Input.GetKey(Keys.Brake));
        car.Engine.Boost(Input.GetKey(Keys.Boost));
        car.Wheels.Drift(Input.GetKey(Keys.Drift));
        car.Adrenaline.SlowTime(Input.GetKey(Keys.SlowTime));
        
        if (Input.GetKey(Keys.TurnLeft) || Input.GetKey(Keys.TurnRight))
            car.Wheels.Turn(Input.GetKey(Keys.TurnLeft) ? Keys.TurnLeft : Keys.TurnRight);
       
        if(Input.GetKeyDown(Keys.CameraChange))
            _camera.ChangeCamera();

        if (Input.GetKeyDown(Keys.ResetRace))
            SceneManager.LoadScene(0);

    }
    
    
}
