using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private float _health = 100f;

    private Rigidbody rig;
    private float speed = 10;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    public float Health
    {
        get => _health;
        set => _health = value;
    }

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
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");
        rig.velocity = new Vector3(xMove * speed * Time.deltaTime, rig.velocity.y, zMove * speed * Time.deltaTime) * speed;
    }
}
