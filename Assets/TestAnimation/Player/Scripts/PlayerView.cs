using UnityEngine;
using Zenject;

namespace PetProject.Player
{
    public class PlayerView : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<PlayerView>
        { }
    }
}