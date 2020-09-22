using Unity.Burst;
using Unity.Jobs;
using Unity.Mathematics;

[BurstCompile]
public struct SomeJob : IJob
{
    public void Execute()
    {
        float value = 0f;
        for (var i = 0; i < 50000; i++)
            value = math.exp10(math.sqrt(value));
    }
}
