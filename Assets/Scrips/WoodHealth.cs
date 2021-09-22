using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class WoodHealth : MonoBehaviour
{
    public float Health = 50f;
    public UnityAction<GameObject> OnWoodDestroyed = delegate { };
    private bool _isHit = false;

    void OnDestroy()
    {
        if (_isHit)
        {
            OnWoodDestroyed(gameObject);
        }
    }

    public void setHit()
    {
        _isHit = true;
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Rigidbody2D>() == null) return;

        if (col.gameObject.tag == "Bird" || col.gameObject.tag == "Enemy")
        {
            //Hitung damage yang diperoleh
            float damage = col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10;
            Health -= damage;

            if (Health <= 0)
            {
                _isHit = true;
                Destroy(gameObject);
            }
        }
       
    }
}
