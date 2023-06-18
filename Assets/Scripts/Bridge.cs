using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Bridge : MonoBehaviour
{
    [SerializeField] private GameObject _fire;
    private Rigidbody[] _rigidbodies;
    private NavMeshObstacle _navMeshObstacle;
    private GameObject _player;
    private Potion _potion;


    private float _minForceValue = 150;
    private float _maxForceValue = 200;
    private bool _isPotionPickedUp;

    private void Awake()
    {
        _navMeshObstacle = GetComponent<NavMeshObstacle>();
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        _player = GameObject.Find("Player");
        _potion = FindObjectOfType<Potion>();
        _potion.onPotionPickedUp.AddListener(OnPotionPickedUp);

    }

    
    private void Update()
    {
        BridgeCollapse();
    }

    public void Break()
    {
        // Вырезаем отверстие в навмеш (чтобы игрок там больше не смог пройти)
        _navMeshObstacle.enabled = true;
        
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;

            // Генерируем случайную силу.
            var forceValue = Random.Range(_minForceValue, _maxForceValue);

            // Генерируем случайное направление.
            var direction = Random.insideUnitSphere;
            
            // Придаем силу каждому rigidbody.
            rigidbody.AddForce(direction * forceValue);
        }
    }

    private void BridgeCollapse()
    {
        {
            if ((_player.transform.position - _navMeshObstacle.transform.position).sqrMagnitude < 15f)
            {
                if (!_isPotionPickedUp)
                {
                    Break();
                }

                if (_isPotionPickedUp)
                {
                    FireOn();
                }
                
            }
        }
        
    }
    
    private void OnPotionPickedUp()
    {
        _isPotionPickedUp = true;
    }

    private void FireOn()
    {
        _fire.SetActive(_fire);
    }

}