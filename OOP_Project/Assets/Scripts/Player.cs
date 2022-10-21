using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _health = 100f;
    private float speed = 200;
    private Rigidbody rig;

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
        
    }

    private void FixedUpdate()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        rig.velocity = new Vector3(xMove, rig.velocity.y, zMove) * speed * Time.deltaTime;

        // Shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        }
    }   
}
