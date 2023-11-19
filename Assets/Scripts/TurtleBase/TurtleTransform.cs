using UnityEngine;

namespace TurtleBase
{
    public class TurtleTransform
    {
        public Vector3 Position { get; }
        public Quaternion Rotation { get; }

        public TurtleTransform(Vector3 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }
    }
}