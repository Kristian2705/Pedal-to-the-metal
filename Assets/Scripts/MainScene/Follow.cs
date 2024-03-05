using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset = new Vector3(0f, 0f, -10f);

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float smoothTime = 0.25f;

    private Vector3 velocity = Vector3.zero;
    private Transform transformCached;

    public void Start()
    {
        transformCached = transform;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(
            target.position.x + offset.x,
            target.position.y + offset.y,
            transformCached.position.z
            );
        transformCached.position = Vector3.SmoothDamp(transformCached.position, targetPosition, ref velocity, smoothTime);
        //transform.LookAt(target);
    }
}
