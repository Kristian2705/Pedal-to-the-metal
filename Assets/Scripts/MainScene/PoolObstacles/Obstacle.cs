using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class Obstacle : MonoBehaviour
{
    public int Speed = 10;

    [SerializeField]
    private float minX = -30f;

    [SerializeField]
    private float maxX = 30f;

    [SerializeField]
    private float deactivateZ = -50f;

    [SerializeField]
    private float spawnZ = 160f;

    [SerializeField]
    private int damage = 10;

    public int Damage => damage;

    private Transform transformCached;
    private GameObject gameObjectCached;

    public virtual void Awake()
    {
        transformCached = transform;
        gameObjectCached = gameObject;
    }

    void OnEnable()
    {
        transformCached.position = new Vector3(
            Random.Range(minX, maxX),
            0,
            spawnZ
        );

        transformCached.rotation = Quaternion.identity;
    }

    private void Update()
    {
        if (Player.IsAlive && gameObjectCached.activeSelf)
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime, Space.World);
            DeactivateAfterLimit();
        }
    }

    private void DeactivateAfterLimit()
    {
        if (transformCached.position.z <= deactivateZ)
        {
            gameObjectCached.SetActive(false);
        }
    }
}
