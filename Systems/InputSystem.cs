using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class InputSystem : ComponentSystem
{
    private struct Data
    {
        public int Lenght;
        public ComponentArray<InputComponent> InputComponents;
    }

    [Inject] Data _data;

    protected override void OnUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        
        for(var i = 0; i < _data.Lenght; i++)
        {
            _data.InputComponents[i].Horizontal = horizontal;
            _data.InputComponents[i].Vertical = vertical;
        }
    }
}
