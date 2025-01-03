using Unity.Cinemachine;
using UnityEngine;

namespace Puerinferos.Cinemachine.Blender
{
    public class CameraPositionStateBlender : IStateBlender
    {
        public void GetIntermediateState(ICinemachineCamera camFrom, ICinemachineCamera camTo, float t, ref CameraState finalState) =>
            finalState.RawPosition = Vector3.Lerp(camFrom.State.RawPosition, camTo.State.RawPosition, t);
    }
}