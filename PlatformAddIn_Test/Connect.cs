using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Outlook = Microsoft.Office.Interop.Outlook;
using Newtonsoft.Json;
using System.Net;
using System.Threading;
using Microsoft.Win32;

using System.Collections;

namespace PlatformAddIn_Test
{
    class Connect
    {
        public ConnectDec cd = new ConnectDec();
        public void nCheck(string _actie, Hashtable param = null) //link maken
        {
            
            //String verify_json = JsonConvert.SerializeObject(Connect.revalidate);

            cd.postData = "u=" + ConnectDec.usernameEncoded + "&t=" + ConnectDec.machine + "&client_version=" + ConnectDec.version + "&act=" + _actie;

            foreach (DictionaryEntry arg in param)
            {
                cd.postData += "&" + arg.Key + "=" + arg.Value;
            }

            /*if (Connect.Debug_inst.DebugConsoleState) //  && json_obj.debug != null
                Connect.Debug_inst.Add("PostData: " + this.postData);*/

            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                try
                {
                    wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");// Upload the input string using the HTTP 1.0 POST method.
                    wc.Headers.Add("Cache-Control", "no-cache");

                    cd.byteArray = System.Text.Encoding.ASCII.GetBytes(cd.postData);// this.byteResult = wc.UploadData(Init.url, "POST", this.byteArray);

                    cd.byteResult = wc.UploadData(ConnectDec.url, "POST", cd.byteArray);// Decode and display the result.

                    // checken
                    wc.CancelAsync();

                    cd.json_str = Encoding.ASCII.GetString(cd.byteResult);
                    cd.json_str = cd.json_str.Trim();

                    // dynamic = Json.Decode(json_str);
                    if ((cd.json_str.StartsWith("{") && cd.json_str.EndsWith("}")) || //For object
                        (cd.json_str.StartsWith("[") && cd.json_str.EndsWith("]"))) //For array
                    {
                        try
                        {
                            cd.json_obj = JsonConvert.DeserializeObject(cd.json_str);
                            //System.Windows.Forms.MessageBox.Show(Convert.ToString(cd.json_obj));
                            string test = Security.Decrypt(cd.cipherText, ConnectDec.passPhrase, ConnectDec.saltValue, ConnectDec.hashAlgorithm, ConnectDec.passwordIterations, ConnectDec.initVector, ConnectDec.keySize);
                            

                            //System.Windows.Forms.MessageBox.Show(test);
                        }
                        catch (FormatException fex)
                        {
                            /*if (Connect.Debug_inst.DebugConsoleState)
                                Connect.Debug_inst.Add("E 0x1 " + fex.Message + "\n" + this.json_str.ToString());*/
                            System.Windows.Forms.MessageBox.Show("Error");
                        }
                    }
                    else
                    {
                        /*if (Connect.Debug_inst.DebugConsoleState)
                            Connect.Debug_inst.Add("E 0x3 Server response is no valid JSON string: \n" + json_str);*/
                        System.Windows.Forms.MessageBox.Show("Error");
                    }
                }
                catch (WebException wex)
                {
                    /*if (Connect.Debug_inst.DebugConsoleState)
                        Connect.Debug_inst.Add("E 0x2 " + wex.Message);*/
                    System.Windows.Forms.MessageBox.Show("Error");
                }
                wc.Dispose();
            }
        }
    }
}
