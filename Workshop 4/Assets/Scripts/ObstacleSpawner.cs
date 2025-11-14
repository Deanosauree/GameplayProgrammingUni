using UnityEngine;

public class ObstacleSpawner : Spawner

{

    public override GameObject Spawn(GameObject caller)

    {

        GameObject obstacle = base.Spawn(caller);

        // Adjust position relative to the ground

        float yPos = caller.transform.localScale.y / 2 + obstacle.transform.localScale.y / 2;

        obstacle.transform.position = caller.transform.position + new Vector3(0, yPos, 0);

        return obstacle;

    }

}
