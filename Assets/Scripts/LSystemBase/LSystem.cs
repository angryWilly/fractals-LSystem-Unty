using System;
using System.Collections.Generic;
using TurtleBase;
using UnityEngine;

namespace LSystemBase
{
    public class LSystem
    {
        private string _sentence;
        private Dictionary<char, string> _ruleset;
        private Dictionary<string, Action<Turtle>> _turtleCommands;
        
        private Turtle _turtle;
        private GameObject _fragmentPrefab;
        private GameObject _fragmentParent;
        private Vector3 _initialPosition;

        public LSystem(string axiom, Dictionary<char, string> ruleset, Dictionary<string, Action<Turtle>> turtleCommands,
            Vector3 initPos, GameObject fragmentPrefab, GameObject parentGameObject)
        {
            _sentence = axiom;
            _ruleset = ruleset;
            _turtleCommands = turtleCommands;
            _initialPosition = initPos;
            _fragmentPrefab = fragmentPrefab;
            _fragmentParent = parentGameObject;
        }

        public void DrawSystem()
        {
            _turtle = new Turtle(_initialPosition, _fragmentPrefab, _fragmentParent);

            foreach (var instruction in _sentence)     
            {
                if (_turtleCommands.TryGetValue(instruction.ToString(), out var command))
                {
                    command(_turtle);
                }
            }
        }

        public void GenerateSentence()
        {
            _sentence = IterateSentence(_sentence);
        }

        private string IterateSentence(string oldSentence)
        {
            var newSentence = string.Empty;

            foreach (var ch in oldSentence)   
            {
                if (_ruleset.TryGetValue(ch, out var replacement))
                {
                    newSentence += replacement;
                }
                else
                {
                    newSentence += ch;
                }
            }

            return newSentence;
        }
    }
}