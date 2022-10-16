using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Barrel : MonoBehaviour
{
    private float barrelHealth;
 
    void Start()
    {
        GetHealth();
    }

    void Update()
    {
        DestroyBarrel();
    }

    private void GetHealth()
    {
        barrelHealth = int.Parse(GetComponentInChildren<TMP_Text>().text);
    }

    private void DestroyBarrel()
    {
        if(barrelHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void DecreaseHealth()
    {
        barrelHealth--;
        GetComponentInChildren<TMP_Text>().text = barrelHealth.ToString();
    }
}
