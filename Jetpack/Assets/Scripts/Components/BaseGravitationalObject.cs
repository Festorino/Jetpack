using UnityEngine;

namespace Jetpack.Components
{
    /// <summary>
    /// Base class for gravitational objects to inherit from
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public abstract class BaseGravitationalObject : MonoBehaviour
    {
        /// <summary>
        /// Mass of current object in kilograms
        /// </summary>
        public float Mass
        {
            get
            {
                return GetComponent<Rigidbody>().mass;
            }
            set
            {
                GetComponent<Rigidbody>().mass = value;
            }
        }
    }
}