using System;
using System.Drawing; // Bắt buộc có dòng này để dùng Point

namespace baitap3
{
    public class InfoWindows
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Point Location { get; set; } // Lưu tọa độ X, Y
    }
}