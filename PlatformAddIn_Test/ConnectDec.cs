using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace PlatformAddIn_Test
{
    class ConnectDec
    {
        //declaratie
        private static string _version = "v1.0.1";
        private static string _machine = Environment.MachineName;
        private static string _fullUsername = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        private static string _username_encoded = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(_fullUsername.Substring(10)));
        private static string _url = "http://localhost/Outlook_Plugin/index.php";

        private static string _plainText = "Hello, world!";
        private static string _passPhrase = "Pass5pr@se";
        private static string _saltValue = "s@1tValue";
        private static string _hashAlgorithm = "SHA1";
        private static int _passwordIterations = 2;
        private static string _initVector = "@1B2c3D4e5F6g7H8";
        private static int _keySize = 256;
        
        private string _cipherText = Security.Encrypt(_plainText, _passPhrase, _saltValue, _hashAlgorithm, _passwordIterations, _initVector, _keySize);

        private string _postData;
        private byte[] _byteArray;
        private byte[] _byteResult;
        private string _json_str;
        private dynamic _json_obj;

        /*private static string test = Security.Decrypt(_cipherText, _passPhrase, _saltValue, _hashAlgorithm, _passwordIterations, _initVector, _keySize);*/



        //toegankelijkheid

        // Get 
        public static string version { get { return _version; } }
        public static string machine { get { return _machine; } }
        public static string usernameEncoded { get { return _username_encoded; } }
        public static string url { get { return _url; } }
        public string cipherText { get { return _cipherText; } }
        public static string passPhrase { get { return _passPhrase; } }
        public static string saltValue { get { return _saltValue; } }
        public static string hashAlgorithm { get { return _hashAlgorithm; } }
        public static int passwordIterations { get { return _passwordIterations; } }
        public static string initVector { get { return _initVector; } }
        public static int keySize { get { return _keySize; } }

        // Get - Set
        public string postData
        {
            get { return _postData; }
            set { _postData = value; }
        }
        public byte[] byteArray
        {
            get { return _byteArray; }
            set { _byteArray = value; }
        }
        public byte[] byteResult
        {
            get { return _byteResult; }
            set { _byteResult = value; }
        }
        public string json_str
        {
            get { return _json_str; }
            set { _json_str = value; }
        }
        public dynamic json_obj
        {
            get { return _json_obj; }
            set { _json_obj = value; }
        }
    }
}
