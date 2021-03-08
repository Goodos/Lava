using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject armObj;
    private Data data;
    private Camera mainCamera;
    private MovementControler movementControler;
    private float fireRate = 0;
    private Quaternion startPoint = new Quaternion(0, 0, 0, 0);
    private bool armBool = false;
    private Vector3 armVec;

    void Start()
    {
        data = Resources.Load<Data>("Data");
        mainCamera = Camera.main;
        movementControler = GetComponent<MovementControler>();
        armVec = armObj.transform.position;
    }

    void Update()
    {
        if (fireRate <= 0)
        {
            if (!movementControler.canMove && Input.GetMouseButton(0))
            {
                GetComponent<CharacterController>().enabled = false;
                RaycastHit hit;
                if (!Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit, 1000))
                    return;
                if (!hit.transform)
                    return;
                if (hit.collider.tag != "Player")
                {
                    if (startPoint == new Quaternion(0, 0, 0, 0))
                        startPoint = Quaternion.LookRotation(hit.point);
                    float dir = Quaternion.Angle(startPoint, Quaternion.LookRotation(hit.point));
                    if (dir > 35f)
                    {
                        transform.LookAt(new Vector3(hit.point.x, hit.point.y + 2f, hit.point.z));
                        startPoint = Quaternion.LookRotation(hit.point);
                    }
                    else
                    {
                        armBool = true;
                        armVec = hit.point;
                    }
                    ClickToShoot(hit.point);
                    fireRate = data.FireRate();
                }
            }
        }
        fireRate -= Time.deltaTime;
        if (armBool)
        {
            armObj.transform.rotation = Quaternion.LookRotation(armVec, transform.up) * Quaternion.Euler(new Vector3(0, 80, 0));
        }
    }

    void ClickToShoot(Vector3 target)
    {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.position = armObj.transform.position;
        newProjectile.GetComponent<ProjectileController>().SetParameters(target, newProjectile);
    }
}
