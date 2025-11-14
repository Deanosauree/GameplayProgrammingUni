using UnityEngine;

public class DestroyOnHidden : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
