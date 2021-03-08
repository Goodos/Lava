using UnityEngine;

public class MovementControler : MonoBehaviour
{
    private CharacterController cc;
    private Animator animator;
    private Vector3 targetPosition;
    private Vector3 directionVector;
    private Vector3 targetToMove;
    private Camera mainCamera;
    private float speed = 10f;
    public bool canMove = true;

    void Start()
    {
        speed = Resources.Load<Data>("Data").MoveSpeed();
        mainCamera = Camera.main;
        targetToMove = transform.position;
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (canMove && Input.GetMouseButton(0))
        {
            ClickToMove();
        }
        if (canMove)
        {
            Movement(targetToMove);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "FirePlace")
        {
            animator.SetBool("toRun", false);
            animator.SetBool("toShoot", true);
            canMove = false;
            
        }
    }

    void ClickToMove()
    {
        RaycastHit hit;
        if (!Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit, 100))
            return;
        if (!hit.transform)
            return;
        if (hit.collider.tag != "Player" && hit.collider.tag != "Enemy")
        {
            targetToMove = hit.point;
            animator.SetBool("toRun", true);
            transform.LookAt(targetToMove);
        }
    }

    void Movement(Vector3 target)
    {
        targetPosition = target;
        directionVector = target - transform.position;
        if (directionVector.magnitude > 1)
        {
            directionVector = directionVector.normalized;
        }
        cc.Move(directionVector * Time.deltaTime * speed);
        Vector3 diff = targetPosition - transform.position;
        if (diff.magnitude < .1f)
        {
            animator.SetBool("toRun", false);
            transform.position = targetPosition;
        }
    }
}
