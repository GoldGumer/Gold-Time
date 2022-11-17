using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float followSpeed;
    [SerializeField] private float followDistance;

    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 lerpPos = new Vector3(player.position.x, player.position.y, transform.position.z);
        if (Mathf.Abs(Mathf.Abs(player.position.x) - Mathf.Abs(transform.position.x)) > followDistance || Mathf.Abs(Mathf.Abs(player.position.y) - Mathf.Abs(transform.position.y)) > followDistance)
        {
            transform.position = Vector3.Lerp(transform.position, lerpPos, followSpeed);
        }
    }
}
