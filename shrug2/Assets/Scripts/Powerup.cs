using UnityEngine;
public interface IPowerup
{
    void Activate(PlayerStats stats);

    void Deactivate(PlayerStats stats);
}
public abstract class Powerup : MonoBehaviour, IPowerup
{
    protected PlayerStats stats;
    [SerializeField] protected float duration = 5f;
    public abstract void Activate(PlayerStats stats);
    public abstract void Deactivate(PlayerStats stats);

    public float GetDuration()
    {
        return duration;
    }

    protected void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponentInParent<PowerupManager>()?.ActivatePowerUp(this);
        }
    }
}



