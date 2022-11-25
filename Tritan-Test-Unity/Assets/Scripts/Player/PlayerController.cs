using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Tritan.Utils;

namespace Tritan.Player
{
    public class PlayerController : Singleton<PlayerController>
    {
        [Header("Movement")]
        [SerializeField] private LayerMask _walkLayers;
        [SerializeField] private NavMeshAgent _agent;

        [Header("Stats")]
        [SerializeField] private float _initialWalkSpeed = 8f;
        [SerializeField] private float _minWalkSpeed = 0f;
        [SerializeField] private float _maxWalkSpeed = 50f;

        public float InitialWalkSpeed => _initialWalkSpeed;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.speed = _initialWalkSpeed;
        }

        private void OnValidate()
        {
            if(_initialWalkSpeed < _minWalkSpeed)
                _minWalkSpeed = _initialWalkSpeed;

            if(_initialWalkSpeed > _maxWalkSpeed)
                _maxWalkSpeed = _initialWalkSpeed;
        }

        private void Update()
        {
            if(Input.GetMouseButton(0))
                MovePlayer();
        }

        private void MovePlayer()
        {
            _agent.SetDestination(PlayerInput.Instance.GetWorldHitPoint(_walkLayers));
        }

        public void IncreaseSpeed(float amount)
        {
            if (_agent.speed == _maxWalkSpeed) return;

            if(amount + _agent.speed > _maxWalkSpeed)
                _agent.speed = _maxWalkSpeed;
            else
                _agent.speed += amount;

            EventManager.TriggerEvent(new SpeedIncrease(_agent.speed, amount));
        }

        public void DecreaseSpeed(float amount)
        {
            if (_agent.speed == _minWalkSpeed) return;

            if (_agent.speed - amount < _minWalkSpeed)
                _agent.speed = _minWalkSpeed;
            else
                _agent.speed -= amount;

            EventManager.TriggerEvent(new SpeedDecrease(_agent.speed, amount));
        }
    }
}