using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<MovementControler>().canMove)
        {
            transform.position = new Vector3(player.transform.position.x, startPos.y, player.transform.position.z - 7f);
        }
    }
}
