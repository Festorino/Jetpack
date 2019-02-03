using Jetpack.Helpers;
using UnityEngine;

namespace Jetpack.Components
{
    /// <summary>
    /// Component for player game object
    /// </summary>
    public class Player : BaseGravitationalObject
    {
        /// <summary>
        /// How much velocity the jetpack generates
        /// </summary>
        [SerializeField]
        private float jetpackPower = 500;

        /// <summary>
        /// Planet the player is currently on
        /// </summary>
        private Planet currentPlanet;

        private void OnCollisionEnter(Collision collision)
        {
            currentPlanet = collision.collider.GetComponent<Planet>();

            // clear player velocity on collision to prevent bouncing
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        private void OnCollisionExit(Collision collision)
        {
            currentPlanet = null;
        }

        private void LateUpdate()
        {
            // if player is pressing spacebar, activate jetpack
            if (Input.GetKey(KeyCode.Space))
            {
                GetComponent<Rigidbody>().AddForce((transform.up.normalized) * jetpackPower, ForceMode.Acceleration);
            }

            // if player is not on a planet, calculate gravity from planets
            if (currentPlanet == null)
            {
                // todo: cache planets instead of calling very bad FindObjectsOfType every frame
                BaseGravitationalObject[] gravityObjects = FindObjectsOfType<BaseGravitationalObject>();

                foreach (BaseGravitationalObject item in gravityObjects)
                {
                    if (item == this) { continue; }

                    Vector3 direction = item.transform.position - transform.position;
                    float speed = GravityCalculator.ConvertNewtonsToVelocity(Mass, GravityCalculator.CalculateGravitationalForceBetweenObjects(Mass, item.Mass, Vector3.Distance(transform.position, item.transform.position)));

                    GetComponent<Rigidbody>().AddForce(direction.normalized * (speed / GravityCalculator.PlanetScale), ForceMode.Acceleration);
                }
            }
        }
    }
}