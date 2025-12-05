using UnityEngine;

public class PokeBall : Item

{

    public PokeBall()
    {

        name = "PokeBall";
        forWildPokemon = true;

    }



    public override void Execute()

    {

        if (target != null)
        {

            target.SetIsCaught(true);
            string targetName = target.GetName();
            Debug.Log($"Caught {targetName}");
        }
    }



    public override void Undo()

    {

        if (target != null && target.GetIsCaught())

            target.SetIsCaught(false);

    }

}

