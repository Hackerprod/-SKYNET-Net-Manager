using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET
{
    public class ControlSorter
    {
        private static Dictionary<int, List<Control>> Childs = new Dictionary<int, List<Control>>();
        public static List<Control> SortControls(Control Parent)
        {
            Childs.Clear();
            List<int> Y_Coordenate = new List<int>();
            List<Control> SortResult = new List<Control>();
            List<Control> _childs = new List<Control>();


            foreach (Control child in Parent.Controls)
            {
                Y_Coordenate.Add(child.Location.Y);
                _childs.Add(child);
            }

            Y_Coordenate.Sort((c1, c2) => c1.CompareTo(c2));

            foreach (var Y in Y_Coordenate)
            {
                List<Control> XControls = _childs.FindAll(c => c.Location.Y == Y);
                foreach (var item in XControls)
                {
                    if (!SortResult.Contains(item))
                    {
                        SortResult.Add(item);
                    }
                    
                }
            }
            return SortResult;
        }
    }
}
