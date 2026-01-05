using UnityEngine;

namespace Main.Scripts.Domain.Weapons
{
    public class Gun : IWeapon
    {
        public void Fire()
        {
            Debug.Log("Bang");
        }
    }
}