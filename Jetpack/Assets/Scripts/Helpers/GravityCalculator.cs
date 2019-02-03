namespace Jetpack.Helpers
{
    /// <summary>
    /// Class for handling newtonian gravity related calculations
    /// </summary>
    public static class GravityCalculator
    {
        public const float GravitationalConstant = 1;
        public const float PlanetScale = 1000000;

        /// <summary>
        /// Calculate gravitational force acting between two objects
        /// </summary>
        /// <param name="mass1">Mass of the first object in kilograms</param>
        /// <param name="mass2">Mass of the second object in kilograms</param>
        /// <param name="distance">Distance between the centers of mass of both objects in meters</param>
        /// <returns>Gravitational force acting between the two objects in Newtons</returns>
        public static float CalculateGravitationalForceBetweenObjects(float mass1, float mass2, float distance)
        {
            return GravitationalConstant * ((mass1 * mass2) / distance);
        }

        /// <summary>
        /// Convert gravitational force to velocity
        /// </summary>
        /// <param name="mass">Mass of object in kilograms</param>
        /// <param name="gravitationalForce">Gravitational force in Newtons</param>
        /// <returns>Velocity of object in meters per second</returns>
        public static float ConvertNewtonsToVelocity(float mass, float gravitationalForce)
        {
            return gravitationalForce / mass;
        }
    }
}