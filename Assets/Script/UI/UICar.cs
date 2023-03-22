using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class UICar //интрефейс машинки
{
    public Image Speed;
    public Image Adrenaline;
    
    public void ShowSpeed(Engine engine) => 
        Speed.fillAmount = engine.speed / engine.maxSpeed;

    public void ShowAdrenaline(Adrenaline adrenaline) =>
        Adrenaline.fillAmount = adrenaline.adrenaline / adrenaline.maxAdrenaline;
    
}
