using UnityEngine;
public interface ISpawner
{
    GameObject Spawn(GameObject caller);

}

public abstract class Spawner : MonoBehaviour, ISpawner
{
    [SerializeField] GameObject prefabToSpawn;

    public virtual GameObject Spawn(GameObject caller) => Instantiate(prefabToSpawn);
}
public class GroundSpawner : Spawner

{

    private int numSpawns = 0;


    public override GameObject Spawn(GameObject caller)

    {

        GameObject ground = base.Spawn(caller);

        ground.transform.position += new Vector3(0, 0, numSpawns * ground.transform.localScale.z);

        numSpawns++;

        return ground;

    }

}
