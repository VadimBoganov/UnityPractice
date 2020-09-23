using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Mesh _mesh;
    [SerializeField] private Material _material;
    public void Start()
    {
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        EntityArchetype entityArchetype = entityManager.CreateArchetype(
            typeof(InputComponent),
            typeof(MoveSpeedComponent),
            typeof(Translation)
        );

        var entity = entityManager.CreateEntity(entityArchetype);
        entityManager.SetComponentData(entity, new InputComponent());
        entityManager.SetComponentData(entity, new MoveSpeedComponent { MoveSpeed = 5f });
    }
}
