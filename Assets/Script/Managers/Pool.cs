using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Pool // Здесь хранится все, что спавнится на сцену
{
    public List<Vehicle> CarsList;
    public void Initialize(Initializer initializer)
    { 
        LoadCars();
    }

    private void LoadCars() => CarsList.AddRange(Resources.LoadAll<Vehicle>("Prefab/Cars/"));
    
}
