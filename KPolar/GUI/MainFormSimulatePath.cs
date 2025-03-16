/*  GRBL-Plotter. Another GCode sender for GRBL.
    This file is part of the GRBL-Plotter application.
   
    Copyright (C) 2015-2024 Sven Hasemann contact: svenhb@web.de

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
/*
 * 2020-03-11 split from MainForm.cs
 * 2021-07-02 code clean up / code quality
 * 2021-12-02 add range test for index
 * 2022-03-29 line 115 check if (_serial_form != null)
 * 2022-04-07 reset codeInfo on start
 * 2023-01-07 use SetTextThreadSave(lbInfo...
 * 2024-05-03 l:206 f:SimulationTimer_Tick avoid division by 0
 * 2024-09-24 l:226 f:BtnSimulateSlower_Click adapt slowest simulation speed - issue #418
 * 2024-09-29 adapt dwell delay on faster/slower click
*/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace GrblPlotter
{
    public partial class MainForm
    {
        #region simulate path
        private static int simuLine = 0;
        private static bool simuEnabled = false;
        private static XyzPoint codeInfo = new XyzPoint();
        private static bool simulateA = false;

        
        
       

        

        

        
        

        #endregion
    }
}
