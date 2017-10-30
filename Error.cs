// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Error.cs" company="">
//   
// </copyright>
// <summary>
//   The error.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;
using System.Windows.Forms;

#endregion

namespace CoffeeEditor
{
    /// <summary>
    /// The error.
    /// </summary>
    public partial class Error : Form
    {
        /// <summary>
        /// The _error.
        /// </summary>
        private readonly string _error;

        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="error">
        /// The error.
        /// </param>
        public Error(string error)
        {
            InitializeComponent();
            _error = error;
        }

        /// <summary>
        /// The error_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Error_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = _error;
        }
    }
}