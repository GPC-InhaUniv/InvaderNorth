using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ItemType
{
    void LeaveBombFromPlayer(GameObject gameObject);

    void StartTheEffect(GameObject BombObject);

    void StopTheEffect();
}
