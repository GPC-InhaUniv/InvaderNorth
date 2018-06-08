using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//EvasiveManeuver: 회피 기동
public class EvasiveManeuver : MonoBehaviour {

    
    public float dodge;
    public Vector2 starWait;
    public Vector2 maneuverWait;
    public Vector2 maneuverTime;
    public Boundary boundary;
    public float smoothing;
    public float tilt;
    private Transform playerTransform;

    private float currentSpeed;
    private float targetManeuver;
    private Rigidbody rb;
    
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        
        currentSpeed = rb.velocity.z;
        StartCoroutine(Evade());
	}

    private IEnumerator Evade()//피하다.
    {
        yield return new WaitForSeconds(Random.Range(starWait.x, starWait.y));

        while(true)
        {
            targetManeuver = Random.Range(1,dodge) * -Mathf.Sign(transform.position.x);
            //targetManeuver = playerTransform.position.x; ///prefab asset인 enemy ship은 scene에 있는 player ship 인스턴스에 대한 참조를 보유 할 수 없다. 직접 찾아야 한다.
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }
	void FixedUpdate ()
    {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, 0.0f, boundary.zMax)
            );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
