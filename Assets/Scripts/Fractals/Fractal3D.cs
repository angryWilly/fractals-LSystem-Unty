using System;
using System.Collections.Generic;
using System.Linq;
using LSystemBase;
using TurtleBase;
using UnityEngine;

namespace Fractals
{
    public class Fractal3D : MonoBehaviour
    {
        [SerializeField] private GameObject _fragmentPrefab;
        [SerializeField] private string _axiom;
        [SerializeField] private List<Rule> _rule;
        [Range(0, 120)] [SerializeField] private float _angle;
        [Range(0.1f, 2f)] [SerializeField] private float _length;
        [Range(1, 8)] [SerializeField] private float _iterations;

        private LSystem _lSystem;
        private Dictionary<string, Action<Turtle>> _commands;
        private Dictionary<char, string> _ruleset;

        private void Start()
        {
            SetupCommands();
        
            _ruleset = _rule.ToDictionary(keySelector: rule => rule.Char,
                elementSelector: rule => rule.RulePattern);
        
            CreateLSystem(_ruleset);
        }

        private void CreateLSystem(Dictionary<char, string> ruleset)
        {
            _lSystem = new LSystem(_axiom, ruleset, _commands, transform.position, _fragmentPrefab, gameObject);

            for (var i = 0; i < _iterations; i++)
            {
                _lSystem.GenerateSentence();
            }
            _lSystem.DrawSystem();
        }

        private void SetupCommands()
        {
            var _commandsToSetup = new Dictionary<string, Action<Turtle>>
            {
                { "F", turtle => turtle.DrawLine(_length) },
                { "G", turtle => turtle.Translate(_length) },
                { "+", turtle => turtle.Rotate(_angle) },
                { "-", turtle => turtle.Rotate(-_angle) },
                { "^", turtle => turtle.Pitch(-_angle) },
                { "&", turtle => turtle.Pitch(_angle) },
                { @">", turtle => turtle.Roll(_angle) },
                { "<", turtle => turtle.Roll(-_angle) },
                { "|", turtle => turtle.TurnAround() },
                { "[", turtle => turtle.Push() },
                { "]", turtle => turtle.Pop() },
            };
  
            _commands = _commandsToSetup;
        }
    }
}