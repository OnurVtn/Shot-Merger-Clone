using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    void Update()
    {
        MoveBullet();
        DestroyBullet();
    }
   
    private void MoveBullet()
    {
        transform.position += Vector3.forward * Time.deltaTime * bulletSpeed;
    }

    private void DestroyBullet()
    {
        Destroy(this.gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrel"))
        {
            other.GetComponent<Barrel>().DecreaseHealth();
            Destroy(this.gameObject);
        }
    }
}
