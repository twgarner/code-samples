using MoreMountains.TopDownEngine;
using MoreMountains.Tools;
using UnityEngine;

public class CharacterShockwave : CharacterAbility
{
    [Header("Shockwave Settings")]
    public float CooldownDuration = 3f;
    public float Radius = 2f;
    public int Damage = 20;
    public KeyCode ActivationKey = KeyCode.F;
    public LayerMask TargetLayers;

    private float _lastUsedTime = -999f;

    protected override void Initialization()
    {
        base.Initialization();
    }

    protected override void HandleInput()
    {
        if (Input.GetKeyDown(ActivationKey) && Time.time - _lastUsedTime >= CooldownDuration)
        {
            TriggerShockwave();
        }
    }

    protected void TriggerShockwave()
    {
        _lastUsedTime = Time.time;

        // Optional: Add animation or feedback here

        Collider2D[] hits = Physics2D.OverlapCircleAll(_controller.transform.position, Radius, TargetLayers);
        foreach (var hit in hits)
        {
            Health enemyHealth = hit.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.Damage(Damage, gameObject, 0f, 0f, Vector3.zero);
            }
        }

        MMFeedbacks?.PlayFeedbacks();
    }

    // Optional: Visualize shockwave range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
