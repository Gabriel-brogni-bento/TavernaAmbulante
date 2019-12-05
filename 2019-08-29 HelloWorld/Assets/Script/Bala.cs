using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<Health>();
        if (health != null)
        {
            health.tomouDano(10);
        }

        Destroy(gameObject);
    }
}