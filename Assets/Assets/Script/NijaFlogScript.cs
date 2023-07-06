using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NijaFlogScript : AllyBasicMovement
{
    Animation _animation;

    void Start()
    {
        _speed = 5f;
        _stopDistance = 1;
        _damage = 10;
        _maxHealth = 50;
        Rigidbody2D _rb2d;
    }


}
