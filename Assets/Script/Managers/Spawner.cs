using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour //спавнит обьекты на сцену
{
    [Header("Обьект, где хранятся машины со сцены")]
    public Transform carsContainer;
    
    [Header("Координаты спавна машин")]
    public List<Transform> carSpawnPoints;
    
    [Header("Управление интерфесом")]
    public UI ui;
    
    [Header("Управление камерой")]
    public CarCamera carCamera;
    
    [Header("Управление вводом")]
    public Controller controller;
    
    [Header("Управление петлей")]
    public Rule rule;
    
    [Header("Управление правилами гонок")]
    public Race race;
    
    [Header("Хранилище обьектов")]
    public Pool pool;

    [HideInInspector]public List<Vehicle>carsInRace = new List<Vehicle>();
    protected void SpawnCars(Initializer initializer)
    {
        for (int i = 0; i < race.RacersCount; i++)
        {
            var car = Instantiate(pool.CarsList[i], carSpawnPoints[i].transform.position, Quaternion.identity, carsContainer); 
            carsInRace.Add(car);
            car.Initialize(initializer);
        }
    }

}
