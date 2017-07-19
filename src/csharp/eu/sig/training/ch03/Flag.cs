using System.Collections.Generic;
using System.Drawing;

namespace eu.sig.training.ch03
{
    public class Flag
    {
        public IList<Color> Colors { get; }

        public Flag( params Color[ ] colors )
        {
            Colors = new List<Color>( colors );
        }
    }
}