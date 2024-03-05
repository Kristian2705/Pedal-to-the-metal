using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private float minX = -20f;

    [SerializeField]
    private float maxX = 20f;

    [SerializeField]
    private float minZ = 0f;

    [SerializeField]
    private float maxZ = 20f;

    private Transform transformCached;
    private float horizontalAxis;
    private float positionZ;

    // Start is called before the first frame update
    void Start()
    {
        transformCached = transform;
        positionZ = transformCached.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.IsAlive)
        {
            return;
        }

        horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalAxis, 0f, 0f);

        transformCached.Translate(movement * speed * Time.deltaTime);

        if (minX > transformCached.position.x)
        {
            transformCached.position = new Vector3(minX, transformCached.position.y, positionZ);
        }
        else if (maxX < transformCached.position.x)
        {
            transformCached.position = new Vector3(maxX, transformCached.position.y, positionZ);

        }
        if(minZ > transformCached.position.z)
        {
            transformCached.position = new Vector3(transformCached.position.x, transformCached.position.y, minZ);
        }

        // Rotation
        float targetAngle = horizontalAxis * 20;
        float progress = Mathf.Abs(horizontalAxis);
        float yAngle = Mathf.LerpAngle(transformCached.rotation.eulerAngles.y, targetAngle, progress);
        transformCached.rotation = Quaternion.Euler(0f, yAngle, 0f);
    }
}
