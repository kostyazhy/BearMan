using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    Transform _transform;
    public float speed = 10.0f;
    public int damage = 1;

    private void Start()
    {
        _transform = transform;
    }

    void Update()
    {
        _transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    { 
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null) { 
            Debug.Log("Player hit");
            player.Hurt(damage);
        }

        Destroy(gameObject);
    }
}




