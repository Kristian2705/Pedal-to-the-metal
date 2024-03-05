using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private FloatEvent onUpdateHealth = new FloatEvent();

    [SerializeField]
    private BooleanEvent onDeathParticleActivation = new BooleanEvent();

    [SerializeField]
    private BooleanEvent onDeathSoundActivation = new BooleanEvent();

    public static bool IsAlive { get; private set; }

    private int currentHealth;

    public void Awake()
    {
        IsAlive = true;
        UpdateHealth(maxHealth);
    }

    public void UpdateHealth(int value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
        if (currentHealth <= 0)
        {
            IsAlive = false;
            onDeathParticleActivation.Invoke(!IsAlive);
            onDeathSoundActivation.Invoke(!IsAlive);
        }

        onUpdateHealth.Invoke(currentHealth);
    }
}
