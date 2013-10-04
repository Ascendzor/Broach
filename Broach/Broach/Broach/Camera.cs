using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Broach
{
    /// <summary>
    /// The direction as in lecture 19
    /// so it has bearing and elevation
    /// </summary>
    class Direction
    {
        private float bearing;
        private float elevation;

        /// <summary>
        /// get the direction vector, it is a unit vector, use the bearing and elevation interface to change direction
        /// </summary>
        public Vector3 DirectionVector
        {
            get
            {
                Vector3 forward = Vector3.Transform(new Vector3(0, 0, -1),
                    Matrix.CreateRotationX(elevation) * Matrix.CreateRotationY(bearing));
                Vector3 d = new Vector3(0, 0, 0) + forward;
                d.Normalize();
                return d;
            }
        }

        /// <summary>
        /// Angle (radians) direction it is pointing in the horizontal plane
        /// </summary>
        public float Bearing
        {
            get { return bearing; }
            set { bearing = value % MathHelper.TwoPi; }
        }

        /// <summary>
        /// Angle (radians) direction the camera is pointing in the vertical plane
        /// </summary>
        public float Elevation
        {
            get { return elevation; }
            set
            {
                if (value >= MathHelper.ToRadians(-80) && value <= MathHelper.ToRadians(80))
                {
                    elevation = value;
                }
            }
        }

        public override string ToString()
        {
            float compassBearing = MathHelper.ToDegrees(Bearing);
            if (compassBearing > 0)
            {
                compassBearing = 360 - compassBearing;
            }
            else
            {
                compassBearing = Math.Abs(compassBearing);
            }
            String cam = "Bearing: " + compassBearing + "\nElevation: " + MathHelper.ToDegrees(Elevation); return cam;
        }
    }

    class Camera
    {
        private Vector3 position;
        private Direction direction;

        public Camera()
        {
            direction = new Direction()
            {
                Bearing = 0f,
                Elevation = 0f
            };
        }

        /// <summary>
        /// The direction the camera is pointing
        /// </summary>
        public Direction Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        /// <summary>
        /// Position of the camera in world space
        /// </summary>
        public Vector3 Position
        {
            get { return position; }
            set { position = value; }
        }

        /// <summary>
        /// The view matrix, cannot be set
        /// </summary>
        public Matrix View
        {
            get
            {
                // from lecture slides
                Vector3 forward = Vector3.Transform(new Vector3(0, 0, -1),
                    Matrix.CreateRotationX(direction.Elevation) * Matrix.CreateRotationY(direction.Bearing));

                Matrix view = Matrix.CreateLookAt(position, position + forward, new Vector3(0, 1, 0));
                return view;
            }
            set
            {
                throw new Exception("can't set view matrix, you have to use position, bearing, elevation");
            }
        }

        public override String ToString()
        {
            return "Position: " + position + "\n" + direction.ToString();
        }
    }
}