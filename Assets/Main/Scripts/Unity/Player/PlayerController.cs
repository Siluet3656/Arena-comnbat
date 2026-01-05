using Main.Scripts.Domain.Weapons;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Unity.Player
{
    public class PlayerController : MonoBehaviour
    {
        IWeapon _weapon;

        [Inject]
        public void Construct(IWeapon weapon)
        {
            _weapon = weapon;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
                _weapon.Fire();
        }
    }
}