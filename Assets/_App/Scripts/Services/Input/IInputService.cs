using _App.Scripts.Infrastructure.Services;
using UnityEngine;

namespace _App.Scripts.Services.Input
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }

        bool IsAttackButtonUp();
    }
}
