using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace Sandbox
{
    internal class Transform2D
    {
        private Matrix3 _localMatrix = Matrix3.Identity;
        private Matrix3 _globalMatrix = Matrix3.Identity;

        private Matrix3 _localTranslation = Matrix3.Identity;
        private Matrix3 _localRotation = Matrix3.Identity;
        private Matrix3 _localScale = Matrix3.Identity;

        private Actor _owner;

        private Transform2D _parent;
        private Transform2D[] _children;

        private float _localRotationAngle;

        public Matrix3 LocalRotation
        {
            get { return _localRotation; }

            set
            {
                // set the _localrotation
                _localRotation = value;

                // set _localRotationAngle
                _localRotationAngle = (float)Math.Atan2(_localRotation.m01, _localRotation.m00);
            }
        }

        public Vector2 LocalPosition
        {
            get { return new Vector2(_localTranslation.m02, _localTranslation.m12); }

            set
            {
                _localTranslation.m02 = value.x;
                _localTranslation.m12 = value.y;
            }
        }

        public Vector2 GlobalPosition
        {
            get { return new Vector2(_globalMatrix.m02, _globalMatrix.m12); }
        }

        public Vector2 LocalScale
        {
            get { return new Vector2(_localScale.m00, _localScale.m11); }

            set
            {
                _localScale.m00 = value.x;
                _localScale.m11 = value.y;
            }
        }

        public Vector2 GlobalScale
        {
            get
            {
                Vector2 xAxis = new Vector2(_globalMatrix.m00, _globalMatrix.m10);
                Vector2 yAxis = new Vector2(_globalMatrix.m01, _globalMatrix.m11);

                return new Vector2(xAxis.Magnitude, yAxis.Magnitude);
            }
        }

        public Actor Owner
        {
            get { return _owner; }
        }

        public Vector2 Forward
        {
            get { return new Vector2(_globalMatrix.m00, _globalMatrix.m10); }
        }

        public Vector2 Right
        {
            get { return new Vector2(_globalMatrix.m10, _globalMatrix.m11); }
        }

        public float LocalRotationAngle
        {
            get { return _localRotationAngle; }
        }

        public float GlobalRotationAngle
        {
            get { return (float)Math.Atan2(_globalMatrix.m01, _globalMatrix.m00); }
        }

        // waogh thats a lotta variables !

        public Transform2D(Actor owner)
        {
            _owner = owner;
            _children = new Transform2D[0];
        }

        public void Translate(Vector2 direction)
        {
            LocalPosition += direction;
        }

        public void Translate(float x, float y)
        {
            LocalPosition += new Vector2(x, y);
        }

        public void AddChild(Transform2D child)
        {

        }

        public void RemoveChild(Transform2D child)
        {

        }

        public void UpdateTransform()
        {

        }
    }
}
