using UnityEditor.Build;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private bool isFlying = false;
    [SerializeField] private float speed = 10f;

    public void SetIsFlying(bool fly)
    {
        isFlying = fly;
    }

    public bool GetIsFlying()
    {
        return isFlying;
    }

}
