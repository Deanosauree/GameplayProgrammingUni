using UnityEngine;

public class Memento
{
    public string name;
    public Vector3 position;

    public Memento(string name, Vector3 position)
    {
        this.name = name;
        this.position = position;
    }
}

public class Unit : MonoBehaviour

{

    private Memento state;


    public void Initialize(string unitName, Vector3 unitPosition)

    {

        state = new Memento(unitName, unitPosition);

        gameObject.name = unitName;

        transform.position = unitPosition;

    }


    public string Save()

    {

        return JsonUtility.ToJson(state);

    }


    public void Load(string savedData)

    {

        state = JsonUtility.FromJson<Memento>(savedData);

        gameObject.name = state.name;

        transform.position = state.position;

    }

}
