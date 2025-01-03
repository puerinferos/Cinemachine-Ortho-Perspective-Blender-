using Unity.Cinemachine;
using UnityEngine;

namespace Puerinferos.Cinemachine.Blender
{
    [DisallowMultipleComponent]
    [AddComponentMenu("Cinemachine/Custom Cinemachine Blender")]
    public class CustomCinemachineBlender : MonoBehaviour
    {
        protected CinemachineBrain _brain;
        protected CustomBlender _customBlender;

        void Start()
        {
            if (TryGetComponent(out CinemachineBrain brain))
            {
                _brain = brain;

                Initialize();
                return;
            }

            CinemachineCore.CameraUpdatedEvent.AddListener(OnCameraUpdated);
        }

        protected void Initialize()
        {
            if (_brain == null)
                return;
            
            CinemachineCore.BlendCreatedEvent.AddListener(OnBlendCreated);
            _customBlender = new CustomBlender(new IStateBlender[]
            {
                new CameraPositionStateBlender(),
                new CameraRotationStateBlender(),
                new CameraLensStateBlender(_brain.OutputCamera)
            });
        }
        
        protected void OnCameraUpdated(CinemachineBrain brain)
        {
            if(_brain == null || _brain != brain)
                _brain = brain;

            Initialize();
            CinemachineCore.CameraUpdatedEvent.RemoveListener(OnCameraUpdated);
        }
        
        void OnBlendCreated(CinemachineCore.BlendEventParams evt)
        {
            if (evt.Origin == _brain as ICinemachineMixer)
                evt.Blend.CustomBlender = _customBlender;
        }
    }
}