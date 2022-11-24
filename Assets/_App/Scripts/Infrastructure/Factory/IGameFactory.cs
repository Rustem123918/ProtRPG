using UnityEngine;

namespace _App.Scripts.Infrastructure.Factory
{
    public interface IGameFactory
    {
        GameObject CreateHero(GameObject at);
        void CreateHud();
    }
}
