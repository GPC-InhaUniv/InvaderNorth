using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected GameObject Parent;
    public abstract void ApplyTheEffect();
}
