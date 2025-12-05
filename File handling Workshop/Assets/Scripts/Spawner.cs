using UnityEngine;
public interface ISpawn
{
    GameObject Spawn(GameObject caller);
}
public class Spawner : MonoBehaviour, ISpawn
{
    [SerializeField] private GameObject prefab;
    private FileManager fileManager = new FileManager();

    public virtual GameObject Spawn(GameObject caller) 
    {
        return Instantiate(prefab);
    }
}

public class UnitSpawner:Spawner
{
public void Spawn(GameObject caller)

{

    string randomName = fileManager.getInstance().GenerateRandomName();

    Vector3 randomPosition = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));

    GameObject unitObject = Instantiate(caller, randomPosition, Quaternion.identity);

    Unit unit = unitObject.GetComponent<Unit>();

    unit.Initialize(randomName, randomPosition);

}
}
