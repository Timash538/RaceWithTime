using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class CarCamera  //Камера машины 
{
    private Camera _camera;
    private Vehicle _car;

    public Vector3 distance;
    
    public void Initialize(Initializer initializer)
    { 
        _camera = Camera.current;
        _car = initializer.controller.car;
        PlaceCamera();
    }

    public void ControlCamera()
    {
        FollowCar();
        RotateCamera();
    }

    private void PlaceCamera()
    {
        
    }

    private void FollowCar()
    {
        
    }

    private void RotateCamera()
    {
        
    }

    public void ChangeCamera()
    {
        
    }

    public void ShakeCamera()
    {
        
    }
}
