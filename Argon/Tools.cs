using System;

namespace Argon
{
    /// <summary>
    /// Contains various instances of <see cref="Microsoft.Xna.Framework"/> and <see cref="System"/> classes and structs,
    /// as well as helper methods for said classes and structs (XNA and Dotnet).
    /// </summary>
    public static class Tools
    {
        public static Random random;

        static Tools()
        {
            random = new Random(27466);
        }
    }
}
