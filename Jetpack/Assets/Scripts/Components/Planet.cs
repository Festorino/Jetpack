using Jetpack.Helpers;
using UnityEngine;

namespace Jetpack.Components
{
    /// <summary>
    /// Component to handle physics for planet prefab
    /// </summary>
    [RequireComponent(typeof(Renderer))]
    public class Planet : BaseGravitationalObject
    {
        [Tooltip("Density in kg/m³")]
        [SerializeField]
        private float density = 5515.3f;

        private void Awake()
        {
            // calculate mass from radius & density
            Mass = density * (4 / 3 * Mathf.PI * Mathf.Pow(Radius, 3));
        }

        /// <summary>
        /// Radius of planet in meters
        /// </summary>
        public float Radius
        {
            get
            {
                return GetComponent<Renderer>().bounds.extents.magnitude * GravityCalculator.PlanetScale;
            }
        }
    }
}