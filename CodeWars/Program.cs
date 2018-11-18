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
            string colorToParse;
            color = color.ToLower();
            if ( color[0].Equals( '#' ) )
            {
                colorToParse = color.Length == 4 ? $"{color[1]}{color[1]}{color[2]}{color[2]}{color[3]}{color[3]}" : color.Remove( 0, 1 );
            }
            else if ( presetColors.ContainsKey( color ) )
            {
                presetColors.TryGetValue( color, out colorToParse );
                colorToParse = colorToParse.Remove(0, 1);
            }
            else
                colorToParse = "000000";

            byte parseToNum( string col )
            {
                return (byte) (parseToDigit(col[0]) * 16 + parseToDigit(col[1]));
            }

            byte parseToDigit( char ch )
            {
                if (ch >= '0' && ch <= '9')
                    return (byte) (ch - '0');
                if (ch >= 'a' && ch <= 'f')
                    return (byte) (ch - 'a' + 10);
                return 0;
            }

            return new RGB( parseToNum( colorToParse.Substring( 0, 2 ) ),
                            parseToNum( colorToParse.Substring( 2, 2 ) ),
                            parseToNum( colorToParse.Substring( 4, 2 ) )
            );
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
