using UnityEngine;
using System.Collections;

public class SphericalCoordinate
{
        public float radius;
        public float elevation;
        public float azimuth;
        public float minRadius = 3.0f;
        public float maxRadius = 5.0f;
        public float minElevation = 0;
        public float maxElevation = 85;
        public float minAzimuth = 0;
        public float maxAzimuth = 360;

        private readonly float _minAzimuth;
        private readonly float _maxAzimuth;
        private readonly float _minElevation;
        private readonly float _maxElevation;

        public SphericalCoordinate(Vector3 cartesianCoordinate)
        {
            _minAzimuth = minAzimuth * Mathf.Deg2Rad;
            _maxAzimuth = maxAzimuth * Mathf.Deg2Rad;
            _minElevation = minElevation * Mathf.Deg2Rad;
            _maxElevation = maxElevation * Mathf.Deg2Rad;

            Radius = cartesianCoordinate.magnitude;
            Azimuth = Mathf.Atan2(cartesianCoordinate.z, cartesianCoordinate.x);
            Elevation = Mathf.Asin(cartesianCoordinate.y / radius);
        }

        public float Radius
        {
            private set { radius = Mathf.Clamp(value, minRadius, maxRadius); }
            get { return radius; }
        }

        public float Azimuth
        {
            private set
            {
                azimuth = Mathf.Repeat(value, _maxAzimuth - _minAzimuth);
            }
            get { return azimuth; }
        }

        public float Elevation
        {
            private set
            {
                elevation = Mathf.Clamp(value, _minElevation, _maxElevation);
            }
            get { return elevation; }
        }

        public Vector3 ToCartesian
        {
            get
            {
                float t = radius * Mathf.Cos(Elevation);
                return new Vector3(t * Mathf.Cos(Azimuth), radius * Mathf.Sin(Elevation), t * Mathf.Sin(Azimuth));
            }
        }

        public void Rotate(float mouseX, float mouseY, float radius, float speed)
        {
            Azimuth += mouseX * Time.deltaTime * speed;
            Elevation += mouseY * Time.deltaTime * speed;
            Radius += radius * Time.deltaTime * speed * 20.0f;
        }
}
