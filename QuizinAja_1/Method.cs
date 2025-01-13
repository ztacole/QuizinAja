using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizinAja_1
{
    internal class Method
    {
        public static User user;
        public static bool CheckEmptyField(Control ctrl)
        {
            foreach (TextBox i in ctrl.Controls.OfType<TextBox>())
            {
                if (i.Text ==string.Empty) return false;
            }
            return true;
        }
        public static bool ValidateCode(string code)
        {
            return new Regex(@"^(?=.*[A-Z])(?=.*[0-9]).{1,}$").IsMatch(code);
        }

        public static void ClearAllField(Control control)
        {
            foreach (TextBox tb in control.Controls.OfType<TextBox>()) tb.Clear();
            foreach (RadioButton rb  in control.Controls.OfType<RadioButton>()) rb.Checked = false;
        }
    }
}
