using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class Game : MonoBehaviour
{
    public void Start()
    {
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        EntityArchetype entityArchetype = entityManager.CreateArchetype(
            typeof(Translation),
            typeof(InputComponent),
            typeof(MoveSpeedComponent)
        );

        var entity = entityManager.CreateEntity(entityArchetype);
        entityManager.SetComponentData(entity, new MoveSpeedComponent { MoveSpeed = 5f });
    }
}
