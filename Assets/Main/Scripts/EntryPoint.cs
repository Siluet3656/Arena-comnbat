using UnityEngine;

namespace Main.Scripts
{
   public class EntryPoint : MonoBehaviour
   {
      private static EntryPoint _instance;
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
      }
   }
}
