
//    This file is part of Dynamical Systems Net.
//
//    Dynamical Systems Net is free software: you can redistribute it and/or modify
//    it under the terms of the GNU Lesser General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    Dynamical Systems Netis distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with Dynamical Systems Net.  If not, see <http://www.gnu.org/licenses/>.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace DynamicalSystemsNet.Core
{
    [DebuggerDisplay("{Name}")]
    public class DynamicalNode
    {
        public string Name
        {
            get;
            set;
        }

        public int HistorySize
        {
            get;
            set;
        }

        public IEnumerable<Complex> History
        {
            get
            {
                if (_history == null)
                {
                    return new Complex[] { this.Value };
                }
                else
                {
                    return _history;
                }
            }
        }

        /// <summary>
        /// Average magnitude over the history size.
        /// </summary>
        public double AverageMagnitude
        {
            get
            {
                return this.History.Average(v => (double?)v.Magnitude) ?? 0.0;
            }
        }

        public IList<NodeLink> IncomingNodes
        {
            get;
            protected set;
        }

        public Complex Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                if (this.HistorySize > 0)
                {
                    if (_history == null)
                    {
                        _history = new Queue<Complex>();
                    }

                    while (this.HistorySize <= _history.Count)
                    {
                        _history.Dequeue();
                    }

                    _history.Enqueue(value);
                }
            }
        }

        public DynamicalNode(double initialTime, Complex initialValue, string id = null)
        {
            this.Name = id ?? "Anonymous Node";
            this.IncomingNodes = new List<NodeLink>();
            this.Value = initialValue;
        }

        public bool AddIncomingNode(DynamicalNode node)
        {
            return AddIncomingNode(node, 1.0, 0, 0);
        }
        
        public bool AddIncomingNode(DynamicalNode node, Complex weight, double decay, double plasticity)
        {
            if (this.IncomingNodes.Any(link => link.From == node))
            {
                // Exists.
                return false;
            }

            this.IncomingNodes.Add(new NodeLink(this, node, weight, decay, plasticity));
            return true;
        }

        /// <summary>
        /// Function F for only this node (scalar return value).
        /// </summary>
        public virtual Complex F(double t, VectorOI y)
        {
            return 0.0;
        }


        private Complex _value;
        private Queue<Complex> _history;
    }
}
