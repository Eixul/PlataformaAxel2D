using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollect : MonoBehaviour
{
    BoxCollider2D _boxCollider;
    //SFXManager sfxManager;
    public int value;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        //sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }

    // Update is called once per frame
    public void Coger()
    {
        _boxCollider.enabled = false;
        Destroy(this.gameObject);
        //sfxManager.CogerMoneda();
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Contador.instance.IncreaseStars(value);
        }
    }
}
