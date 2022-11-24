using UnityEngine;

namespace _App.Scripts.Infrastructure
{
    public interface IGameFactory
    {
        GameObject CreateHero(GameObject at);
        void CreateHud();
    }
}
