using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour

{

    private ISpawner[] spawners;

    [SerializeField] private int initialSpawnCount = 5;


    private int currentSpawnerIndex = 0;

    private static GameManager instance;

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void Awake()
    {
        instance = this;
    }

    void Start()

    {
        
        spawners = gameObject.GetComponentsInChildren<ISpawner>();
        Debug.Log(spawners.Length);
        Debug.Log("ThisPartWork?");
        // Spawn an initial sequence of ground and obstacles

        for (int i = 0; i < initialSpawnCount; i++)

        {

            SpawnGround();

        }

    }


    public void SpawnGround()

    {

        //Spawn grounds first

        List<GameObject> newGrounds = new List<GameObject>();


        foreach (ISpawner spawner in spawners)

        {

            
            if (spawner is GroundSpawner)

            {
                

                GameObject ground = spawner.Spawn(gameObject);

                newGrounds.Add(ground);

            }

        }


        // Spawn all other things onto each new ground

        foreach (GameObject ground in newGrounds)

        {

            foreach (ISpawner spawner in spawners)

            {

                if (spawner is not GroundSpawner)

                {

                    spawner.Spawn(ground);

                }

            }

        }

    }



}
