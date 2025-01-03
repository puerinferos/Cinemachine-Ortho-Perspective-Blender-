using Unity.Cinemachine;

namespace Puerinferos.Cinemachine.Blender
{
    public interface IStateBlender
    {
        public void GetIntermediateState(ICinemachineCamera camFrom, ICinemachineCamera camTo, float t, ref CameraState finalState);
    }
}