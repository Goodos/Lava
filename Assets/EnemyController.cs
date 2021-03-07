using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] List<Rigidbody> ragdollElements = new List<Rigidbody>();

    void Start()
    {
        DisableRagdoll();
    }

    void DisableRagdoll()
    {
        transform.Find("Dummy").GetComponent<Rigidbody>().isKinematic = true;
        foreach (Rigidbody rb in ragdollElements)
        {
            rb.isKinematic = true;
        }
    }

    public void EnableRagdoll()
    {
        transform.Find("Dummy").GetComponent<Rigidbody>().isKinematic = false;

        foreach (Rigidbody rb in ragdollElements)
        {
            rb.isKinematic = false;
        }
    }
}
