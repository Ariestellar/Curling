using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStopper : MonoBehaviour
{
    [Range(0, 1)] [SerializeField] private float _speedStopped;
    [SerializeField] private bool _braking = true;
    [SerializeField] private Pusher _pusher;

    private Rigidbody _ridgidbodyCurrentCat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cat")
        {
            _ridgidbodyCurrentCat = other.gameObject.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_ridgidbodyCurrentCat && _braking)
        {
            _ridgidbodyCurrentCat.velocity = Vector3.Lerp(_ridgidbodyCurrentCat.velocity, Vector3.zero, _speedStopped);
            if (_ridgidbodyCurrentCat.velocity == Vector3.zero)
            {
                _braking = false;                
                LaunchPushingMechanism();
            }
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cat")
        {
            _ridgidbodyCurrentCat = null;
            _braking = true;
        }
    }

    private void LaunchPushingMechanism()
    {
        //если по x больше 6 то стоп
        _pusher.Launch();
    }
}
