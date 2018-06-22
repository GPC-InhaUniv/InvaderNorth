using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float tilt;
    [SerializeField]
    private Boundary boundary;
    [SerializeField]
    private Transform shotSpawn;
    [SerializeField]
    private float fireRate;
    private float nextFire;
    private AudioSource shotAudio;
    private GameObject bullet;
    private Rigidbody rigidbody;
    private Collider collider;



    void OnEnable()                  //활성화 시 호출되는 함수.
    {
        if (rigidbody != null)           //처음에는 실행 안되게
        {
            StartCoroutine(FirstMove());
            StartCoroutine(GetShotInput());
            StartCoroutine(GetTransferInput());
        }
    }

    void Start()
    {
        collider = GetComponent<MeshCollider>();
        rigidbody = GetComponent<Rigidbody>();
        shotAudio = GetComponent<AudioSource>();
        StartCoroutine(FirstMove());
        StartCoroutine(GetShotInput());
        StartCoroutine(GetTransferInput());
    }

    IEnumerator GetShotInput()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            if (StageController.IsGameClear)
                break;
            else
            {
                if (Input.GetButton("Fire1") && Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    bullet = ObjectPoolManager.ObjectPools.PlayerBulletPool.PopFromPool();
                    bullet.transform.position = shotSpawn.position;
                    bullet.SetActive(true);
                    shotAudio.Play();
                }
                yield return null;
            }
        }
        yield return null;
    }

    IEnumerator GetTransferInput()
    {
        float moveHorizontal = 0;
        float moveVertical = 0;
        yield return new WaitForSeconds(2);
        while (true)
        {
            if (StageController.IsGameClear)
            {
                rigidbody.velocity = Vector3.zero;
                rigidbody.rotation = Quaternion.Euler(Vector3.zero);
                break;
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                    moveHorizontal = -1;
                else if (Input.GetKey(KeyCode.RightArrow))
                    moveHorizontal = 1;
                else
                    moveHorizontal = 0;
                if (Input.GetKey(KeyCode.UpArrow))
                    moveVertical = 1;
                else if (Input.GetKey(KeyCode.DownArrow))
                    moveVertical = -1;
                else
                    moveVertical = 0;
                Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
                rigidbody.velocity = movement * speed;

                rigidbody.position = new Vector3
                (
                    Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
                    0.0f,
                    Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
                );
                rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
                yield return null;
            }
        }
        yield return null;
    }

    IEnumerator FirstMove()
    {
        collider.enabled = false;
        while (true)
        {
            gameObject.transform.Translate(Vector3.forward * 3f * Time.deltaTime);
            if (gameObject.transform.position.z >= -2)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(2);
        if (StageController.IsGameClear == false)
            collider.enabled = true;
        StopCoroutine(FirstMove());

    }

    public IEnumerator LastMove()    // 마지막 플레이어 이동 및 씬 전환.
    {
        Vector3 limitBackPosition = transform.position;
        bool canForword = false;
        if (limitBackPosition.z - 2 >= boundary.zMin)
            limitBackPosition.z -= 2;
        while (true)
        {
            if (canForword == false)
            {
                rigidbody.velocity += Vector3.back * 0.5f;
                if (limitBackPosition.z >= transform.position.z)
                    canForword = true;
            }
            else
                rigidbody.velocity += Vector3.forward * 1;

            if (transform.position.z > 18)
            {
                Destroy(GameObject.FindGameObjectWithTag("ObjectPool"));
                SceneManager.LoadScene("LobbyScene");
            }
            yield return null;
        }
    }

    public void OnClickedGameClearLobbyButton() //게임클리어 로비버튼 클릭 시.
    {
        StartCoroutine(LastMove());
    }

}