using System.Collections;
using UnityEngine;

public class PowerupManager : MonoBehaviour

{


    private IPowerup current;

    private Coroutine activeRoutine;
    private PlayerStats stats;
    private Rigidbody rb;

    private void Start()
    {
        stats = GetComponent<PlayerStats>();
        rb = GetComponentInChildren<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (stats.GetIsFlying() && current is Fly fly)

        {

            rb.AddForce(Vector3.up * fly.GetFlyForce(), ForceMode.Acceleration);

        }
    }

    public void ActivatePowerUp(Powerup newPowerUp)

    {

        // Stop previous coroutine if a power-up was already active

        if (activeRoutine != null)

        {

            StopCoroutine(activeRoutine);

            current?.Deactivate(stats);

        }


        current = newPowerUp;

        activeRoutine = StartCoroutine(RunPowerUp(newPowerUp));

    }


    private IEnumerator RunPowerUp(Powerup powerUp)

    {

        // Tell the powerup to activate

        powerUp.Activate(stats);

        powerUp.gameObject.SetActive(false);


        // Wait for its duration

        yield return new WaitForSeconds(powerUp.GetDuration());


        // Deactivate and clear reference

        powerUp.gameObject.SetActive(true);

        powerUp.Deactivate(stats);

        current = null;

        activeRoutine = null;

    }

}