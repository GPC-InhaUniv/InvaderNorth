using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    void Move(GameObject enemy);
}


public class Fixing : MonoBehaviour, IMovable
{
    public void Move(GameObject enemy)
    {
        Debug.Log("No Moving");
    }
}


public class Moving : MonoBehaviour, IMovable
{
    float speed;
    public Moving(float speed)
    {
        this.speed = speed;
    }


    public void Move(GameObject enemy)
    {

        Debug.Log("Moving");
    }

    
}