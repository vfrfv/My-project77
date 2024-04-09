using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed = 3f;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _player.transform.position, _speed * Time.deltaTime);
    }
}
