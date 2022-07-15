using UnityEngineAssets.Helpers;
using UnityEngine;

namespace UnityEngineAssets.Scripts.Tools
{
    [DisallowMultipleComponent]
    [AddComponentMenu(ScriptHelpers.AddComponentMenuText.Components + "Target Framerate")]
    public class TargetFramerate : MonoBehaviour
    {
        [SerializeField] private int m_targetFramerate;

        private void Reset()
        {
            if (ScriptHelpers.HasInstanceInScene<TargetFramerate>(gameObject.scene, this)) DestroyImmediate(this);
        }

        private void OnValidate()
        {
            Application.targetFrameRate = m_targetFramerate;
        }
    }
}