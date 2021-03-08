using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] List<Rigidbody> ragdollElements = new List<Rigidbody>();
    [SerializeField] private float enemyMoveSpeed = 1f;
    [SerializeField] private float enemyRotate = -.5f;
    private Animator animator;

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
            transform.Rotate(0, enemyRotate, 0);
        }        
    }

    void DisableRagdoll()
    {
        foreach (Rigidbody rb in ragdollElements)
        {
            rb.isKinematic = true;
        }
    }

    public void EnableRagdoll()
    {
        foreach (Rigidbody rb in ragdollElements)
        {
            rb.isKinematic = false;
        }
    }
}
