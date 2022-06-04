using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    /// <summary>
    /// - Los ejercicio se encuentran como métodos de Program, para testearlos descomentarlos.
    /// - En la carpeta documents (../Documents) se encuentran png's de soluciones 
    ///     tipo grafos de los ejercicios 2 y 3.
    /// - Las imagenes que son guardadas se encuentran en la carpeta ModifiedImages en la 
    ///     carpeta Program
    /// - Cuando empeze a realizar los ejercicios 2 y 3 no sabia si era obligatorio utilizar
    ///     únicamente secuencias seriales, por lo que me pareció mejor utilizar directamente
    ///     una mezcla con bifurcaciones.
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //ejercicio_1();

            //ejercicio_2();

            //ejercicio_3();

            string path_image = @"../Program/beer.jpg";
            // Para probar el caso de imagen con rostro, descomentar la siguiente linea
            //path_image = @"../Program/luke.jpg";

            //ejercicio_4(path_image);
        }


        static void ejercicio_1()
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"../Program/beer.jpg");

            PipeNull pipeNull = new PipeNull();
            
            FilterNegative filterNegative = new FilterNegative();
            FilterGreyscale filterGreyscale = new FilterGreyscale();



            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipeNull);

            PipeSerial pipeSerialGrey = new PipeSerial(filterGreyscale, pipeSerialNegative);

            picture = pipeSerialGrey.Send(picture);

            provider.SavePicture(picture, @"../Program/ModifiedImages/SavedImage.jpg");
        }

        static void ejercicio_2()
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"../Program/beer.jpg");

            PipeNull pipeNull = new PipeNull();
            
            FilterNegative filterNegative = new FilterNegative();
            FilterGreyscale filterGreyscale = new FilterGreyscale();

            FilterSave filterSave = new FilterSave();



            PipeSerial pipeSerialSave = new PipeSerial(filterSave, pipeNull);

            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipeSerialSave);

            PipeFork pipeForkSave = new PipeFork(pipeSerialNegative, pipeSerialSave);

            PipeSerial pipeSerialGrey = new PipeSerial(filterGreyscale, pipeForkSave);

            picture = pipeSerialGrey.Send(picture);


        }

        static void ejercicio_3()
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"../Program/beer.jpg");

            PipeNull pipeNull = new PipeNull();
            
            FilterNegative filterNegative = new FilterNegative();
            FilterGreyscale filterGreyscale = new FilterGreyscale();

            FilterSave filterSave = new FilterSave();

            FilterTwitter filterTwitter = new FilterTwitter();



            PipeSerial pipeSerialTwitter = new PipeSerial(filterTwitter, pipeNull);

            PipeSerial pipeSerialSave = new PipeSerial(filterSave, pipeSerialTwitter);

            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipeSerialSave);

            PipeFork pipeForkSave = new PipeFork(pipeSerialNegative, pipeSerialSave);

            PipeSerial pipeSerialGrey = new PipeSerial(filterGreyscale, pipeForkSave);

            picture = pipeSerialGrey.Send(picture);


        }

        static void ejercicio_4(string pathImage)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(pathImage);

            PipeNull pipeNull = new PipeNull();
            
            FilterNegative filterNegative = new FilterNegative();
            FilterGreyscale filterGreyscale = new FilterGreyscale();

            FilterSave filterSave = new FilterSave();

            FilterTwitter filterTwitter = new FilterTwitter();



            // picture = provider.GetPicture(@"../Program/luke.jpg");

            // Cañeria Imagenes sin Cara
            PipeSerial pipeSerialSave1 = new PipeSerial(filterSave, pipeNull);

            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipeSerialSave1);

            // Cañeria Imagenes con cara
            PipeSerial pipeSerialTwitter = new PipeSerial(filterTwitter, pipeNull);

            PipeSerial pipeSerialSave2 = new PipeSerial(filterSave, pipeSerialTwitter);

            // Bifuración condicional

            PipeForkConditional pipeConditional = new PipeForkConditional(pipeSerialSave2, pipeSerialNegative);

            PipeSerial pipeSerialGrey = new PipeSerial(filterGreyscale, pipeConditional);

            picture = pipeSerialGrey.Send(picture);

        }
    }
}
