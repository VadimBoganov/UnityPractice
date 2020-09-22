using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Rendering;
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
            typeof(LevelComponent),
            typeof(Translation),
            typeof(RenderMesh),
            typeof(LocalToWorld),
            typeof(MoveSpeedComponent)
        );

        NativeArray<Entity> entities = new NativeArray<Entity>(5, Allocator.Temp);

        entityManager.CreateEntity(entityArchetype, entities);

        foreach (var entity in entities)
        {
            entityManager.SetComponentData(entity, new LevelComponent { Level = UnityEngine.Random.Range(10, 20) });
            entityManager.SetComponentData(entity, new MoveSpeedComponent { MoveSpeed = UnityEngine.Random.Range(1f, 3f) });
            entityManager.SetComponentData(entity, new Translation { Value = new float3(UnityEngine.Random.Range(-8f, 8f), UnityEngine.Random.Range(-5f, 5f), 0) });
            entityManager.SetSharedComponentData(entity, new RenderMesh
            {
                mesh = _mesh,
                material = _material
            });
        }

        entities.Dispose();

    }

    private JobHandle SomeTaskJob()
    {
        var job = new SomeJob();
        return job.Schedule();
    }

    private void Update()
    {
        NativeList<JobHandle> jobHandles = new NativeList<JobHandle>(Allocator.Temp);
        for(var i = 0; i < 10; i++)
        {
            JobHandle jobHandle = SomeTaskJob();
            jobHandles.Add(jobHandle);
        }
        JobHandle.CompleteAll(jobHandles);
        jobHandles.Dispose();
    }
}
