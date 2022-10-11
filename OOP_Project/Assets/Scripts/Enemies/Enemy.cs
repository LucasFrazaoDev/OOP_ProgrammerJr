using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage;

    [SerializeField] private float speed = 3f;
    private Rigidbody enemyRig;
    private GameObject player;
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
            DamagePlayer();
        }
    }

    protected virtual void DamagePlayer()
    {
        Debug.Log("Peguei vc!");
        player.GetComponent<Player>().health -= 10;
    }
}
