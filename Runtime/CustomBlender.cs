using System.Collections.Generic;
using Unity.Cinemachine;

namespace Puerinferos.Cinemachine.Blender
{
    public class CustomBlender : CinemachineBlend.IBlender
    {
        protected readonly List<IStateBlender> _stateBlenders = new List<IStateBlender>();
        
        public CustomBlender(params IStateBlender[] stateBlenders) =>
            _stateBlenders.AddRange(stateBlenders);

        public CameraState GetIntermediateState(ICinemachineCamera fromState, ICinemachineCamera toState, float t)
        {
            CameraState state = CameraState.Default;
            
            foreach (IStateBlender blender in _stateBlenders)
                blender.GetIntermediateState(fromState, toState, t, ref state);

            return state;
        }
    }
}