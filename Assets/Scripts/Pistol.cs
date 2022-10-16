using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] private Transform finishLine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrel") || other.CompareTag("Saw"))
        {
            BreakPistol();

            if(transform.position.z > finishLine.position.z)
            {
                GameManager.Instance.OnGameFinished();
            }
            else
            {
                GameManager.Instance.OnGameFailed();
            }        
        }

        if (other.CompareTag("X10"))
        {
            GameManager.Instance.OnGameFinished();
        }
    }

    private void BreakPistol()
    {
        foreach (Transform child in transform)
        {
            if(child.GetComponent<Rigidbody>() == null && child.GetComponent<BoxCollider>() == null)
            {
                child.gameObject.AddComponent<Rigidbody>();
                child.gameObject.AddComponent<BoxCollider>();
            }         
        }
    }
}
