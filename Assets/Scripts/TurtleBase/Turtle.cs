using System.Collections.Generic;
using UnityEngine;

namespace TurtleBase
{
    public class Turtle {
        
        private Transform _transform;
        private readonly Stack<TurtleTransform> _stack = new();

        private readonly GameObject _fragment;
        private readonly GameObject _parent;
        private LineRenderer _line;

        public Turtle(Vector3 position, GameObject fragmentPrefab, GameObject parent)
        {
            _transform = new GameObject("Turtle").GetComponent<Transform>();
            _transform.position = position;
            _transform.rotation = Quaternion.identity;
            _fragment = fragmentPrefab;
            _parent = parent;
        }

        public void DrawLine(float delta)
        {
            _line = Object.Instantiate(_fragment, _parent.transform).GetComponent<LineRenderer>();
            _line.positionCount = 2;
            _line.SetPosition(0, _transform.position);
            
            _transform.Translate(_transform.forward * delta, Space.World);
            
            _line.SetPosition(1, _transform.position);
        }
    
        public void Translate(float delta) => _transform.Translate(_transform.forward * delta, Space.World);

        public void Rotate(float angle) => _transform.Rotate(_transform.up, angle, Space.World);

        public void Pitch(float angle) => _transform.Rotate(_transform.right, angle, Space.World);

        public void Roll(float angle) => _transform.Rotate(_transform.forward, angle, Space.World);

        public void TurnAround() => _transform.rotation = Quaternion.LookRotation(-_transform.forward);

        public void Push() => _stack.Push(new TurtleTransform(_transform.position, _transform.rotation));

        public void Pop()
        {
            var poppedTransform = _stack.Pop();
            _transform.position = poppedTransform.Position;
            _transform.rotation = poppedTransform.Rotation;
        }
        
        
    }
}