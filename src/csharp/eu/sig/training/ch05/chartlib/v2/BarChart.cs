using System.Drawing;
using System.Windows.Forms;
using Rectangle = eu.sig.training.ch05.boardpanel.v2.Rectangle;

namespace eu.sig.training.ch05.chartlib.v2
{
    // tag::BarChart[]
    public class BarChart
    {
        private CategoryDataset dataset = CategoryDataset.DEFAULT;
        private CategoryAxis domainAxis = CategoryAxis.DEFAULT;
        private Rectangle graphArea = new Rectangle( new Point( 0, 0 ), 100, 100 );
        private CategoryPlot plot = CategoryPlot.DEFAULT;
        private ValueAxis rangeAxis = ValueAxis.DEFAULT;
        private CategoryItemRendererState state = CategoryItemRendererState.DEFAULT;

        public BarChart Draw( Graphics g )
        {
            // ..
            return this;
        }

        public CategoryDataset getDataset( )
        {
            return dataset;
        }

        public CategoryAxis getDomainAxis( )
        {
            return domainAxis;
        }

        public Rectangle getGraphArea( )
        {
            return graphArea;
        }

        public CategoryPlot getPlot( )
        {
            return plot;
        }

        public ValueAxis GetRangeAxis( )
        {
            return rangeAxis;
        }

        public CategoryItemRendererState GetState( )
        {
            return state;
        }

        public BarChart SetDataset( CategoryDataset dataset )
        {
            this.dataset = dataset;
            return this;
        }

        public BarChart setDomainAxis( CategoryAxis domainAxis )
        {
            this.domainAxis = domainAxis;
            return this;
        }

        public BarChart setGraphArea( Rectangle graphArea )
        {
            this.graphArea = graphArea;
            return this;
        }

        public BarChart setPlot( CategoryPlot plot )
        {
            this.plot = plot;
            return this;
        }

        public BarChart SetRangeAxis( ValueAxis rangeAxis )
        {
            this.rangeAxis = rangeAxis;
            return this;
        }

        // More getters and setters.

        // end::BarChart[]
        public BarChart setState( CategoryItemRendererState state )
        {
            this.state = state;
            return this;
        }
    }

    public class BarChartTest : Form
    {
        private CategoryDataset myDataset = null;
        private ValueAxis myValueAxis = null;
#pragma warning disable 219

        // tag::showMyBarChart[]
        private void ShowMyBarChart( )
        {
            Graphics g = this.CreateGraphics( );
            BarChart b = new BarChart( )
                .SetRangeAxis( myValueAxis )
                .SetDataset( myDataset )
                .Draw( g );
        }

        // end::showMyBarChart[]
#pragma warning restore 219
    }

    public class CategoryAxis
    {
        public const CategoryAxis DEFAULT = null;
    }

    public class CategoryDataset
    {
        public const CategoryDataset DEFAULT = null;
    }

    public class CategoryItemRendererState
    {
        public const CategoryItemRendererState DEFAULT = null;
    }

    public class CategoryPlot
    {
        public const CategoryPlot DEFAULT = null;
    }

    public class ValueAxis
    {
        public const ValueAxis DEFAULT = null;
    }
}