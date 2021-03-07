using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Vector3 directionVector;
    private float projectileSpeed = 1000f;
    private float hitForse;
    private Vector3 target;
    private GameObject projectile;        

    void Start()
    {
        hitForse = Resources.Load<Data>("Data").HitForse();
        Shoot();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target) <= .2f)
        {
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        directionVector = target - projectile.transform.position;
        if (directionVector.magnitude > 1)
        {
            directionVector = directionVector.normalized;
        }
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(directionVector * projectileSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().EnableRagdoll();
            other.transform.Find("Dummy").GetComponent<Rigidbody>().AddForce(-transform.forward * hitForse);            
        }
    }

    public void SetParameters(Vector3 _target, GameObject _projectile)
    {
        target = _target;
        projectile = _projectile;
    }
}
