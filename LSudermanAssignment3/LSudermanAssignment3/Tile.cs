/*
 * Program Name: LSudermanAsignment3
 * 
 * Purpose: creates some custom values to add to a picture box, in the form of a tile
 * 
 * Revision History:
 *          November 11, 2019: Created
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSudermanAssignment3
{
    /// <summary>
    /// this is the tile class
    /// </summary>
    public class Tile : PictureBox
    {
        public int left;
        public int down;
        public int tileType;
    }
}
