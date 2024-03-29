﻿// -----------------------------------------------------------------------
// <copyright file="Program.cs">
//     Copyright (c) Cezar Petriuc. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace DungeonCrawler
{
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}