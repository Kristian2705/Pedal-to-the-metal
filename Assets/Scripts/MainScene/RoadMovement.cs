using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class RoadMovement : MonoBehaviour
{
    [SerializeField]
    private Renderer targetMaterialCached;

    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private int nextLevelMeters;

    [SerializeField]
    private IntEvent onUpdateScore = new IntEvent();

    [SerializeField]
    private UnityEvent OnUpdateLevels = new UnityEvent();


    public int Distance => (int)targetMaterialCached.material.mainTextureOffset.x;

    void Start()
    {
        StartCoroutine(CountLevelUp());
    }

    void Update()
    {
        if (Player.IsAlive)
        {
            targetMaterialCached.material.mainTextureOffset += new Vector2(Time.deltaTime * speed, 0);
            onUpdateScore.Invoke(Distance);
        }
    }

    private IEnumerator CountLevelUp()
    {
        while (Player.IsAlive)
        {
            yield return new WaitForSeconds(0.5f);
            if (Distance > 0f && Distance % nextLevelMeters == 0f)
            {
                OnUpdateLevels.Invoke();
            }
        }
    }
}
