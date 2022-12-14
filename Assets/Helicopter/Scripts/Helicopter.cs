using UnityEngine;

public class Helicopter : MonoBehaviour
{

    [SerializeField] private ParticleSystem _smokeAndFire;
    [SerializeField] private HelicopterRagdoll _helicopterRagdoll;

    private bool _isAdded = false;
    private float _duration = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<RocketTerrorist>(out RocketTerrorist rocketTerrorist))
        {
            _smokeAndFire.Play();
        }

        if (other.TryGetComponent<Graund>(out Graund graund))
        {
            if (!_isAdded)
            {
                _isAdded = true;
                Invoke(nameof(Instantiator), _duration);
            }
        }
    }

    private void Instantiator()
    {
        Instantiate(_helicopterRagdoll, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
