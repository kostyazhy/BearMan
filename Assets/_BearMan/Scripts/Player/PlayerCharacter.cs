using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private float _health;

    void Start()
    {
        _health = 5;
    }

    public void Hurt(float damage)
    {
        _health -= damage; 
        Debug.Log("Health: " + _health);
    }
}
