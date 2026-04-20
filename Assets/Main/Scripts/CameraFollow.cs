using UnityEngine;
using Zenject;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _cameraSpeed;
    
    private Transform target;

    [Inject]
    private void Construct(Player player)
    {
        target = player.transform;
    }
    
    private void Update()
    {
        Vector3 correctedPosition = target.transform.position + _offset;
        Vector3 difference = correctedPosition - transform.position;

        if (difference.magnitude > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, correctedPosition, _cameraSpeed * Time.deltaTime);
        }
    }
}
