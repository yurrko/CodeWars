using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    class Program
    {
        static void Main( string[] args )
        {
            var colorDic = new Dictionary<string, string>();
            colorDic.Add( "limegreen", "32cd32" );
            var colorParser = new HtmlColorParser( colorDic );

            Console.WriteLine(
                colorParser.Parse( "LimeGreen" )
            );

            Console.ReadLine();
        }
    }

    class HtmlColorParser
    {
        private readonly IDictionary<string, string> presetColors;

        public HtmlColorParser( IDictionary<string, string> presetColors )
        {
            this.presetColors = presetColors;
        }

        public RGB Parse( string color )
        {
            color = color.ToLower();
            string hex;

            if ( presetColors.ContainsKey( color ) )
                hex = presetColors[color];
            else if ( color.Length == 4 )
                hex = string.Format( "#{0}{0}{1}{1}{2}{2}", color[1], color[2], color[3] );
            else
                hex = color;

            var n = Convert.ToInt32( hex.Substring( 1 ), 16 );
            return new RGB( (byte)( ( n >> 16 ) & 0xFF ), (byte)( ( n >> 8 ) & 0xFF ), (byte)( n & 0xFF ) );
        }
    }

    struct RGB
    {
        public byte _r, _g, _b;
        public RGB( byte r, byte g, byte b )
        {
            (_r, _g, _b) = (r, g, b);
        }

        public override string ToString() => $"R={_r} G={_g} B={_b}";
    }
}
