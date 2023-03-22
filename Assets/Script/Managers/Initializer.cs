using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Initializer : Spawner //Здесь все начинается, контроль апдейта
{
    void Awake() //Закидываем ссылку на инициализатор. Аналоги метода старт
    { 
        pool.Initialize(this);
        SpawnCars(this);
        race.Initialize(this);
        rule.Initialize(this);
        InitController();
        ui.Initialize(this);
        carCamera.Initialize(this);
    }

    private void InitController()
    {
        foreach (var player in carsInRace.Where(player => player.isPlayer))
            controller.Initialize(this,player);
    }
    
    private void FixedUpdate() //обработка ввода и физики
    {
        controller.WaitForInput();
        //здесь еще будет апдейт для ии
    }
    
    void Update() //единственный апдейт на всю игру.
    {
        carCamera.ControlCamera();
        ui.ShowUi();
    }

    
}
