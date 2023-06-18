using System;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator _animator;
    private GameObject _player;
    private GameObject _chest;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GameObject.Find("Player");
        _chest = GameObject.Find("Chest");
    }

    private void Update()
    {
        ChestOpen();
    }

    public void Open()
    {
        _animator.SetTrigger("open");
    }

    private void ChestOpen()
    {
        if ((_player.transform.position - _chest.transform.position).sqrMagnitude < 5f)
        {
            Open();
        }
    }
}