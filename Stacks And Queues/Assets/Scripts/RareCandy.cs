using UnityEngine;

public class RareCandy : Item

{

    public RareCandy()
    {

        name = "Rare Candy";
        forWildPokemon = false;

    }



    public override void Execute()

    {

        if (target != null)

            target.SetLevel(target.GetLevel() + 1);

    }



    public override void Undo()

    {

        if (target != null && target.GetLevel() > 1)

            target.SetLevel(target.GetLevel() - 1);

    }

}
