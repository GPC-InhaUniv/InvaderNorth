using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected ItemType itemName;
    
    public abstract void ApplyTheEffect();
}
