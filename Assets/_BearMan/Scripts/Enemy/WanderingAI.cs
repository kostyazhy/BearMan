using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    
    [SerializeField, Header("Оружие врага")] 
    private GameObject fireballPrefab;
    private GameObject _fireball;

    Transform _transform;
    public float speed = 3.0f; 
    public float obstacleRange = 5.0f;

    private bool _alive;

    private void Start()
    {
        _transform = transform;
        _alive = true;
    }

    void Update()
    {
        if (_alive)
            _transform.Translate(0, 0, speed * Time.deltaTime); 
        Ray ray = new Ray(_transform.position, _transform.forward); 
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit)) {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>()) { 
                if (_fireball == null) { 
                    _fireball = Instantiate(fireballPrefab) as GameObject; 
                    _fireball.transform.position =  transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                }
            }
            else if (hit.distance < obstacleRange) {
                float angle = Random.Range(-110, 110); 
                _transform.Rotate(0, angle, 0);
            }
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
