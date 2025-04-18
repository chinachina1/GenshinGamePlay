﻿using System;
using Nino.Core;
using UnityEngine;

namespace TaoTie
{
    [NinoType(false)]
    public partial class ConfigConditionByStateTime : ConfigCondition
    {
        [NinoMember(1)]
        public float Time;
        [NinoMember(2)]
        public bool IsNormalized;
        [NinoMember(3)]
        public CompareMode Mode;

        public override bool Equals(ConfigCondition other)
        {
            if (other is ConfigConditionByStateTime data)
            {
                return Time == data.Time && IsNormalized == data.IsNormalized && Mode == data.Mode;
            }

            return false;
        }
        public override ConfigCondition Copy()
        {
            return new ConfigConditionByStateTime()
            {
                Time = this.Time,
                IsNormalized = this.IsNormalized,
                Mode = this.Mode
            };
        }

        public override bool IsMatch(Fsm fsm)
        {
            float val;
            if (this.IsNormalized)
                val = fsm.StateNormalizedTime;
            else
                val = fsm.StateTime;

            switch (this.Mode)
            {
                case CompareMode.Equal:
                    return val == this.Time;
                case CompareMode.NotEqual:
                    return val != this.Time;
                case CompareMode.Greater:
                    return val > this.Time;
                case CompareMode.Less:
                    return val < this.Time;
                case CompareMode.LEqual:
                    return val <= this.Time;
                case CompareMode.GEqual:
                    return val >= this.Time;
                default:
                    break;
            }
            return false;
        }
    }
}