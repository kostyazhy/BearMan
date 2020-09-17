using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    Text textScore;

    private int _score;

    void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit); 
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit); 
    }

    void Start()
    {
        _score = 0;
        textScore.text = "Score:" + _score.ToString();
    }

    private void OnEnemyHit()
    {
        _score += 1;
        textScore.text = "Score:" + _score.ToString();
    }

}
