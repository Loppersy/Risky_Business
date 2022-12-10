using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risky_Business
{
    public class BodyModel
    {
        public string Client
        {
            get
            {
                return this.Client;
            }

            set
            {
                this.Client = value;
            }
        }
        public string URL
        {
            get
            {
                return URL;
            }

            set
            {
                URL = value;
            }
        }
        // set up properties based on needed body parameters

        public string MyProperty { get; set; }

        public int MyProperty { get; set; }


    }
}
