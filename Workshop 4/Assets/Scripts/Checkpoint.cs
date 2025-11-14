using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.GetInstance().SpawnGround();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

