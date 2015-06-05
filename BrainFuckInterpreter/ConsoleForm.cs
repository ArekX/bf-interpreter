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
    /// Represents linked brackets structure.
    /// </summary>
    struct Bracket
    {
        public int fromBracketPC;
        public int toBracketPC;
    }

    /// <summary>
    /// Console form
    /// </summary>
    public partial class ConsoleForm : Form
    {
        bool disposeOnFinish = false;
        List<Bracket> bracketList;

        byte[] memory;
        uint memoryPointer;
        int inputPointer;
        int PC;

        MainForm frm;
        String code;

        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="main">MainFrom instance.</param>
        public ConsoleForm(MainForm main)
        {
            frm = main;
            bracketList = new List<Bracket>();
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// Executes BrainF**k code
        /// </summary>
        /// <param name="code">String with code to be executed.</param>
        /// <param name="memorySize">Size of memory to be used.</param>
        public void executeCode(String code, int memorySize)
        {
            memory = new byte[memorySize];
            this.code = code;
            memoryPointer = 0;
            inputPointer = 0;
            PC = 0;
            bracketList.Clear();
            txtOutput.Clear();

            bgWorker.RunWorkerAsync();
            TopMost = true;
        }

        /// <summary>
        /// Cancels current execution.
        /// </summary>
        public void cancelExecution()
        {
            bgWorker.CancelAsync();
        }

        /// <summary>
        /// Copies output to clipboard.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments</param>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtOutput.Text);
        }

        /// <summary>
        /// Clears output.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
        }

        /// <summary>
        /// Activates when key is pressed while on console window.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void ConsoleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (bgWorker.IsBusy)
                    disposeOnFinish = true;
                else
                    this.Dispose();
            }
        }

        /// <summary>
        /// Executes code character by character after
        /// performing syntax check.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            txtOutput.Text = "Syntax check...";

            int bracketCounter = 0;
            Stack<int> openStack = new Stack<int>();

            while(PC != code.Length)
            {
                if (code[PC] == '[')
                {
                    openStack.Push(PC);
                    bracketCounter++;
                }
                else if (code[PC] == ']')
                {
                    bracketCounter--;

                    if (bracketCounter > -1)
                    {
                        int startBracket = openStack.Pop();
                        bracketList.Add(new Bracket() { fromBracketPC = startBracket, toBracketPC = PC });
                        bracketList.Add(new Bracket() { fromBracketPC = PC, toBracketPC = startBracket });
                    }
                    else
                    {
                         txtOutput.Text = "Error: Too many closed brackets. At: " + PC.ToString();
                         return;
                    }
                }

                PC++;
            }

            if (openStack.Count > 0)
            {
                txtOutput.Text = "Error: Not enough closed brackets.";
                return;
            }

            PC = 0;
            openStack.Clear();

            txtOutput.Text = "";

            StringBuilder sb = new StringBuilder();
            StringBuilder output = new StringBuilder();

            bool debugMode = ((frm.debug != null) && !frm.debug.IsDisposed);
            bool nonConstantMode = !frm.chkConstant.Checked;
            char instruction = '\0';

            while(!bgWorker.CancellationPending && (PC != code.Length))
            {
                instruction = code[PC];

                if (debugMode)
                {
                    sb.Clear();
                    sb.Append("[" + PC + "] : ");
                }

                switch (instruction)
                {
                    case '>':
                        memoryPointer++;
                        if (debugMode)
                            sb.Append("Move right to pointer - ").Append(memoryPointer);
                        break;
                    case '<':
                        memoryPointer--;
                        if (debugMode)
                            sb.Append("Move left to pointer - ").Append(memoryPointer);
                        break;
                    case '+':
                        if (memoryPointer < memory.Length)
                            memory[memoryPointer]++;
                        if (debugMode)
                            sb.Append("Pointer increment -> memory[").Append(memoryPointer).Append("]=").Append(memory[memoryPointer]);
                        break;
                    case '-':
                        if (memoryPointer < memory.Length)
                            memory[memoryPointer]--;
                        if (debugMode)
                            sb.Append("Pointer decrement -> memory[").Append(memoryPointer).Append("]=").Append(memory[memoryPointer]);
                        break;
                    case '.':
                        if (memoryPointer < memory.Length)
                        {
                            if (nonConstantMode)
                                output.Append((char)memory[memoryPointer]);
                            else
                                txtOutput.Text += (char)memory[memoryPointer];
                            if (debugMode)
                            {
                                sb.Append("Character ");
                                if (memory[memoryPointer] == 0)
                                    sb.Append("null");
                                else
                                    sb.Append("'").Append((char)memory[memoryPointer]).Append("'");

                                sb.Append(" output.");
                            }
                        }
                        break;
                    case ',':
                        if (memoryPointer < memory.Length)
                        {
                            memory[memoryPointer] = frm.getInputByte(inputPointer++);

                            if (debugMode)
                            {
                                sb.Append("Character ");
                                if (memory[memoryPointer] == 0)
                                    sb.Append("null");
                                else
                                    sb.Append("'").Append((char)memory[memoryPointer]).Append("'");

                                sb.Append(" taken from input.");
                            }
                        }
                        break;
                    case '[':
                        if ((memoryPointer >= memory.Length) || (memory[memoryPointer] == 0))
                        {
                            foreach (Bracket b in bracketList)
                            {
                                if (b.fromBracketPC == PC)
                                {
                                    PC = b.toBracketPC;
                                    if (debugMode)
                                        sb.Append("Jump out of while loop from start.");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (debugMode)
                                sb.Append("Enter while loop.");
                        }
                        break;
                    case ']':
                        if ((memoryPointer >= memory.Length) || (memory[memoryPointer] != 0))
                        {
                            foreach (Bracket b in bracketList)
                            {
                                if (b.fromBracketPC == PC)
                                {
                                    PC = b.toBracketPC;
                                    if (debugMode)
                                        sb.Append("Jump back to start of while loop.");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (debugMode)
                                sb.Append("Jump out of while loop.");
                        }
                        break;
                    default:
                        if (debugMode)
                            sb.Append("Skipping comment.");
                        break;
                }

                if (debugMode)
                    frm.debug.addLine(sb.ToString(), PC);

                txtOutput.Select(txtOutput.Text.Length, 0);
                txtOutput.ScrollToCaret();
                PC++;
            }

            if (nonConstantMode)
                txtOutput.Text = output.ToString();
        }

        /// <summary>
        /// Function which runs when background worker has
        /// completed or canceled its task.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            frm.programFinish();
            TopMost = false;

            frm.Focus();

            if (disposeOnFinish)
                this.Dispose();
        }

        /// <summary>
        /// Event which activates when form is closing.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void ConsoleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bgWorker.IsBusy)
            {
                e.Cancel = true;
                disposeOnFinish = true;
            }
        }
    }
}
