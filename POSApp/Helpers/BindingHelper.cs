using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSApp.Helpers
{
    public class BindingHelper
    {
        public static void HapusBinding(Form myForm)
        {
            foreach (var ctr in myForm.Controls)
            {
                if (ctr is TextBox)
                {
                    var myTxt = ctr as TextBox;
                    myTxt.DataBindings.Clear();
                }
            }
        }
    }
}
