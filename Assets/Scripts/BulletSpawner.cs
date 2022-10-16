using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    private float timer = 0;
    public static float delay;

    void Start()
    {
        delay = 2f;
    }

    void Update()
    {
        if(GameManager.Instance.IsGameStart() == true && GameManager.Instance.IsGameOver() == false)
        {
            CreateBullet();
        }       
    }

    private void CreateBullet()
    {
        if (!this.CompareTag("Collectable"))
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                timer = delay;
            }
        }      
    }   
}
