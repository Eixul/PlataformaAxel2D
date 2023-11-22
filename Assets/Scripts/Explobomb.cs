using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explobomb : MonoBehaviour
{
    [SerializeField] private float radio;
    [SerializeField] private float fuerzaExplosion;

    
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Explosion();
        }
    }
    
    public void Explosion()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radio);

        foreach(Collider2D collider in objetos)
        {
            Rigidbody2D rB2D = collider.GetComponent<Rigidbody2D>();
            if(rB2D != null)
            {
                Vector2 direction = collider.transform.position - transform.position;
                float distancia = 1 + direction.magnitude;
                float fuerzaFinal = fuerzaExplosion / distancia;
                rB2D.AddForce(direction * fuerzaFinal);
            }
        }

        Destroy(gameObject);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
