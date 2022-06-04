using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"../Program/beer.jpg");

            PipeNull pipenull = new PipeNull();
            FilterNegative filterNegative = new FilterNegative();
            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipenull);

            FilterGreyscale filterGreyscale = new FilterGreyscale();
            PipeSerial pipeSerialGrey = new PipeSerial(filterGreyscale, pipeSerialNegative);

            picture = pipeSerialGrey.Send(picture);

            provider.SavePicture(picture, @"../Program/Saved1.jpg");
        }
    }
}
