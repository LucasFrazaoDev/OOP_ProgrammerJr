using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rig;
    public float fireForce;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.AddForce(Vector3.forward * fireForce * Time.deltaTime, ForceMode.Impulse);
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Enemy"))
        {
            Destroy(target.gameObject);
        }
    }
}
