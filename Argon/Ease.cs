using System;

namespace Argon
{
    /// <summary>
    /// Provides functions for smoothly transitioning between values. From https://github.com/ai/easings.net.
    /// </summary>
    public static class Ease
    {
        public static class Sine
        {
            public static float In(float x)
            {
                return 1 - Out(x);
            }

            public static float Out(float x)
            {
                return MathF.Cos((x * MathF.PI) / 2);
            }

            public static float InOut(float x)
            {
                return -(MathF.Cos(MathF.PI * x) - 1) / 2;
            }
        }

        public static class Quad
        {
            public static float In(float x)
            {
                return MathF.Pow(x, 2);
            }

            public static float Out(float x)
            {
                return 1 - MathF.Pow(1 - x, 2);
            }

            public static float InOut(float x)
            {
                return x < 0.5 ? 2 * MathF.Pow(x, 2) : 1 - MathF.Pow(-2 * x + 2, 2) / 2;
            }
        }

        public static class Cubic
        {
            public static float In(float x)
            {
                return MathF.Pow(x, 3);
            }

            public static float Out(float x)
            {
                return 1 - MathF.Pow(1 - x, 3);
            }

            public static float InOut(float x)
            {
                return x < 0.5f ? 4 * MathF.Pow(x, 3) : 1 - MathF.Pow(-2 * x + 2, 3) / 2;
            }
        }

        public static class Quart
        {
            public static float In(float x)
            {
                return MathF.Pow(x, 4);
            }

            public static float Out(float x)
            {
                return 1 - MathF.Pow(1 - x, 4);
            }

            public static float InOut(float x)
            {
                return x < 0.5f ? 8 * MathF.Pow(x, 4) : 1 - MathF.Pow(-2 * x + 2, 4) / 2;
            }
        }

        public static class Quint
        {
            public static float In(float x)
            {
                return MathF.Pow(x, 5);
            }

            public static float Out(float x)
            {
                return 1 - MathF.Pow(1 - x, 5);
            }

            public static float InOut(float x)
            {
                return x < 0.5 ? 16 * MathF.Pow(x, 5) : 1 - MathF.Pow(-2 * x + 2, 5) / 2;
            }
        }

        public static class Expo
        {
            public static float In(float x)
            {
                return x == 0 ? 0 : MathF.Pow(2, 10 * x - 10);
            }

            public static float Out(float x)
            {
                return x == 1 ? 1 : 1 - MathF.Pow(2, -10 * x);
            }

            public static float InOut(float x)
            {
                return x == 0 ? 0 : x == 1 ? 1 : x < 0.5 ? MathF.Pow(2, 20 * x - 10) / 2 : (2 - MathF.Pow(2, -20 * x + 10)) / 2;
            }
        }

        public static class Circ
        {
            public static float In(float x)
            {
                return 1 - MathF.Sqrt(1 - MathF.Pow(x, 2));
            }

            public static float Out(float x)
            {
                return MathF.Sqrt(1 - MathF.Pow(x - 1, 2));
            }

            public static float InOut(float x)
            {
                return
                    x < 0.5 ? (1 - MathF.Sqrt(1 - MathF.Pow(2 * x, 2))) / 2 :
                    (MathF.Sqrt(1 - MathF.Pow(-2 * x + 2, 2)) + 1) / 2;
            }
        }

        public static class Back
        {
            private const float c1 = 1.70158f;
            private const float c2 = c1 * 1.525f;
            private const float c3 = c1 + 1;

            public static float In(float x)
            {
                return c3 * MathF.Pow(x, 3) - c1 * MathF.Pow(x, 2);
            }

            public static float Out(float x)
            {
                return 1 + c3 * MathF.Pow(x - 1, 3) + c1 * MathF.Pow(x - 1, 2);
            }

            public static float InOut(float x)
            {
                return
                    x < 0.5 ? (MathF.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2)) / 2 :
                    (MathF.Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
            }
        }
    }
}
