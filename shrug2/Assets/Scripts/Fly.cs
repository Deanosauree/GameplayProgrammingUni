using UnityEngine;

public class Fly : Powerup
{
    [SerializeField] private float flyForce = 10f;

    public float GetFlyForce()
    {
        return flyForce;
    }

    public override void Activate(PlayerStats stats)
    {
        this.stats = stats;
        stats.SetIsFlying(true);
    }
    public override void Deactivate(PlayerStats stats)
    {
        this.stats = stats;
        stats.SetIsFlying(false);
    }
}
