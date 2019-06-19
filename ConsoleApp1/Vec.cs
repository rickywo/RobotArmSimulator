namespace ConsoleApp1
{
    /* Vector structure */
    struct Vec
    {
        public int x, y;
        public Vec(int p1, int p2)
        {
            x = p1;
            y = p2;
        }

        public static Vec operator +(Vec v1,
            Vec v2)
        {
            Vec v3 = new Vec(0, 0);
            v3.x = v1.x + v2.x;
            v3.y = v1.y + v2.y;
            return v3;
        }
    }
}