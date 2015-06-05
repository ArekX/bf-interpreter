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
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrainFuckInterpreter
{
    /// <summary>
    /// Main Form of Brainf**k interpreter
    /// </summary>
    public partial class MainForm : Form
    {
        ConsoleForm outputConsole;
        public DebugForm debug;
        Random rng;

        /// <summary>
        /// Constructs new main form.
        /// </summary>
        public MainForm()
        {
            rng = new Random();
            InitializeComponent();
        }

        /// <summary>
        /// Activates when key is pressed on form.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                btnRun_Click(null, null);

            if ((e.KeyCode == Keys.F10) 
                && (btnRun.Text == "Cancel (F10)") 
                && (outputConsole != null) 
                && !outputConsole.IsDisposed)
            {
                btnRun_Click(null, null);
            }
                

            if (e.KeyCode == Keys.F4)
                btnDebug_Click(null, null);
        }

        /// <summary>
        /// Activates when Run button is clicked.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (btnRun.Text == "Cancel (F10)")
            {
                outputConsole.cancelExecution();
                btnRun.Enabled = false;
                btnDebug.Enabled = false;
                txtInput.Enabled = false;
                chkEndIsNull.Enabled = false;
                return;
            }

            chkFillDebugEnd.Enabled = false;
            chkConstant.Enabled = false;
            nmMemorySize.Enabled = false;

            if ((debug != null) && !debug.IsDisposed)
            {
                debug.scroll = false;
                debug.clear();
                if (debug.Visible)
                    debug.TopMost = true;
            }
            
            if (outputConsole == null || outputConsole.IsDisposed)
                outputConsole = new ConsoleForm(this);

            outputConsole.executeCode(scnCode.Text, (int)nmMemorySize.Value);

            outputConsole.Show();
            outputConsole.Focus();

            scnCode.IsReadOnly = true;

            btnRun.Text = "Cancel (F10)";
        }

        /// <summary>
        /// Activates when Debug button is clicked.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnDebug_Click(object sender, EventArgs e)
        {
            if (debug == null || debug.IsDisposed)
                debug = new DebugForm(this);

            debug.Show();
            debug.Left = this.Right;
            debug.Top = this.Top;
            debug.Height = this.Height;
        }

        /// <summary>
        /// Finish the code and return control to form.
        /// </summary>
        public void programFinish()
        {
            btnRun.Text = "Run (F5)";
            btnRun.Enabled = true;
            btnDebug.Enabled = true;
            txtInput.Enabled = true;
            chkEndIsNull.Enabled = true;
            chkFillDebugEnd.Enabled = true;
            chkConstant.Enabled = true;
            nmMemorySize.Enabled = true;
            scnCode.IsReadOnly = false;
            if ((debug != null) && !debug.IsDisposed)
            {
                debug.scroll = true;
                if (chkFillDebugEnd.Checked)
                    debug.fillList();

                if (debug.Visible)
                    debug.TopMost = false;
            }
                


        }

        /// <summary>
        /// Selects one character in editor.
        /// </summary>
        /// <param name="PC">Index (Program Counter) of the character</param>
        public void selectChar(int PC)
        {
            scnCode.Selection.Start = PC;
            scnCode.Selection.Length = 1;
            scnCode.Scrolling.ScrollToCaret();
        }

        /// <summary>
        /// Returns one character from input as byte or
        /// random byte if null terminated checkbox is turned off.
        /// </summary>
        /// <param name="pointer">Pointer of the required input.</param>
        /// <returns>Byte or random byte or 0 byte if input text is out of bounds and null terminated is turned on.</returns>
        public byte getInputByte(int pointer)
        {
            if (pointer >= txtInput.Text.Length)
            {
                if (chkEndIsNull.Checked)
                {
                    return 0;
                }
                else
                {
                    return (byte)rng.Next(255);
                    
                }
            }

            return (byte)txtInput.Text[pointer];
        }

        /// <summary>
        /// Activates when form is loaded.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            Left -= 100;
            outputConsole = new ConsoleForm(this);
            outputConsole.Show();
            outputConsole.Top = this.Bottom;
            outputConsole.Left = this.Left;
        }

        /// <summary>
        /// Activates when save button is clicked.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                String fileName = dlgSave.FileName.LastIndexOf(".b") > -1 ? dlgSave.FileName : dlgSave.FileName + ".b";

                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);

                byte[] buffer = Encoding.UTF8.GetBytes(scnCode.Text);

                fs.Write(buffer, 0, buffer.Length);

                fs.Close();
            }
        }

        /// <summary>
        /// Activates when load button is clicked.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(dlgOpen.FileName);

                FileStream fs = new FileStream(dlgOpen.FileName, FileMode.Open);

                byte[] buffer = new byte[fi.Length];

                fs.Read(buffer, 0, buffer.Length);

                scnCode.Text = Encoding.UTF8.GetString(buffer);

                fs.Close();
            }
        }
    }
}
