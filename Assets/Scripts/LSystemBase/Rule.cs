using System;
using UnityEngine;

namespace LSystemBase
{
    [Serializable]
    public class Rule
    {
        [SerializeField] private char _char;
        [SerializeField] private string _RulePattern;
        public char Char => _char;
        public string RulePattern => _RulePattern;
    }
}