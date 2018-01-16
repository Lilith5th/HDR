﻿using System;

namespace HDR
{
    public class MyBitplaneDouble
    {
        public int width { get; set; }
        public int height { get; set; }

        public double[,] data { get; set; }

        public MyBitplaneDouble(MyBitplane bitplane)
        {
            width = bitplane.width;
            height = bitplane.height;

            data = new double[height, width];
            for (int y = 0; y < this.height; ++y)
                for (int x = 0; x < this.width; ++x)
                    SetPixel(x, y, (double)bitplane.GetPixel(x, y));
        }

        public MyBitplaneDouble(int w, int h)
        {
            width = w;
            height = h;

            data = new double[height, width];
        }

        public double GetPixel(int x, int y)
        {
            return data[y, x];
        }

        public void SetPixel(int x, int y, double value)
        {
            data[y, x] = value;
        }

        public void log()
        {
            for (int y = 0; y < height; ++y)
                for (int x = 0; x < width; ++x)
                    SetPixel(x, y, Math.Log(GetPixel(x, y)));
        }

        public void exp()
        {
            for (int y = 0; y < height; ++y)
                for (int x = 0; x < width; ++x)
                    SetPixel(x, y, Math.Exp(GetPixel(x, y)));
        }

        public void multiply(double value)
        {
            for (int y = 0; y < height; ++y)
                for (int x = 0; x < width; ++x)
                    SetPixel(x, y, GetPixel(x, y) * value);
        }

        public void divide(double value)
        {
            for (int y = 0; y < height; ++y)
                for (int x = 0; x < width; ++x)
                    SetPixel(x, y, GetPixel(x, y) / value);
        }

        public void normalize(double min, double max)
        {
            for (int y = 0; y < height; ++y)
                for (int x = 0; x < width; ++x)
                    SetPixel(x, y, GetPixel(x, y) - min / max - min);
        }

        public double findMax()
        {
            double max = Double.MinValue;
            for (int y = 0; y < height; ++y)
                for (int x = 0; x < width; ++x)
                    if (max < GetPixel(x, y))
                        max = GetPixel(x, y);
            return max;
        }

        public double findMin()
        {
            double min = Double.MaxValue;
            for (int y = 0; y < height; ++y)
                for (int x = 0; x < width; ++x)
                    if (min > GetPixel(x, y))
                        min = GetPixel(x, y);
            return min;
        }
    }
}
