using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public bool hit;
    public ParticleSystem effect;
    // Start is called before the first frame update
    void Start()
    {
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hit = true;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (hit)
        {
            effect.Play();
            GameManager.Instance.playerLife--;
        }
    }
}
