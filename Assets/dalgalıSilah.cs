using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dalgalıSilah : MonoBehaviour
{

    public float damage;

    private void OnParticleCollision(GameObject other)
    {
        other.GetComponent<Enemy>().getDamage(damage);
        Debug.Log("vurdum");
    }
}
