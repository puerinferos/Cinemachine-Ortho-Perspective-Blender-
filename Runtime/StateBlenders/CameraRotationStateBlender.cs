using Unity.Cinemachine;
using UnityEngine;

namespace Puerinferos.Cinemachine.Blender
{
    public class CameraRotationStateBlender : IStateBlender
    {
        public void GetIntermediateState(ICinemachineCamera camFrom, ICinemachineCamera camTo, float t, ref CameraState finalState) =>
            finalState.RawOrientation = Quaternion.Slerp(camFrom.State.RawOrientation, camTo.State.RawOrientation, t);
    }
}