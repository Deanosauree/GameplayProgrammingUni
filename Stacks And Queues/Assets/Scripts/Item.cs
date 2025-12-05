using System.Windows.Input;
using UnityEngine;

public interface ICommand
{
    public void Execute();
    public void Undo();
}

public abstract class Item : MonoBehaviour, ICommand

{

    protected string name;

    protected Pokemon target;

    protected bool forWildPokemon;


    public bool IsForWiIsForWildPokemon()
    {
        return forWildPokemon;
    }


    public abstract void Execute();

    public abstract void Undo();



    public void SetTarget(Pokemon pokemon)

    {

        target = pokemon;

    }

    public bool IsForWildPokemon()
    {

        return forWildPokemon;

    }

    public string GetName()
    {

        return name;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<TrainerLogic>().GetInventory().Add(this);
            Destroy(this.gameObject);
        }
    }

}
