using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace PlatformAddIn_Test
{
    class Verzoeken
    {
        public void Bladeren(int _folder_id)
        {
            // titelbalk
            Init.f.StartForm();

            // aantal rijen in tabel declareren
            int _Rijen = 0;

            // verzameling van info 
            Hashtable param = new Hashtable(); 
            param.Add("folder_id", _folder_id);

            // connectie met de connect-class
            Connect c = new Connect(); 
            c.nCheck("file_import", param);

            // parent folder doorgeven
            int _Parent = Convert.ToInt32(c.cd.json_obj.parent_folder); 
            Init.f.Parent = _Parent;

            //checken of omhoogknop nodig is
            if (c.cd.json_obj.current_folder != 0)
            {
                Init.f.ButtonOmhoog.Visible = true;
                Init.f.ButtonOmhoog.Enabled = true;
            }

            // folders overlopen
            foreach (dynamic folder in c.cd.json_obj.folder_arr)
            {
                int _id = Convert.ToInt32(folder.folder_id);
                string _Naam = Convert.ToString(folder.folder_name);
                _Rijen++;

                Init.f.AddRow(_Rijen, _Naam, false, 0, "map", _id);              
            }

            //files overlopen
            foreach (dynamic file in c.cd.json_obj.file_arr)
            {
                int _id = Convert.ToInt32(file.file_id);
                decimal _size = file.file_size;
                string _Naam = Convert.ToString(file.file_name);
                string _Extentie = Convert.ToString(file.file_ext);
                _Rijen++;

                Init.f.AddRow(_Rijen, _Naam, true, _size, _Extentie, _id);
            }

            // functie uitvoeren
            Init.f.AutoCheck(_Rijen);
            //System.Windows.Forms.MessageBox.Show(Convert.ToString(c.cd.json_obj));
        }
    }
}
