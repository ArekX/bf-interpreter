/**
 *
 * Copyright (c) 2014 Aleksandar Panic
 *
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 * claim that you wrote the original software. If you use this software
 * in a product, an acknowledgment in the product documentation would be
 * appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not be
 * misrepresented as being the original software.
 * 
 * 3. This notice may not be removed or altered from any source
 * distribution.
**/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrainFuckInterpreter
{
    /// <summary>
    /// Class which represents debug window.
    /// </summary>
    public partial class DebugForm : Form
    {
        MainForm frm;
        public bool scroll = false;
        List<String> lines;
        List<int> PCs;

        /// <summary>
        /// Constructs new instance of debug form.
        /// </summary>
        /// <param name="frm">Instance of MainForm</param>
        public DebugForm(MainForm frm)
        {
            PCs = new List<int>();
            lines = new List<string>();
            this.frm = frm;
            InitializeComponent();
        }

        /// <summary>
        /// Activates when debug selection has changed.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void lstDebug_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scroll)
                frm.selectChar(PCs[lstDebug.SelectedIndex]);
        }

        /// <summary>
        /// Clears debug window list.
        /// </summary>
        public void clear()
        {
            lstDebug.Items.Clear();
            PCs.Clear();
        }

        /// <summary>
        /// Fills debug window list from lines.
        /// </summary>
        public void fillList()
        {
            foreach(string line in lines)
            {
                lstDebug.Items.Add(line);
            }
        }

        /// <summary>
        /// Adds new line.
        /// </summary>
        /// <param name="line">Line which will be added.</param>
        /// <param name="PC">Program counter which this line represents.</param>
        public void addLine(String line, int PC)
        {
            if (!frm.chkFillDebugEnd.Checked)
            {
                lstDebug.Items.Add(line);
                lstDebug.SelectedIndex = lstDebug.Items.Count - 1;
            }
            else
            {
                lines.Add(line);
            }

            PCs.Add(PC);
            
        }
    }
}
