using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Moving
{
    protected float speed;
    protected Rigidbody enemyRigidbody;
    public abstract void Move(GameObject enemy);
}


public class Fixing : Moving
{

    public override void Move(GameObject enemy)
    {
        Debug.Log("No Moving");
    }
}

public class BaseMoving : Moving
{
    public BaseMoving(float speed, Rigidbody enemyRigidbody)
    {
        this.speed = speed;
        this.enemyRigidbody = enemyRigidbody;
    }


    public override void Move(GameObject enemy)
    {
            enemyRigidbody.velocity = enemy.transform.forward * speed;
        //Debug.Log("Moving");
    }

    
}

public class Zigzag : Moving
{
    private bool canLeft;

    public Zigzag(float speed, Rigidbody enemyRigidbody)
    {
        this.speed = speed;
        this.enemyRigidbody = enemyRigidbody;
    }

    public override void Move(GameObject enemy)
    {
        if (!canLeft)
        {
            enemyRigidbody.velocity = new Vector3(2f, 0, -1) * speed;
            if (enemy.transform.position.x >= 4.5)
                canLeft = true;
        }
        else
        {
            enemyRigidbody.velocity = new Vector3(-2f, 0, -1) * speed;
            if (enemy.transform.position.x <= -4.5)
                canLeft = false;
        }
        
    }
}

public class HorizontalMoving : Moving
{
    public HorizontalMoving(float speed, Rigidbody enemyRigidbody)
    {
        if(enemyRigidbody.transform.position.x < 0)
            this.speed = speed;
        else
            this.speed = -speed;

        this.enemyRigidbody = enemyRigidbody;
    }

    public override void Move(GameObject enemy)
    {
        enemyRigidbody.velocity = Vector3.right * speed;

    }
}

public class FirstNamedMoving : Moving
{

    public FirstNamedMoving(float speed, Rigidbody enemyRigidbody)
    {
        this.speed = speed;
        this.enemyRigidbody = enemyRigidbody;
    }

    public override void Move(GameObject enemy)
    {
        if (enemy.transform.position.z > 11)
        {
            enemyRigidbody.velocity = enemy.transform.forward * speed;
        }
        else
            enemyRigidbody.velocity = Vector3.zero;
        //Debug.Log("Moving");
    }
}



public class SecondNamedMoving : Moving
{
    private bool isFrist = true;

    public SecondNamedMoving(float speed, Rigidbody enemyRigidbody)
    {
        this.speed = speed;
        this.enemyRigidbody = enemyRigidbody;
    }


    public override void Move(GameObject enemy)
    {
        if (enemy.transform.position.z > 11)
        {
            enemyRigidbody.velocity = enemy.transform.forward * speed;
        }
        else if(enemy.transform.position.z <= 11)
        {
            if (isFrist)
            {
                enemyRigidbody.velocity = enemy.transform.right * -speed;
                isFrist = false;
            }
            else if (enemy.transform.position.x <= -4.5)
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