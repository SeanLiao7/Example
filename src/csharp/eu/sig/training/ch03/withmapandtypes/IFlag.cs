using System.Collections.Generic;
using System.Drawing;

namespace eu.sig.training.ch03.withmapandtypes
{
    // tag::Flag[]
    public interface IFlag
    {
        IList<Color> Colors { get; }
    }

    // end::Flag[]
}