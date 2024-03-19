using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FreeDraw.Model
{
    [Serializable]
    public class AppGraphicPath : ISerializable
    {
        [NonSerialized]
        public GraphicsPath path = new GraphicsPath();

        public AppGraphicPath() { }

        public AppGraphicPath(GraphicsPath path)
        {
            this.path = path;
        }
        public AppGraphicPath(SerializationInfo info, StreamingContext context)
        {
            // float[] m = (float[])info.GetValue("matrix", typeof(float[]));
            // path = new Matrix(m[0], m[1], m[2], m[3], m[4], m[5]);
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //  info.AddValue("matrix", path.Elements, typeof(float[]));
        }

    }
}
