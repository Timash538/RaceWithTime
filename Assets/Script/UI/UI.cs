using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class UI // контроль интерфейса
{
    public UICar UICar;
    private Vehicle _car;
    public void Initialize(Initializer initializer)
    {
        _car = initializer.controller.car;
    }

    public void ShowUi()
    {
        UICar.ShowAdrenaline(_car.Adrenaline);
        UICar.ShowSpeed(_car.Engine);
    }

}
