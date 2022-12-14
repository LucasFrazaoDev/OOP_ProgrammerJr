using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRig;
    private GameObject player;

    [SerializeField] private float damage;
    [SerializeField] private float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRig = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRig.AddForce(lookDirection * speed);
    }

    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            DamagePlayer(damage);
        }
    }

    protected virtual void DamagePlayer(float dmg)
    {
        player.GetComponent<Player>().Health -= dmg;
    }
}
