using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    /// <summary>
    /// En la carpeta documents se encuentra un png con la solución al Ejercicio 2
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {
            // Ejercicio 2
            /*
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"../Program/beer.jpg");

            PipeNull pipenull = new PipeNull();
            FilterNegative filterNegative = new FilterNegative();
            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipenull);

            FilterGreyscale filterGreyscale = new FilterGreyscale();
            PipeSerial pipeSerialGrey = new PipeSerial(filterGreyscale, pipeSerialNegative);

            picture = pipeSerialGrey.Send(picture);

            provider.SavePicture(picture, @"../Program/ModifiedImages/SavedImage.jpg");
            */

            //-------------------------------------------------------------------------------

            // Ejercicio 2
            /*
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"../Program/luke.jpg");

            PipeNull pipeNull = new PipeNull();

            FilterSave filterSave = new FilterSave();
            PipeSerial pipeSerialSave = new PipeSerial(filterSave, pipeNull);

            FilterNegative filterNegative = new FilterNegative();
            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipeSerialSave);

            PipeFork pipeForkSave = new PipeFork(pipeSerialNegative, pipeSerialSave);

            FilterGreyscale filterGreyscale = new FilterGreyscale();
            PipeSerial pipeSerialGrey = new PipeSerial(filterGreyscale, pipeForkSave);

            picture = pipeSerialGrey.Send(picture);
            */

            // Ejercicio 3

            
        }
    }
}
