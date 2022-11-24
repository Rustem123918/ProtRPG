using _App.Scripts.Infrastructure.Services;
using UnityEngine;

namespace _App.Scripts.Infrastructure.AssetManagement
{
    public interface IAssets : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}