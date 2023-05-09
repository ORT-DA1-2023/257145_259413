using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class HitRecord
    {
        public double t;
        public Vector intersection;
        public Vector normal;
        public Vector attenuation;

        public HitRecord()
        {
            this.t = 0;
            this.intersection = new Vector();
            this.normal = new Vector();
            this.attenuation = new Vector();
        }

        public HitRecord(double t, Vector intersection, Vector normal, Vector attenuation)
        {
            this.t = t;
            this.intersection = intersection;
            this.normal = normal;
            this.attenuation = attenuation;
        }
    }
}
