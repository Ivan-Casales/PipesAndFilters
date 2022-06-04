using System;
using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen, analiza si tiene cara y modifica el atributo
    ///     Face (bool) al respecto.
    /// </remarks>
    public class FilterFaceConditional : IFilter
    {
        public bool Face {get; private set;}

        /// Modifica Face (bool) respecto a si la imagen contiene o no una cara.
        /// </summary>
        /// <param name="image"> La imagen que será analizada.</param>
        /// <returns> La misma imagen.</returns>
        public IPicture Filter(IPicture image)
        {
            PictureProvider pr = new PictureProvider();
            // En la siguiente linea guardo la imagen en una ruta para usarlo en CognitiveFace
            pr.SavePicture(image, @"FolderToRecognizeImages/image.jpg");

            CognitiveFace cog = new CognitiveFace();
            cog.Recognize(@"FolderToRecognizeImages/image.jpg");
            this.Face = cog.FaceFound;

            return image;
        }

    }
}