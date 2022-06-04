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
            
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"../Program/beer.jpg");

            PipeNull pipeNull = new PipeNull();
            
            FilterNegative filterNegative = new FilterNegative();
            FilterGreyscale filterGreyscale = new FilterGreyscale();
            

            // Ejercicio 1
            
            /*
            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipeNull);

            PipeSerial pipeSerialGrey = new PipeSerial(filterGreyscale, pipeSerialNegative);

            picture = pipeSerialGrey.Send(picture);

            provider.SavePicture(picture, @"../Program/ModifiedImages/SavedImage.jpg");
            */

            //-------------------------------------------------------------------------------

            // Ejercicio 2
            FilterSave filterSave = new FilterSave();

            /*
            PipeSerial pipeSerialSave = new PipeSerial(filterSave, pipeNull);

            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipeSerialSave);

            PipeFork pipeForkSave = new PipeFork(pipeSerialNegative, pipeSerialSave);

            PipeSerial pipeSerialGrey = new PipeSerial(filterGreyscale, pipeForkSave);

            picture = pipeSerialGrey.Send(picture);
            */

            //-------------------------------------------------------------------------------

            // Ejercicio 3

        }
    }
}
