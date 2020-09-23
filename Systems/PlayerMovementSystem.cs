using Unity.Entities;
using UnityEngine;

public class PlayerMovementSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        var deltaTime = Time.DeltaTime;

        Entities.ForEach((ref InputComponent inputComponent, ref MoveSpeedComponent moveSpeedComponent) =>
        {
            inputComponent.Horizontal = Input.GetAxis("Horizontal");
            inputComponent.Vertical = Input.GetAxis("Vertical");

            var direction = new Vector3(inputComponent.Horizontal, 0, inputComponent.Vertical);
            entity.Transform.Translate(direction * moveSpeedComponent.MoveSpeed * deltaTime);
        });
    }
}
