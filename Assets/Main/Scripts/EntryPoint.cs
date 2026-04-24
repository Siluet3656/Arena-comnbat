using Constants;
using Main.Scripts.Pooling;
using UnityEngine;
using Zenject;

namespace Main.Scripts
{
   public class EntryPoint : MonoBehaviour
   {
      private static EntryPoint _instance;
      
      private EnemyPool enemyPool;

      [Inject] 
      private void Construct(EnemyPool pool)
      {
         enemyPool = pool;
      }
      
      private void Awake()
      {
         if (_instance == null)
         {
            _instance = this;
            DontDestroyOnLoad(this);
         }
         else
         {
            Destroy(gameObject);
         }
         
         CMS.Init();

         for (int i = 0; i < 5; i++)
         {
            enemyPool.Spawn(new EnemySpawnParams
            {
               Position = new Vector3(0, 10, 0),
               EnemyTypeId = Models.Enemy1
            });
         }
      }
   }
}
