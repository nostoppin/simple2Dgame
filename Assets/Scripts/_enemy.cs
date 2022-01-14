using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _enemy : MonoBehaviour
{
    public GameObject enemybullet;
    public GameObject enemyBulletSpawnPoint;
    GameObject[] enemyBulletArray;

    int enemyBulletPoolCount;

    float enemyBulletShotVelocity;
    float tankMoveSpeed;
    float tankMoveDir; // 0 : left, 1 : right.

    float enemyShotStartTime;
    float enemyHasShotTime;
    float enemyHasShotElapsedTime;
    float enemyShotInterval_Lifetime;

    void Start()
    {
        enemyBulletPoolCount = 10;
        enemyBulletShotVelocity = 4f;

        enemyBulletArray = new GameObject[enemyBulletPoolCount];
        m_initBulletPool();

        tankMoveSpeed = 1f;
        if(this.gameObject.name == "Tank")
        {
            tankMoveDir = 1f;
        }
        if (this.gameObject.name == "Tank1")
        {
            tankMoveDir = 0f;
        }

        enemyShotStartTime = Time.time;
        enemyShotInterval_Lifetime = 0.5f;
    }

    void Update()
    {
        m_tankMovement();

        enemyHasShotElapsedTime = Time.time - enemyShotStartTime;

        if (enemyHasShotElapsedTime > enemyShotInterval_Lifetime)
        {
            m_enemyShotController();
        }
    }

    void m_tankMovement()
    {
        if (tankMoveDir == 1)
        {
            this.transform.Translate(Vector2.right * tankMoveSpeed * Time.deltaTime);
            if (transform.position.x > 8f)
            {
                tankMoveDir = 0;
            }
        }
        if (tankMoveDir == 0)
        {
            this.transform.Translate(Vector2.left * tankMoveSpeed * Time.deltaTime);
            if (transform.position.x <= -8)
            {
                tankMoveDir = 1;
            }
        }
    }

    void m_initBulletPool()
    {
        for (int i = 0; i < enemyBulletPoolCount; i++)
        {
            enemyBulletArray[i] = Instantiate(enemybullet, 
                                              new Vector3(enemyBulletSpawnPoint.transform.position.x,
                                                        enemyBulletSpawnPoint.transform.position.y - 1f,
                                                        enemyBulletSpawnPoint.transform.position.z), 
                                                        Quaternion.identity);
            enemyBulletArray[i].SetActive(false);
        }
    }

    

    void m_enemyShotController()
    {
        for (int i = 0; i < enemyBulletPoolCount; i++)
        {
            if (!(enemyBulletArray[i].activeInHierarchy))
            {
                enemyBulletArray[i].SetActive(true);
                enemyBulletArray[i].GetComponent<Rigidbody2D>().AddForce(Vector2.down * enemyBulletShotVelocity, ForceMode2D.Impulse);
                enemyBulletArray[i].transform.position = enemyBulletSpawnPoint.transform.position - new Vector3(0f,0.8f,0f);

                //reset Time
                enemyShotStartTime = Time.time;
                break;
            }
        }
    }
}
