using UnityEngine;

namespace _App.Scripts.Infrastructure
{
    public class GameFactory : IGameFactory
    {
        private const string HeroPath = "Hero/Hero";
        private const string HudPath = "Hud/Hud";

        public GameObject CreateHero(GameObject at)
        {
            return Instantiate(HeroPath, at: at.transform.position);
        }

        public void CreateHud()
        {
            Instantiate(HudPath);
        }

        private GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        private GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
    }
}
