using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float force = 30;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector3 velocity = Vector3.zero;
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.W))
        {
            velocity.x += force;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            velocity.x -= force;
        } 
        if (Input.GetKeyDown(KeyCode.D))
        {
            velocity.y += force;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            velocity.y -= force;
        }

    }
}
