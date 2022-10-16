using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacker : MonoBehaviour
{
    private Transform stackerTransform;

    void Start()
    {
        stackerTransform = GameObject.FindGameObjectWithTag("Stacker").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            BulletSpawner.delay -= 0.132f;

            Stack(other);
        }
    }

    private void Stack(Collider collectable)
    {
        var collectableParentTransform = collectable.transform.parent.gameObject.transform;

        collectable.tag = "Untagged";
        collectable.isTrigger = true;
        collectable.transform.parent = stackerTransform;

        foreach (Transform child in collectableParentTransform)
        {
            child.SetParent(collectable.transform);
        }

        collectable.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);

        foreach (Transform child in collectable.transform)
        {
            if (child.GetComponent<BoxCollider>() != null)
            {
                child.tag = "Untagged";
                child.GetComponent<BoxCollider>().isTrigger = true;
                child.SetParent(stackerTransform);
            }
        }
    }
}
