using Unity.Entities;

[GenerateAuthoringComponent]
public struct InputComponent : IComponentData
{
    public float Horizontal;
    public float Vertical;
}
