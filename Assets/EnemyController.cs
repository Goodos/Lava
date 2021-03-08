using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] List<Rigidbody> ragdollElements = new List<Rigidbody>();
    private Animator animator;

    private float enemyMoveSpeed = 1f;
    void Start()
    {
        DisableRagdoll();
        animator = GetComponent<Animator>();
        animator.SetBool("toRun", true);
    }

    private void Update()
    {
        if (animator.enabled)
        {
            transform.position += transform.forward * enemyMoveSpeed * Time.deltaTime;
            transform.Rotate(0, -.5f, 0);
        }        
    }

    void DisableRagdoll()
    {
        //transform.Find("Dummy").GetComponent<Rigidbody>().isKinematic = true;
        foreach (Rigidbody rb in ragdollElements)
        {
            rb.isKinematic = true;
        }
    }

    public void EnableRagdoll()
    {
        //transform.Find("Dummy").GetComponent<Rigidbody>().isKinematic = false;

        foreach (Rigidbody rb in ragdollElements)
        {
            rb.isKinematic = false;
        }
    }
}
