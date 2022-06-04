using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    /// <summary>
    /// Los distintos ejercicios (tuberias) están comentados. El código que no se 
    ///     encuentra comentado es porque es reutilizado en varios ejercicios.
    /// En la carpeta documents (../Documents) se encuentran png's de soluciones 
    ///     tipo grafos de los ejercicios 2 y 3.
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
            FilterTwitter filterTwitter = new FilterTwitter();

            /*
            PipeSerial pipeSerialTwitter = new PipeSerial(filterTwitter, pipeNull);

            PipeSerial pipeSerialSave = new PipeSerial(filterSave, pipeSerialTwitter);

            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipeSerialSave);

            PipeFork pipeForkSave = new PipeFork(pipeSerialNegative, pipeSerialSave);

            PipeSerial pipeSerialGrey = new PipeSerial(filterGreyscale, pipeForkSave);

            picture = pipeSerialGrey.Send(picture);
            */

            //-------------------------------------------------------------------------------

            // Ejercicio 4
            
        }
    }
}
