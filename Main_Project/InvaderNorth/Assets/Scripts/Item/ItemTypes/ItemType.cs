using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ItemType
{
    void ExertAnEffect(GameObject gameObject);

    void StopTheEffect();
}
