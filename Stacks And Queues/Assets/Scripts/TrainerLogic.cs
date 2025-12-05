using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TrainerLogic : MonoBehaviour

{

    private LinkedList<Pokemon> party;

    private Pokemon activePokemon;

    private Inventory inventory = new Inventory();
    private PlayerInput playerInput;
    private InputAction interactAction;
    private InputAction swapItemAction;
    private CharacterController characterController;
    [SerializeField] Camera playerCam;


    public Inventory GetInventory() {  return inventory; }
    public static TrainerLogic Instance { get; private set; }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        interactAction = playerInput.actions["Interact"];
        interactAction.started += interact;
        swapItemAction = playerInput.actions["SwapItem"];
        swapItemAction.started += switchItem;

    }

    public TrainerLogic()

    {

        party = new LinkedList<Pokemon>();

        Instance = this;

    }

    private void interact(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        Vector3 p1 = playerCam.transform.position;
        if (Physics.SphereCast(p1, characterController.radius * 0.2f, playerCam.transform.forward, out hit, 5))
        {
            Debug.DrawRay(p1, playerCam.transform.forward * 10, Color.green, 1, true);
            Pokemon traget = hit.collider.GetComponent<Pokemon>();
            if (traget != null) 
            {
                inventory.TryUse(traget);
            }
        }
    }

    private void switchItem(InputAction.CallbackContext context)
    {
        SwitchToNext();
    }


    public void AddPokemon(Pokemon p)

    {

        party.AddLast(p);



        if (activePokemon == null)

        {

            activePokemon = p;

        }

    }



    public void RemovePokemon(Pokemon p)

    {

        party.Remove(p);

        activePokemon = party.First?.Value;

    }



    public void SwitchToNext()

    {

        if (party.First == null) return;



        var node = party.Find(activePokemon);

        activePokemon = (node?.Next ?? party.First).Value;

        Debug.Log($"Switched to {activePokemon.GetName()}");

    }

    
}
