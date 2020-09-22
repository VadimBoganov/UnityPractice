using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class MoveSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation, ref MoveSpeedComponent moveSpeedComponent) =>
        {
            translation.Value.y += moveSpeedComponent.MoveSpeed * Time.DeltaTime;
            if (translation.Value.y > 5f)
                moveSpeedComponent.MoveSpeed =- math.abs(moveSpeedComponent.MoveSpeed);

            if (translation.Value.y < -5f)
                moveSpeedComponent.MoveSpeed =+ math.abs(moveSpeedComponent.MoveSpeed);
        });
    }
}
