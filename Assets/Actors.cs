using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actors : MonoBehaviour, IVulnerable{
    protected Rigidbody rig;

    // Use this for initialization
    void Awake () {
        rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Function();
	}

    protected abstract void Function();

    public virtual void DamageTaken()
    {
        Destroy(gameObject);
    }
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IVulnerable>() != null)
        {
            collision.gameObject.GetComponent<IVulnerable>().DamageTaken();
        }
    }
}
