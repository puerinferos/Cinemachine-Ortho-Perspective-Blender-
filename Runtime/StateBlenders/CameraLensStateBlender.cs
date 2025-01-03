using Unity.Cinemachine;
using UnityEngine;

namespace Puerinferos.Cinemachine.Blender
{
    public class CameraLensStateBlender : IStateBlender
    {
        private const int MatrixSize = 16;

        private readonly float _aspect = (float)Screen.width / (float)Screen.height;
        private readonly Camera _camera;

        public CameraLensStateBlender(Camera camera)
        {
            _camera = camera;
        }

        public void GetIntermediateState(ICinemachineCamera camFrom, ICinemachineCamera camTo, float t,
            ref CameraState finalState)
        {
            Matrix4x4 firstMatrix = GetMatrixFromLens(camFrom);
            Matrix4x4 secondMatrix = GetMatrixFromLens(camTo);
            
            _camera.projectionMatrix = MatrixLerp(firstMatrix, secondMatrix, t);
        }
        
        private Matrix4x4 MatrixLerp(Matrix4x4 from, Matrix4x4 to, float time)
        {
            Matrix4x4 lerpedMatrix = new Matrix4x4();
            for (int i = 0; i < MatrixSize; i++)
                lerpedMatrix[i] = Mathf.Lerp(from[i], to[i], time);

            return lerpedMatrix;
        }
        
        private Matrix4x4 GetMatrixFromLens(ICinemachineCamera camera)
        {
            LensSettings lensSettings = camera.State.Lens;
            float orthographicSize = lensSettings.OrthographicSize;

            if (lensSettings.ModeOverride == LensSettings.OverrideModes.Orthographic)
            {
                return Matrix4x4.Ortho(-orthographicSize * _aspect, orthographicSize * _aspect, -orthographicSize,
                    orthographicSize, lensSettings.NearClipPlane, lensSettings.FarClipPlane);
            }

            return Matrix4x4.Perspective(lensSettings.FieldOfView, _aspect, lensSettings.NearClipPlane,
                lensSettings.FarClipPlane);
        }
    }
}