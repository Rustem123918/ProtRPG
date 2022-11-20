using UnityEngine;

namespace _App.Scripts.Services.Input
{
    public interface IInputService
    {
        Vector2 Axis { get; }

        bool IsAttackButtonUp();
    }
}
