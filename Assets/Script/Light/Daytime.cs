using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GradientsTutorial
{
    [ExecuteInEditMode]
    public class Daytime : MonoBehaviour
    {
        [SerializeField] Gradient directionalLightGradient;
        [SerializeField] Gradient ambientLightGradient;

        [SerializeField, Range(1, 720)] float timeDayInSeconds = 720;
        [SerializeField, Range(0f, 1f)] float timeProgress = 0.5f;

        [SerializeField] Light dirLight;

        Vector3 defaultAngles;
        void Start() => defaultAngles = dirLight.transform.localEulerAngles;

        void Update()
        {
            if (Application.isPlaying)
                timeProgress += Time.deltaTime / timeDayInSeconds;  

            if (timeProgress > 1f)
                timeProgress = 0f;

            dirLight.color = directionalLightGradient.Evaluate(timeProgress);
            RenderSettings.ambientLight = ambientLightGradient.Evaluate(timeProgress);

            dirLight.transform.localEulerAngles = new Vector3(360f * timeProgress - 90, defaultAngles.x, defaultAngles.y);
        }
    }
}
