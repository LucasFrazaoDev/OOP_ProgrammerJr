using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rig;
    public GameObject projectilePrefab;
    public Transform firePoint;

    public float health;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        }
    }

    // Code clean later

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveFoward();
        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.S))
        {
            MoveBack();
        }
    }

    private void MoveFoward()
    {
        rig.AddForce(Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);
    }

    private void MoveBack()
    {
        rig.AddForce(Vector3.forward * -speed * Time.deltaTime, ForceMode.Impulse);
    }

    private void MoveLeft()
    {
        rig.AddForce(Vector3.left * speed * Time.deltaTime, ForceMode.Impulse);
    }

    private void MoveRight()
    {
        rig.AddForce(Vector3.right * speed * Time.deltaTime, ForceMode.Impulse);
    }
}
