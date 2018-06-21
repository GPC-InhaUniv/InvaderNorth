using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    void Move(GameObject enemy);
}


public class Fixing : IMovable
{

    public void Move(GameObject enemy)
    {
        Debug.Log("No Moving");
    }
}

public class BaseMoving : IMovable
{
    private bool isFrist = true;
    private float speed;
    Rigidbody enemyRigidbody;
    public BaseMoving(float speed, Rigidbody EnemyRigidbody)
    {
        this.speed = speed;
        enemyRigidbody = EnemyRigidbody;
    }


    public void Move(GameObject enemy)
    {
        if (isFrist)
        {
            enemyRigidbody.velocity = enemy.transform.forward * speed;
            isFrist = false;
        }
        //Debug.Log("Moving");
    }

    
}

public class NamedMoving : IMovable
{
    private bool isFrist = true;
    private float speed;
    Rigidbody enemyRigidbody;
    public NamedMoving(float speed, Rigidbody EnemyRigidbody)
    {
        this.speed = speed;
        enemyRigidbody = EnemyRigidbody;
    }


    public void Move(GameObject enemy)
    {
        if (enemy.transform.position.z > 11)
        {
            enemyRigidbody.velocity = enemy.transform.forward * speed;
        }

        if(enemy.transform.position.z <= 11)
        {
            if (isFrist)
            {
                enemyRigidbody.velocity = enemy.transform.right * -speed;
                isFrist = false;
            }

            if (enemy.transform.position.x <= -4.5)
            {
                enemyRigidbody.velocity = enemy.transform.right * -speed;
            }
            else if (enemy.transform.position.x >= 4.5)
            {
                enemyRigidbody.velocity = enemy.transform.right * speed;
            }
        }

        //Debug.Log("Moving");
    }


}