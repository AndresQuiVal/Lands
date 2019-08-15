using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lands.Helpers
{
    public class FilesHelper
    {
        public static byte[] ReadFully(Stream input) // method to send the image by the API (an array of bytes is required 
            //to pass the image by the API) to the backend proyect
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
