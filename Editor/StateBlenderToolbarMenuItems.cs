using Unity.Cinemachine;
using UnityEngine;

namespace Puerinferos.Cinemachine.Blender.Editor
{
    static class StateBlenderToolbarMenuItems
    {
        [UnityEditor.MenuItem("Tools/Create State Blender")]
        public static void CreateStateBlender()
        {
            CinemachineBrain sceneBrain = Object.FindFirstObjectByType<CinemachineBrain>();
            
            if(sceneBrain == null)
            {
                Debug.LogError($"no cinemachine brain found in the scene!");
                return;
            }

            if (sceneBrain.GetComponent<CustomCinemachineBlender>())
            {
                Debug.LogWarning($"custom blender already exists in the scene!");
                return;
            }
            
            sceneBrain.gameObject.AddComponent<CustomCinemachineBlender>();
        }
    }
}