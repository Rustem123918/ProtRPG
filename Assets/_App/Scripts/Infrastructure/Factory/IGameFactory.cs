using _App.Scripts.Infrastructure.Services;
using UnityEngine;

namespace _App.Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject at);
        void CreateHud();
    }
}
