using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Potion : MonoBehaviour
{
    public UnityEvent onPotionPickedUp;
    
    private GameObject _player;
    private Outline _outline;

    private void Awake()
    {
        _player = GameObject.Find("Player");
        _outline = _player.GetComponent<Outline>();
    }

    private void Update()
    {
        PickUpPotion();
    }

    public void PickUpPotion()
    {
        if ((_player.transform.position - transform.position).sqrMagnitude < 0.1f)
        {
            Destroy(gameObject);
            _outline.OutlineWidth = 2;
            _outline.OutlineColor = Color.red;
             onPotionPickedUp.Invoke();
        }
    }
    
}
