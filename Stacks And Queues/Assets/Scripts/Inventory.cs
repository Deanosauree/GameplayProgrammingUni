using System.Collections.Generic;
using UnityEngine;

public class Inventory

{

    private Queue<Item> queue = new Queue<Item>();

    private Stack<Item> history = new Stack<Item>();



    public void Add(Item item)

    {

        queue.Enqueue(item);
        Debug.Log(item.GetName());

    }



    public bool TryUse(Pokemon target)

    {
        

        if (queue.Count == 0) return false;



        bool targetIsWild = !target.GetIsCaught();

        Item item = queue.Peek();
        Debug.Log($"TryingToUse {item.GetName()}");



        // If item type doesn't match target type ? cycle 

        if (item.IsForWildPokemon() && !targetIsWild ||

            !item.IsForWildPokemon() && targetIsWild)

        {

            queue.Enqueue(queue.Dequeue());

            return false;

        }



        // Valid usage 

        item = queue.Dequeue();

        item.SetTarget(target);

        item.Execute();

        history.Push(item);

        return true;

    }



    public void Undo()

    {

        if (history.Count == 0) return;



        Item last = history.Pop();

        last.Undo();

        queue.Enqueue(last);

    }

}
