using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class PlayerMovementSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        var deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Translation translation, ref InputComponent inputComponent, ref MoveSpeedComponent moveSpeedComponent) =>
        {
            inputComponent.Horizontal = Input.GetAxis("Horizontal");
            inputComponent.Vertical = Input.GetAxis("Vertical");

            var direction = math.normalizesafe(new Vector3(inputComponent.Horizontal, 0, inputComponent.Vertical));
            translation.Value += direction * moveSpeedComponent.MoveSpeed * deltaTime;
        });
    }
}
