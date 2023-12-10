using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using func_lab3;
using System.Collections;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;

namespace func_lab3
{
    // Used as return type from method
    public abstract class Option<T>
    {
        // Could contain the value if Some, but not if None
        public abstract T Value { get; }

        public abstract bool IsSome { get; }

        public abstract bool IsNone { get; }
    }
    public sealed class Some<T> : Option<T>
    {
        private T value;
        public Some(T value)
        {
            // Setting Some to null, nullifies the purpose of Some/None
            if (value == null)
            {
                throw new System.ArgumentNullException("value", "Some value was null, use None instead");
            }

            this.value = value;
        }

        public override T Value { get { return value; } }

        public override bool IsSome { get { return true; } }

        public override bool IsNone { get { return false; } }
    }

    public sealed class None<T> : Option<T>
    {
        public override T Value
        {
            get { throw new System.NotSupportedException("There is no value"); }
        }

        public override bool IsSome { get { return false; } }

        public override bool IsNone { get { return true; } }
    }
}