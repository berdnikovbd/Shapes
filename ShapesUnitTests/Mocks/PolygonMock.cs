using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Shapes;
using Shapes.Primitives;

namespace ShapesUnitTests.Mocks
{
    public class PolygonMock : Polygon
    {
        public PolygonMock(params Point[] points) 
        {
            foreach (var point in points)
            {
                this.AddPoint(point);
            }

            this.Close();
        }
    }
}
