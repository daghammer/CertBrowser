using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.DirectoryServices.Protocols;
using System.Diagnostics;

namespace CertBrowser
{
    class CertWrapper
    {
        X509Certificate cert
            ;

        public CertWrapper(X509Certificate c)
        {
            cert = c;
        }

        public String ToString()
        {
            return cert.ToString(false);
        }



    }
}
