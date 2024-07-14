using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] private float _playerAwarenessDistance;

    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }
    private Transform _player;


    private void Awake()
    {

        _player = FindObjectOfType<CharacterController>().transform;

    }
    void Update()
    {

        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector;

        if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance)
        {

            AwareOfPlayer = true;

        }
        else
        {

            AwareOfPlayer = false;
        }
    }


#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _playerAwarenessDistance);
    }
#endif
}
