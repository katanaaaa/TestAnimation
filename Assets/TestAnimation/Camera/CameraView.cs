using UnityEngine;
using Zenject;

namespace PetProject.Camera
{
    public class CameraView : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<CameraView>
        {
        }
    }
}