using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Vector3 directionVector;
    private float projectileSpeed = 3000f;
    private float hitForse;
    private Vector3 target;
    private GameObject projectile;
    private Rigidbody rb;

    void Start()
    {
        hitForse = Resources.Load<Data>("Data").HitForse();
        Shoot();
    }

    void Shoot()
    {
        directionVector = target - projectile.transform.position;
        if (directionVector.magnitude > 1)
        {
            directionVector = directionVector.normalized;
        }
        rb = GetComponent<Rigidbody>();
        rb.AddForce(directionVector * projectileSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Animator>().enabled = false;
            other.gameObject.GetComponent<EnemyController>().EnableRagdoll();
            foreach (Transform transform in other.gameObject.GetComponentsInChildren<Transform>())
            {
                if (transform.GetComponent<Rigidbody>() != null)
                {
                    transform.GetComponent<Rigidbody>().AddRelativeForce(gameObject.transform.forward * 2000f);
                }
            }
        }
        if (other.gameObject.name != "Player")
        {
            Destroy(gameObject);
        }
    }

    public void SetParameters(Vector3 _target, GameObject _projectile)
    {
        target = _target;
        projectile = _projectile;
    }
}
