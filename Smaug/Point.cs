namespace Smaug
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }
        public override bool Equals(object obj)
        {
            Point other = (Point)obj;
            return this.X == other.X && this.Y == other.Y;
        }
    }
}
